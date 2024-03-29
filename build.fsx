// --------------------------------------------------------------------------------------
// FAKE build script
// --------------------------------------------------------------------------------------

#r @"packages/build/FAKE/tools/FakeLib.dll"

open Fake
open Fake.Git
open Fake.AssemblyInfoFile
open Fake.ReleaseNotesHelper
open System
open System.IO
open Fake.Testing.Expecto

let project = "Suave/Fable sample"

let summary = "SAFE sample"

let description = summary

let configuration = "Release"

let clientPath = "./src/Client" |> FullName

let serverPath = "./src/Server/" |> FullName

let dotnetcliVersion = DotNetCli.GetDotNetSDKVersionFromGlobalJson()
let mutable dotnetExePath = "dotnet"

let deployDir = "./deploy"

let dockerUser = getBuildParam "DockerUser"
let dockerPassword = getBuildParam "DockerPassword"
let dockerLoginServer = getBuildParam "DockerLoginServer"
let dockerImageName = getBuildParam "DockerImageName"

// --------------------------------------------------------------------------------------
// END TODO: The rest of the file includes standard build steps
// --------------------------------------------------------------------------------------

let run' timeout cmd args dir =
    if execProcess (fun info ->
        info.FileName <- cmd
        if not (String.IsNullOrWhiteSpace dir) then
            info.WorkingDirectory <- dir
        info.Arguments <- args
    ) timeout |> not then
        failwithf "Error while running '%s' with args: %s" cmd args

let run = run' System.TimeSpan.MaxValue

let runDotnet workingDir args =
    let result =
        ExecProcess (fun info ->
            info.FileName <- dotnetExePath
            info.WorkingDirectory <- workingDir
            info.Arguments <- args) TimeSpan.MaxValue
    if result <> 0 then failwithf "dotnet %s failed" args

let platformTool tool winTool =
    let tool = if isUnix then tool else winTool
    tool
    |> ProcessHelper.tryFindFileOnPath
    |> function Some t -> t | _ -> failwithf "%s not found" tool

let nodeTool = platformTool "node" "node.exe"
let npmTool = platformTool "npm" "npm.cmd"
let yarnTool = platformTool "yarn" "yarn.cmd"

do if not isWindows then
    // We have to set the FrameworkPathOverride so that dotnet sdk invocations know
    // where to look for full-framework base class libraries
    let mono = platformTool "mono" "mono"
    let frameworkPath = IO.Path.GetDirectoryName(mono) </> ".." </> "lib" </> "mono" </> "4.5"
    setEnvironVar "FrameworkPathOverride" frameworkPath


// Read additional information from the release notes document
// let releaseNotes = File.ReadAllLines "RELEASE_NOTES.md"

// let releaseNotesData =
//     releaseNotes
//     |> parseAllReleaseNotes

// let release = List.head releaseNotesData

// --------------------------------------------------------------------------------------
// Clean build results

Target "Clean" (fun _ ->
    !!"src/**/bin"
    |> CleanDirs

    !! "src/**/obj/*.nuspec"
    |> DeleteFiles

    CleanDirs ["bin"; "temp"; "docs/output"; deployDir; Path.Combine(clientPath,"public/bundle")]
)

Target "InstallDotNetCore" (fun _ ->
    dotnetExePath <- DotNetCli.InstallDotNetSDK dotnetcliVersion
)

// --------------------------------------------------------------------------------------
// Build library & test project


Target "BuildServer" (fun _ ->
    runDotnet serverPath "build"
)

Target "InstallClient" (fun _ ->
    printfn "Node version:"
    run nodeTool "--version" __SOURCE_DIRECTORY__
    printfn "Yarn version:"
    run yarnTool "--version" __SOURCE_DIRECTORY__
    run yarnTool "install --frozen-lockfile" __SOURCE_DIRECTORY__
)

Target "BuildClient" (fun _ ->
    runDotnet clientPath "restore"
    runDotnet clientPath "fable webpack --port free -- -p --mode production"
)

// --------------------------------------------------------------------------------------
// Run the Website

let ipAddress = "localhost"
let port = 8080
let serverPort = 8085

FinalTarget "KillProcess" (fun _ ->
    killProcess "dotnet"
    killProcess "dotnet.exe"
)


Target "Run" (fun _ ->
    runDotnet clientPath "restore"
    runDotnet serverPath "restore"

    let server = async {
        runDotnet serverPath "watch run" 
    }

    let fablewatch = async { runDotnet clientPath "fable webpack-dev-server --port free -- --mode development" }
    let openBrowser = async {
        System.Threading.Thread.Sleep(5000)
        Diagnostics.Process.Start("http://"+ ipAddress + sprintf ":%d" port) |> ignore }

    Async.Parallel [| server; fablewatch; openBrowser |]
    |> Async.RunSynchronously
    |> ignore
)


