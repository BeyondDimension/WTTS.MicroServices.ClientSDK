### 🏗️ 项目结构
- Root **项目根文件夹**
    - ImplicitUsings
        - ImplicitUsings.*.cs **全局命名空间引用**
    - TFM
        - TFM_NETX.props **.NET 7 目标框架**
    - .editorconfig **代码样式配置**
    - .gitignore **Git 忽略扩展名与路径配置**
    - Directory.Build.props **csproj 全局项目共享配置**
    - Directory.Packages.props **Nuget 中央包管理**
    - NuGet.Config **Nuget 包源配置**
- Shared **全局共享代码模块**
    - BD.WTTS.Primitives **基本库**
        - Columns **列，字段接口**
        - Enums **值枚举**
        - Extensions **扩展函数**
    - BD.WTTS.Primitives.Models **模型库**
        - Models **模型类**
    - BD.WTTS.Primitives.Models.Compat **兼容客户端 V2 版本的模型库**
    - BD.WTTS.Primitives.ViewModels **视图模型库**
    - BD.WTTS.Primitives.ViewModels.Compat **兼容客户端 V2 版本的视图模型库**
    - BD.WTTS.Primitives.Resources **字符串多语言资源库**
- MicroServices **微服务服务端**
    - Primitives **基本库相关**
        - BD.WTTS.MicroServices.Primitives **微服务共享基本库**
        -   D.WTTS.MicroServices.Primitives.Models **微服务共享模型库**
        -   D.WTTS.MicroServices.Primitives.ViewModels **微服务共享视图模型库**
        -   D.WTTS.MicroServices.Primitives.Resources **微服务共享基本库资源库，客户端 SDK 与服务端共用**
    - SDK **微服务客户端调用 SDK**
        - BD.WTTS.MicroServices.ClientSDK **客户端调用 SDK**
        - BD.WTTS.MicroServices.ClientSDK.Compat **客户端调用 SDK，V2 版本接口调用**

### ⚠ 注意事项
1. ```ServiceCollectionExtensions.*.cs``` **DI 注册服务扩展类，命名空间统一使用**  
<pre>
// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
</pre>