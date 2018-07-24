// ts2fable 0.6.1
module rec Web3Types
open System
open Fable.Core
open Fable.Import
open Fable.Import.JS

// module Us = Underscore
open BigNumber 

type [<AllowNullLiteral>] IExports =
    abstract Eth: EthStatic
    abstract Net: NetStatic
    abstract Personal: PersonalStatic
    abstract Shh: ShhStatic
    abstract Bzz: BzzStatic
    abstract BatchRequest: BatchRequestStatic

type [<AllowNullLiteral>] JsonRPCRequest =
    abstract jsonrpc: string with get, set
    abstract ``method``: string with get, set
    abstract ``params``: ResizeArray<obj option> with get, set
    abstract id: float with get, set

type [<AllowNullLiteral>] JsonRPCResponse =
    abstract jsonrpc: string with get, set
    abstract id: float with get, set
    abstract result: obj option with get, set
    abstract error: string option with get, set

type [<AllowNullLiteral>] Callback<'T> =
    [<Emit "$0($1...)">] abstract Invoke: error: Error * result: 'T -> unit

type ABIDataTypes =
    U5<string, string, string, string, string>

[<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module ABIDataTypes =
    let ofCase1 v: ABIDataTypes = v |> U5.Case1
    let isCase1 (v: ABIDataTypes) = match v with U5.Case1 _ -> true | _ -> false
    let asCase1 (v: ABIDataTypes) = match v with U5.Case1 o -> Some o | _ -> None
    let ofCase2 v: ABIDataTypes = v |> U5.Case2
    let isCase2 (v: ABIDataTypes) = match v with U5.Case2 _ -> true | _ -> false
    let asCase2 (v: ABIDataTypes) = match v with U5.Case2 o -> Some o | _ -> None
    let ofCase3 v: ABIDataTypes = v |> U5.Case3
    let isCase3 (v: ABIDataTypes) = match v with U5.Case3 _ -> true | _ -> false
    let asCase3 (v: ABIDataTypes) = match v with U5.Case3 o -> Some o | _ -> None
    let ofCase4 v: ABIDataTypes = v |> U5.Case4
    let isCase4 (v: ABIDataTypes) = match v with U5.Case4 _ -> true | _ -> false
    let asCase4 (v: ABIDataTypes) = match v with U5.Case4 o -> Some o | _ -> None
    let ofString v: ABIDataTypes = v |> U5.Case5
    let isString (v: ABIDataTypes) = match v with U5.Case5 _ -> true | _ -> false
    let asString (v: ABIDataTypes) = match v with U5.Case5 o -> Some o | _ -> None

type [<StringEnum>] [<RequireQualifiedAccess>] PromiEventType =
    | TransactionHash
    | Receipt
    | Confirmation
    | Error

type [<AllowNullLiteral>] PromiEvent<'T> =
    inherit Promise<'T>
    [<Emit "$0.once('transactionHash',$1)">] abstract once_transactionHash: handler: (string -> unit) -> PromiEvent<'T>
    [<Emit "$0.once('receipt',$1)">] abstract once_receipt: handler: (TransactionReceipt -> unit) -> PromiEvent<'T>
    [<Emit "$0.once('confirmation',$1)">] abstract once_confirmation: handler: (float -> TransactionReceipt -> unit) -> PromiEvent<'T>
    [<Emit "$0.once('error',$1)">] abstract once_error: handler: (Error -> unit) -> PromiEvent<'T>
    abstract once: ``type``: U4<string, string, string, string> * handler: (U3<Error, TransactionReceipt, string> -> unit) -> PromiEvent<'T>
    [<Emit "$0.on('transactionHash',$1)">] abstract on_transactionHash: handler: (string -> unit) -> PromiEvent<'T>
    [<Emit "$0.on('receipt',$1)">] abstract on_receipt: handler: (TransactionReceipt -> unit) -> PromiEvent<'T>
    [<Emit "$0.on('confirmation',$1)">] abstract on_confirmation: handler: (float -> TransactionReceipt -> unit) -> PromiEvent<'T>
    [<Emit "$0.on('error',$1)">] abstract on_error: handler: (Error -> unit) -> PromiEvent<'T>
    abstract on: ``type``: U4<string, string, string, string> * handler: (U3<Error, TransactionReceipt, string> -> unit) -> PromiEvent<'T>

type [<AllowNullLiteral>] EventEmitter =
    [<Emit "$0.on('data',$1)">] abstract on_data: handler: (EventLog -> unit) -> EventEmitter
    [<Emit "$0.on('changed',$1)">] abstract on_changed: handler: (EventLog -> unit) -> EventEmitter
    [<Emit "$0.on('error',$1)">] abstract on_error: handler: (Error -> unit) -> EventEmitter
    abstract on: ``type``: U3<string, string, string> * handler: (U3<Error, TransactionReceipt, string> -> unit) -> EventEmitter

type [<AllowNullLiteral>] TransactionObject<'T> =
    abstract arguments: ResizeArray<obj option> with get, set
    abstract call: ?tx: Tx -> Promise<'T>
    abstract send: ?tx: Tx -> PromiEvent<'T>
    abstract estimateGas: ?tx: Tx -> Promise<float>
    abstract encodeABI: unit -> string

type [<AllowNullLiteral>] ABIDefinition =
    abstract constant: bool option with get, set
    abstract payable: bool option with get, set
    abstract anonymous: bool option with get, set
    abstract inputs: Array<obj> option with get, set
    abstract name: string option with get, set
    abstract outputs: Array<obj> option with get, set
    abstract ``type``: U4<string, string, string, string> with get, set

type [<AllowNullLiteral>] CompileResult =
    abstract code: string with get, set
    abstract info: obj with get, set
    abstract userDoc: obj with get, set
    abstract developerDoc: obj with get, set

type [<AllowNullLiteral>] Transaction =
    abstract hash: string with get, set
    abstract nonce: float with get, set
    abstract blockHash: string with get, set
    abstract blockNumber: float with get, set
    abstract transactionIndex: float with get, set
    abstract from: string with get, set
    abstract ``to``: string with get, set
    abstract value: string with get, set
    abstract gasPrice: string with get, set
    abstract gas: float with get, set
    abstract input: string with get, set
    abstract v: string option with get, set
    abstract r: string option with get, set
    abstract s: string option with get, set

type [<AllowNullLiteral>] EventLog =
    abstract ``event``: string with get, set
    abstract address: string with get, set
    abstract returnValues: obj option with get, set
    abstract logIndex: float with get, set
    abstract transactionIndex: float with get, set
    abstract transactionHash: string with get, set
    abstract blockHash: string with get, set
    abstract blockNumber: float with get, set
    abstract raw: obj option with get, set

type [<AllowNullLiteral>] TransactionReceipt =
    abstract transactionHash: string with get, set
    abstract transactionIndex: float with get, set
    abstract blockHash: string with get, set
    abstract blockNumber: float with get, set
    abstract from: string with get, set
    abstract ``to``: string with get, set
    abstract contractAddress: string with get, set
    abstract cumulativeGasUsed: float with get, set
    abstract gasUsed: float with get, set
    abstract logs: Array<Log> option with get, set
    abstract events: obj option with get, set
    abstract status: string with get, set

type [<AllowNullLiteral>] EncodedTransaction =
    abstract raw: string with get, set
    abstract tx: obj with get, set

type [<AllowNullLiteral>] BlockHeader =
    abstract number: float with get, set
    abstract hash: string with get, set
    abstract parentHash: string with get, set
    abstract nonce: string with get, set
    abstract sha3Uncles: string with get, set
    abstract logsBloom: string with get, set
    abstract transactionRoot: string with get, set
    abstract stateRoot: string with get, set
    abstract receiptRoot: string with get, set
    abstract miner: string with get, set
    abstract extraData: string with get, set
    abstract gasLimit: float with get, set
    abstract gasUsed: float with get, set
    abstract timestamp: float with get, set

type [<AllowNullLiteral>] Block =
    inherit BlockHeader
    abstract transactions: Array<Transaction> with get, set
    abstract size: float with get, set
    abstract difficulty: float with get, set
    abstract totalDifficulty: float with get, set
    abstract uncles: Array<string> with get, set

type [<AllowNullLiteral>] Logs =
    abstract fromBlock: float option with get, set
    abstract address: string option with get, set
    abstract topics: Array<U2<string, ResizeArray<string>>> option with get, set

type [<AllowNullLiteral>] Log =
    abstract address: string with get, set
    abstract data: string with get, set
    abstract topics: Array<string> with get, set
    abstract logIndex: float with get, set
    abstract transactionHash: string with get, set
    abstract transactionIndex: float with get, set
    abstract blockHash: string with get, set
    abstract blockNumber: float with get, set

type [<AllowNullLiteral>] Subscribe<'T> =
    abstract subscription: obj with get, set
    [<Emit "$0.on('data',$1)">] abstract on_data: handler: ('T -> unit) -> unit
    [<Emit "$0.on('changed',$1)">] abstract on_changed: handler: ('T -> unit) -> unit
    [<Emit "$0.on('error',$1)">] abstract on_error: handler: (Error -> unit) -> unit

type [<AllowNullLiteral>] Account =
    abstract address: string with get, set
    abstract privateKey: string with get, set
    abstract publicKey: string with get, set

type [<AllowNullLiteral>] PrivateKey =
    abstract address: string with get, set
    abstract Crypto: obj with get, set
    abstract id: string with get, set
    abstract version: float with get, set

type [<AllowNullLiteral>] Signature =
    abstract message: string with get, set
    abstract hash: string with get, set
    abstract r: string with get, set
    abstract s: string with get, set
    abstract v: string with get, set

type [<AllowNullLiteral>] Tx = 
    abstract nonce: U2<string, float> option with get, set
    abstract chainId: U2<string, float> option with get, set
    abstract from: string option with get, set
    abstract ``to``: string option with get, set
    abstract data: string option with get, set
    abstract value: U2<string, BigNumber> option with get, set
    abstract gas: U2<string, float> option with get, set
    abstract gasPrice: U2<string, float> option with get, set

type [<AllowNullLiteral>] IProvider =
    abstract send: payload: JsonRPCRequest * callback: (Error -> JsonRPCResponse -> unit) -> Promise<obj option>

type [<AllowNullLiteral>] WebsocketProvider =
    inherit IProvider
    abstract responseCallbacks: obj with get, set
    abstract notificationCallbacks: (unit -> obj option) with get, set
    abstract connection: obj with get, set
    abstract addDefaultEvents: (unit -> unit) with get, set
    abstract on: ``type``: string * callback: (unit -> obj option) -> unit
    abstract removeListener: ``type``: string * callback: (unit -> obj option) -> unit
    abstract removeAllListeners: ``type``: string -> unit
    abstract reset: unit -> unit

type [<AllowNullLiteral>] HttpProvider =
    inherit IProvider
    abstract responseCallbacks: obj with get, set
    abstract notificationCallbacks: obj with get, set
    abstract connection: obj with get, set
    abstract addDefaultEvents: obj with get, set
    abstract on: ``type``: string * callback: (unit -> obj option) -> obj
    abstract removeListener: ``type``: string * callback: (unit -> obj option) -> obj
    abstract removeAllListeners: ``type``: string -> obj
    abstract reset: unit -> obj

type [<AllowNullLiteral>] IpcProvider =
    inherit IProvider
    abstract responseCallbacks: obj with get, set
    abstract notificationCallbacks: obj with get, set
    abstract connection: obj with get, set
    abstract addDefaultEvents: obj with get, set
    abstract on: ``type``: string * callback: (unit -> obj option) -> obj
    abstract removeListener: ``type``: string * callback: (unit -> obj option) -> obj
    abstract removeAllListeners: ``type``: string -> obj
    abstract reset: unit -> obj

type Provider =
    U3<WebsocketProvider, IpcProvider, HttpProvider>

[<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Provider =
    let ofWebsocketProvider v: Provider = v |> U3.Case1
    let isWebsocketProvider (v: Provider) = match v with U3.Case1 _ -> true | _ -> false
    let asWebsocketProvider (v: Provider) = match v with U3.Case1 o -> Some o | _ -> None
    let ofIpcProvider v: Provider = v |> U3.Case2
    let isIpcProvider (v: Provider) = match v with U3.Case2 _ -> true | _ -> false
    let asIpcProvider (v: Provider) = match v with U3.Case2 o -> Some o | _ -> None
    let ofHttpProvider v: Provider = v |> U3.Case3
    let isHttpProvider (v: Provider) = match v with U3.Case3 _ -> true | _ -> false
    let asHttpProvider (v: Provider) = match v with U3.Case3 o -> Some o | _ -> None

type [<StringEnum>] [<RequireQualifiedAccess>] Unit =
    | Kwei
    | Femtoether
    | Babbage
    | Mwei
    | Picoether
    | Lovelace
    | Qwei
    | Nanoether
    | Shannon
    | Microether
    | Szabo
    | Nano
    | Micro
    | Milliether
    | Finney
    | Milli
    | Ether
    | Kether
    | Grand
    | Mether
    | Gether
    | Tether

type BlockType =
    U4<string, string, string, float>

[<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module BlockType =
    let ofCase1 v: BlockType = v |> U4.Case1
    let isCase1 (v: BlockType) = match v with U4.Case1 _ -> true | _ -> false
    let asCase1 (v: BlockType) = match v with U4.Case1 o -> Some o | _ -> None
    let ofCase2 v: BlockType = v |> U4.Case2
    let isCase2 (v: BlockType) = match v with U4.Case2 _ -> true | _ -> false
    let asCase2 (v: BlockType) = match v with U4.Case2 o -> Some o | _ -> None
    let ofCase3 v: BlockType = v |> U4.Case3
    let isCase3 (v: BlockType) = match v with U4.Case3 _ -> true | _ -> false
    let asCase3 (v: BlockType) = match v with U4.Case3 o -> Some o | _ -> None
    let ofFloat v: BlockType = v |> U4.Case4
    let isFloat (v: BlockType) = match v with U4.Case4 _ -> true | _ -> false
    let asFloat (v: BlockType) = match v with U4.Case4 o -> Some o | _ -> None

type [<AllowNullLiteral>] Iban =
    interface end

type [<AllowNullLiteral>] Utils =
    abstract BN: BigNumber with get, set
    abstract isBN: any: obj option -> bool
    abstract isBigNumber: any: obj option -> bool
    abstract isAddress: any: obj option -> bool
    abstract isHex: any: obj option -> bool
    // abstract ``_``: Us.UnderscoreStatic with get, set
    abstract asciiToHex: ``val``: string -> string
    abstract hexToAscii: ``val``: string -> string
    abstract bytesToHex: ``val``: ResizeArray<float> -> string
    abstract numberToHex: ``val``: U2<float, BigNumber> -> string
    abstract checkAddressChecksum: address: string -> bool
    abstract fromAscii: ``val``: string -> string
    abstract fromDecimal: ``val``: U3<string, float, BigNumber> -> string
    abstract fromUtf8: ``val``: string -> string
    abstract fromWei: ``val``: U3<string, float, BigNumber> * unit: Unit -> U2<string, BigNumber>
    abstract hexToBytes: ``val``: string -> ResizeArray<float>
    abstract hexToNumber: ``val``: U3<string, float, BigNumber> -> float
    abstract hexToNumberString: ``val``: U3<string, float, BigNumber> -> string
    abstract hexToString: ``val``: string -> string
    abstract hexToUtf8: ``val``: string -> string
    abstract keccak256: ``val``: string -> string
    abstract leftPad: string: string * chars: float * sign: string -> string
    abstract padLeft: string: string * chars: float * sign: string -> string
    abstract rightPad: string: string * chars: float * sign: string -> string
    abstract padRight: string: string * chars: float * sign: string -> string
    abstract sha3: ``val``: string * ?val2: string * ?val3: string * ?val4: string * ?val5: string -> string
    abstract soliditySha3: ``val``: string -> string
    abstract randomHex: bytes: float -> string
    abstract stringToHex: ``val``: string -> string
    abstract toAscii: hex: string -> string
    abstract toBN: any: obj option -> BigNumber
    abstract toChecksumAddress: ``val``: string -> string
    abstract toDecimal: ``val``: obj option -> float
    abstract toHex: ``val``: obj option -> string
    abstract toUtf8: ``val``: obj option -> string
    abstract toWei: ``val``: U3<string, float, BigNumber> * unit: Unit -> U2<string, BigNumber>
    abstract unitMap: obj option with get, set

type [<AllowNullLiteral>] Contract =
    abstract options: obj with get, set
    abstract methods: obj with get, set
    abstract deploy: options: ContractDeployOptions -> TransactionObject<Contract>
    abstract events: obj with get, set
    abstract getPastEvents: ``event``: string * ?options: ContractGetPastEventsOptions * ?cb: Callback<ResizeArray<EventLog>> -> Promise<ResizeArray<EventLog>>
    abstract setProvider: provider: IProvider -> unit

type [<AllowNullLiteral>] ContractDeployOptions =
    abstract data: string with get, set
    abstract arguments: ResizeArray<obj option> with get, set

type [<AllowNullLiteral>] ContractGetPastEventsOptions =
    abstract filter: obj option with get, set
    abstract fromBlock: BlockType option with get, set
    abstract toBlock: BlockType option with get, set
    abstract topics: ResizeArray<string> option with get, set

type [<AllowNullLiteral>] Request =
    interface end

type [<AllowNullLiteral>] Providers =
    abstract WebsocketProvider: obj with get, set
    abstract HttpProvider: obj with get, set
    abstract IpcProvider: obj with get, set

type [<AllowNullLiteral>] EthAbiDecodeParametersType =
    abstract name: string with get, set
    abstract ``type``: string with get, set

type [<AllowNullLiteral>] EthAbiDecodeParametersResultArray =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: index: float -> obj option with get, set

type [<AllowNullLiteral>] EthAbiDecodeParametersResultObject =
    interface end

type [<AllowNullLiteral>] Eth =
    abstract defaultAccount: string with get, set
    abstract defaultBlock: BlockType with get, set
    abstract BatchRequest: obj with get, set
    abstract Iban: obj with get, set
    abstract Contract: obj with get, set
    abstract abi: obj with get, set
    abstract accounts: obj with get, set
    abstract call: callObject: Tx * ?defaultBloc: BlockType * ?callBack: Callback<string> -> Promise<string>
    abstract clearSubscriptions: unit -> bool
    [<Emit "$0.subscribe('logs',$1,$2)">] abstract subscribe_logs: ?options: Logs * ?callback: Callback<Subscribe<Log>> -> Promise<Subscribe<Log>>
    [<Emit "$0.subscribe('syncing',$1)">] abstract subscribe_syncing: ?callback: Callback<Subscribe<obj option>> -> Promise<Subscribe<obj option>>
    [<Emit "$0.subscribe('newBlockHeaders',$1)">] abstract subscribe_newBlockHeaders: ?callback: Callback<Subscribe<BlockHeader>> -> Promise<Subscribe<BlockHeader>>
    [<Emit "$0.subscribe('pendingTransactions',$1)">] abstract subscribe_pendingTransactions: ?callback: Callback<Subscribe<Transaction>> -> Promise<Subscribe<Transaction>>
    abstract subscribe: ``type``: U4<string, string, string, string> * ?options: Logs * ?callback: Callback<Subscribe<U3<Transaction, BlockHeader, obj option>>> -> Promise<Subscribe<U3<Transaction, BlockHeader, obj option>>>
    abstract unsubscribe: callBack: Callback<bool> -> U2<unit, bool>
    abstract compile: obj with get, set
    abstract currentProvider: Provider with get, set
    abstract estimateGas: tx: Tx * ?callback: Callback<float> -> Promise<float>
    abstract getAccounts: ?cb: Callback<Array<string>> -> Promise<Array<string>>
    abstract getBalance: address: string * ?defaultBlock: BlockType * ?cb: Callback<float> -> Promise<float>
    abstract getBlock: number: BlockType * ?returnTransactionObjects: bool * ?cb: Callback<Block> -> Promise<Block>
    abstract getBlockNumber: ?callback: Callback<float> -> Promise<float>
    abstract getBlockTransactionCount: number: U2<BlockType, string> * ?cb: Callback<float> -> Promise<float>
    abstract getBlockUncleCount: number: U2<BlockType, string> * ?cb: Callback<float> -> Promise<float>
    abstract getCode: address: string * ?defaultBlock: BlockType * ?cb: Callback<string> -> Promise<string>
    abstract getCoinbase: ?cb: Callback<string> -> Promise<string>
    abstract getCompilers: ?cb: Callback<ResizeArray<string>> -> Promise<ResizeArray<string>>
    abstract getGasPrice: ?cb: Callback<float> -> Promise<float>
    abstract getHashrate: ?cb: Callback<float> -> Promise<float>
    abstract getPastLogs: options: EthGetPastLogsOptions * ?cb: Callback<Array<Log>> -> Promise<Array<Log>>
    abstract getProtocolVersion: ?cb: Callback<string> -> Promise<string>
    abstract getStorageAt: address: string * ?defaultBlock: BlockType * ?cb: Callback<string> -> Promise<string>
    abstract getTransactionReceipt: hash: string * ?cb: Callback<TransactionReceipt> -> Promise<TransactionReceipt>
    abstract getTransaction: hash: string * ?cb: Callback<Transaction> -> Promise<Transaction>
    abstract getTransactionCount: address: string * ?defaultBlock: BlockType * ?cb: Callback<float> -> Promise<float>
    abstract getTransactionFromBlock: block: BlockType * index: float * ?cb: Callback<Transaction> -> Promise<Transaction>
    abstract getUncle: blockHashOrBlockNumber: U2<BlockType, string> * uncleIndex: float * ?returnTransactionObjects: bool * ?cb: Callback<Block> -> Promise<Block>
    abstract getWork: ?cb: Callback<Array<string>> -> Promise<Array<string>>
    abstract givenProvider: Provider with get, set
    abstract isMining: ?cb: Callback<bool> -> Promise<bool>
    abstract isSyncing: ?cb: Callback<bool> -> Promise<bool>
    abstract net: Net with get, set
    abstract personal: Personal with get, set
    abstract signTransaction: tx: Tx * ?address: string * ?cb: Callback<string> -> Promise<EncodedTransaction>
    abstract sendSignedTransaction: data: string * ?cb: Callback<string> -> PromiEvent<TransactionReceipt>
    abstract sendTransaction: tx: Tx * ?cb: Callback<string> -> PromiEvent<TransactionReceipt>
    abstract submitWork: nonce: string * powHash: string * digest: string * ?cb: Callback<bool> -> Promise<bool>
    abstract sign: address: string * dataToSign: string * ?cb: Callback<string> -> Promise<string>

type [<AllowNullLiteral>] EthGetPastLogsOptions =
    abstract fromBlock: BlockType option with get, set
    abstract toBlock: BlockType option with get, set
    abstract address: string with get, set
    abstract topics: Array<U2<string, Array<string>>> option with get, set

type [<AllowNullLiteral>] EthStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Eth

type [<AllowNullLiteral>] Net =
    abstract getId: ?cb: Callback<float> -> Promise<float>
    abstract isListening: ?cb: Callback<bool> -> Promise<bool>
    abstract getPeerCount: ?cb: Callback<float> -> Promise<float>

type [<AllowNullLiteral>] NetStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Net

type [<AllowNullLiteral>] Personal =
    abstract newAccount: password: string * ?cb: Callback<bool> -> Promise<string>
    abstract importRawKey: unit -> Promise<string>
    abstract lockAccount: unit -> Promise<bool>
    abstract unlockAccount: unit -> unit
    abstract sign: unit -> Promise<string>
    abstract ecRecover: message: string * ``sig``: string -> unit
    abstract sendTransaction: tx: Tx * passphrase: string -> Promise<string>

type [<AllowNullLiteral>] PersonalStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Personal

type [<AllowNullLiteral>] Shh =
    interface end

type [<AllowNullLiteral>] ShhStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Shh

type [<AllowNullLiteral>] Bzz =
    interface end

type [<AllowNullLiteral>] BzzStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Bzz

type [<AllowNullLiteral>] BatchRequest =
    abstract add: request: Request -> unit
    abstract execute: unit -> unit

type [<AllowNullLiteral>] BatchRequestStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> BatchRequest
