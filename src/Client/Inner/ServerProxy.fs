module Client.ServerProxy

open Shared
open Fable.Remoting.Client

let cabinetApi : ICabinetProtocol =
    Proxy.remoting<ICabinetProtocol> {
        use_route_builder Route.builder
    }