Target "RunSSR" (fun _ ->
    runDotnet clientPath "restore"
    runDotnet serverPath "restore"

    let server = async {
        runDotnet serverPath "watch run" 
    }

    let fablewatch = async { runDotnet clientPath "fable webpack --port free -- -w --mode development" }
    let openBrowser = async {
        System.Threading.Thread.Sleep(10000)
        Diagnostics.Process.Start("http://"+ ipAddress + sprintf ":%d" serverPort) |> ignore }

    Async.Parallel [| server; fablewatch; openBrowser |]
    |> Async.RunSynchronously
    |> ignore
)


// --------------------------------------------------------------------------------------
// Release Scripts


Target "BundleClient" (fun _ ->
    let result =
        ExecProcess (fun info ->
            info.FileName <- dotnetExePath
            info.WorkingDirectory <- serverPath
            info.Arguments <- "publish -c Release -o \"" + FullName deployDir + "\"") TimeSpan.MaxValue
    if result <> 0 then failwith "Publish failed"

    let clientDir = deployDir </> "client"
    let publicDir = clientDir </> "public"
    let jsDir = clientDir </> "js"
    let cssDir = clientDir </> "css"
    let imageDir = clientDir </> "Images"

    !! "src/Client/public/**/*.*" |> CopyFiles publicDir
    !! "src/Client/js/**/*.*" |> CopyFiles jsDir
    !! "src/Client/css/**/*.*" |> CopyFiles cssDir
    !! "src/Client/Images/**/*.*" |> CopyFiles imageDir

    "src/Client/index.html" |> CopyFile clientDir
)

Target "CreateDockerImage" (fun _ ->
    if String.IsNullOrEmpty dockerUser then
        failwithf "docker username not given."
    if String.IsNullOrEmpty dockerImageName then
        failwithf "docker image Name not given."
    let result =
        ExecProcess (fun info ->
            info.FileName <- "docker"
            info.UseShellExecute <- false
            info.Arguments <- sprintf "build -t %s/%s ." dockerUser dockerImageName) TimeSpan.MaxValue
    if result <> 0 then failwith "Docker build failed"
)

Target "TestDockerImage" (fun _ ->
    ActivateFinalTarget "KillProcess"
    let testImageName = "test"

    let result =
        ExecProcess (fun info ->
            info.FileName <- "docker"
            info.Arguments <- sprintf "run -d -p 127.0.0.1:8086:8085 --rm --name %s -it %s/%s" testImageName dockerUser dockerImageName) TimeSpan.MaxValue
    if result <> 0 then failwith "Docker run failed"

    System.Threading.Thread.Sleep 5000 |> ignore  // give server some time to start

    // !! clientTestExecutables
    // |> Expecto (fun p -> { p with Parallel = false } )
    // |> ignore

    let result =
        ExecProcess (fun info ->
            info.FileName <- "docker"
            info.Arguments <- sprintf "stop %s" testImageName) TimeSpan.MaxValue
    if result <> 0 then failwith "Docker stop failed"
)

Target "Deploy" (fun _ ->
    let result =
        ExecProcess (fun info ->
            info.FileName <- "docker"
            info.WorkingDirectory <- deployDir
            info.Arguments <- sprintf "login %s --username \"%s\" --password \"%s\"" dockerLoginServer dockerUser dockerPassword) TimeSpan.MaxValue
    if result <> 0 then failwith "Docker login failed"

    let result =
        ExecProcess (fun info ->
            info.FileName <- "docker"
            info.WorkingDirectory <- deployDir
            info.Arguments <- sprintf "push %s/%s" dockerUser dockerImageName) TimeSpan.MaxValue
    if result <> 0 then failwith "Docker push failed"
)

// -------------------------------------------------------------------------------------
Target "Build" DoNothing
Target "All" DoNothing

"Clean"
  ==> "InstallDotNetCore"
  ==> "InstallClient"
//   ==> "SetReleaseNotes"
  ==> "BuildServer"
  ==> "BuildClient"
//   ==> "BuildServerTests"
//   ==> "RunServerTests"
//   ==> "BuildClientTests"
//   ==> "RunClientTests"
  ==> "BundleClient"
  ==> "All"
//  ==> "CreateDockerImage"
//  ==> "TestDockerImage"
//  ==> "PrepareRelease"
//  ==> "Deploy"

"BuildClient"
  ==> "Build"

"InstallClient"
  ==> "Run"

"InstallClient"
  ==> "RunSSR"

RunTargetOrDefault "All"
