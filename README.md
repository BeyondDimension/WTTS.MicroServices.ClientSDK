# WTTS.MicroServices.ClientSDK
Watt Toolkit Micro Service Client SDK

### [🏗️ 项目结构](./doc/Project-Structure.md)

### [序列化与反序列化](https://github.com/BeyondDimension/Common/blob/main/doc/Serializable-And-Deserialize.md)

### [压缩与打包(归档)](https://github.com/BeyondDimension/Common/blob/main/doc/Compression-And-Packaging.md)

### Native AOT serialization contracts

`ApiJsonSerializerContext` supplies source-generated metadata for the SDK's request models, API response envelopes, and shop responses. New SDK endpoints must add their closed request/response types to this context. Nested DTO members are generated automatically; whole-assembly reflection roots are not required.

`ApiRspHelper.JsonPackDeserializeAsync` reads the existing UTF-8 JSON envelope (including its emoji property names), not a binary packing format. MessagePack and MemoryPack remain separate response paths. Shop responses retain case-insensitive property matching and shop requests retain the standard web JSON naming policy. JIT builds retain reflection-based metadata for custom external-plugin models.

Native builds also initialize `ApiMemoryPackFormatters` with the closed official API envelopes, request models, response contents and collection formatters. Add new binary contracts there when extending the SDK. Response decoding uses typed generated readers; content-free error envelopes are read from the original stream without a second attempt on a consumed HTTP or decryption stream.
