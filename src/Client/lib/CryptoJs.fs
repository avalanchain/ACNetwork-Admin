// ts2fable 0.6.1
module rec CryptoJs
open System
open Fable.Core
open Fable.Import.JS

let [<Import("*","crypto-js")>] CryptoJS: CryptoJS.Hashes = jsNative

module CryptoJS =

    type [<AllowNullLiteral>] Base =
        interface end

    type [<AllowNullLiteral>] BufferedBlockAlgorithm =
        inherit Base

    type [<AllowNullLiteral>] Hasher =
        inherit BufferedBlockAlgorithm

    type [<AllowNullLiteral>] Cipher =
        inherit BufferedBlockAlgorithm
        abstract createEncryptor: secretPassphrase: string * ?option: CipherOption -> Encryptor
        abstract createDecryptor: secretPassphrase: string * ?option: CipherOption -> Decryptor

    type [<AllowNullLiteral>] BlockCipher =
        inherit Cipher

    type [<AllowNullLiteral>] StreamCipher =
        inherit Cipher

    type [<AllowNullLiteral>] CipherHelper =
        abstract encrypt: message: string * secretPassphrase: U2<string, WordArray> * ?option: CipherOption -> WordArray
        abstract decrypt: encryptedMessage: U2<string, WordArray> * secretPassphrase: U2<string, WordArray> * ?option: CipherOption -> DecryptedMessage

    type [<AllowNullLiteral>] Encryptor =
        abstract ``process``: messagePart: string -> string
        abstract finalize: unit -> string

    type [<AllowNullLiteral>] Decryptor =
        abstract ``process``: messagePart: string -> string
        abstract finalize: unit -> string

    type [<AllowNullLiteral>] LibWordArray =
        abstract sigBytes: float with get, set
        abstract words: ResizeArray<float> with get, set

    type [<AllowNullLiteral>] WordArray =
        abstract iv: string with get, set
        abstract salt: string with get, set
        abstract ciphertext: string with get, set
        abstract key: string option with get, set
        abstract toString: ?encoder: Encoder -> string

    type [<AllowNullLiteral>] DecryptedMessage =
        abstract toString: ?encoder: Encoder -> string

    type [<AllowNullLiteral>] CipherOption =
        abstract iv: string option with get, set
        abstract mode: Mode option with get, set
        abstract padding: Padding option with get, set
        [<Emit "$0[$1]{{=$2}}">] abstract Item: option: string -> obj option with get, set

    type [<AllowNullLiteral>] Encoder =
        abstract parse: encodedMessage: string -> obj option
        abstract stringify: words: obj option -> string

    type [<AllowNullLiteral>] Mode =
        interface end

    type [<AllowNullLiteral>] Padding =
        interface end

    type [<AllowNullLiteral>] Hashes =
        abstract MD5: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract MD5: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract SHA1: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract SHA1: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract SHA256: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract SHA256: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract SHA224: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract SHA224: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract SHA512: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract SHA512: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract SHA384: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract SHA384: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract SHA3: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract SHA3: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract RIPEMD160: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract RIPEMD160: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacMD5: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacMD5: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacSHA1: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacSHA1: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacSHA256: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacSHA256: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacSHA224: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacSHA224: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacSHA512: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacSHA512: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacSHA384: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacSHA384: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacSHA3: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacSHA3: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacRIPEMD160: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract HmacRIPEMD160: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract PBKDF2: message: U2<string, LibWordArray> * ?key: U2<string, WordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract PBKDF2: message: U2<string, LibWordArray> * [<ParamArray>] options: ResizeArray<obj option> -> WordArray
        abstract AES: CipherHelper with get, set
        abstract DES: CipherHelper with get, set
        abstract TripleDES: CipherHelper with get, set
        abstract RC4: CipherHelper with get, set
        abstract RC4Drop: CipherHelper with get, set
        abstract Rabbit: CipherHelper with get, set
        abstract RabbitLegacy: CipherHelper with get, set
        abstract EvpKDF: CipherHelper with get, set
        abstract algo: obj with get, set
        abstract format: obj with get, set
        abstract enc: obj with get, set
        abstract lib: obj with get, set
        abstract mode: obj with get, set
        abstract pad: obj with get, set
