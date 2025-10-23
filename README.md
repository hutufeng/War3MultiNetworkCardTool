# War3NetHelper

一个为《魔兽争霸III》局域网联机设计的网络辅助工具，旨在解决多网卡环境下（例如，同时有有线网卡和无线网卡）创建游戏时，其他玩家无法看到主机的问题。

## 软件截图 (Screenshot)

*[在此处添加您的软件截图]*

---

## ✨ 功能特性 (Features)

- **双核模式**：内置两种不同的解决方案，以应对复杂的网络环境。
  - **ForceBindIP 模式 (推荐)**: 通过注入技术，将游戏进程精确绑定到您选择的网卡上，对系统无任何更改。
  - **路由表模式**: 通过修改 Windows 系统路由表，为局域网添加高优先级路由，强制数据通过指定网卡。

- **智能与健壮**:
  - **GUID 绑定**: ForceBindIP模式默认使用网卡的固定GUID进行绑定，而非变动的IP地址，更加稳定可靠。
  - **自动清理**: 路由表模式下，添加的路由规则会在程序关闭时自动删除，保证系统纯净。
  - **兼容性选项**: ForceBindIP模式提供“延迟注入”(`-i`参数)选项，以提高对某些系统的兼容性。
  - **高级定制**: 路由表模式支持自定义“跃点数”(Metric)，满足专业用户的需求。

- **优秀的用户体验**:
  - **便携化配置**: 所有设置（游戏路径、上次选择的网卡等）均保存在程序目录下的 `settings.json` 文件中，是纯粹的“绿色软件”。
  - **记忆功能**: 自动记忆您上次的选择，省去重复操作。
  - **高亮显示**: 在路由表模式下，成功添加的路由规则会以**黄色粗体**高亮显示，一目了然。
  - **集成启动器**: 在任一模式下配置完成后，都可直接点击“启动游戏”按钮进入游戏。

---

## 🚀 下载与安装 (Download & Installation)

您可以从本仓库的 `Releases` 页面选择以下两种版本之一进行下载：

1.  **`War3NetHelper-SelfContained.zip` (开箱即用版 - 推荐)**
    -   **优点**: 无需任何前置条件，下载解压后可直接在任何 Windows 电脑上运行。
    -   **缺点**: 体积较大 (压缩后约 40MB+)。
    -   **建议**: 如果您不确定该选哪个，或者希望分发给朋友时对方能直接使用，请选择此版本。

2.  **`War3NetHelper-FrameworkDependent.zip` (极致精简版)**
    -   **优点**: 体积非常小 (压缩后约 1-2MB)。
    -   **缺点**: 运行前，电脑必须已安装 **[.NET 8.0 Desktop Runtime](https://dotnet.microsoft.com/zh-cn/download/dotnet/8.0/runtime)**。
    -   **建议**: 如果您的电脑已经有.NET 8环境，或者您是进阶用户且不介意安装运行库，可以选择此版本。

---

## 🚀 如何使用 (How to Use)

1.  从 GitHub 的 `Releases` 页面下载最新的压缩包。
2.  解压到任意文件夹。
3.  右键点击 `War3NetHelper.exe`，选择“**以管理员身份运行**”。（因为两种模式都需要管理员权限）

### ForceBindIP 模式 (推荐)

这是最推荐的模式，因为它精准、无污染。

1.  在“选择网卡”下拉框中，选择您要用于局域网联机的那个网卡。
2.  点击“浏览...”按钮，选择您的《魔兽争霸III》游戏程序 (通常是 `war3.exe` 或 `Frozen Throne.exe`)。
3.  (可选) 如果直接启动失败，可以勾选“延迟注入”复选框再试一次。
4.  点击硕大的 **“使用 ForceBindIP 启动游戏”** 按钮。

### 路由表模式

当ForceBindIP模式因某些原因（如杀毒软件拦截）无效时，可以使用此模式。

1.  切换到“路由表模式”选项卡。
2.  选择正确的网卡。
3.  (可选) 调整“跃点数”。数字越小，优先级越高。默认值 `5` 已是极高优先级，通常无需修改。
4.  点击 **“1. 应用路由”**。成功后会弹出提示，并且下方的路由表会刷新，将新添加的规则高亮显示。
5.  点击 **“2. 启动游戏”**。
6.  游戏结束后，可以直接关闭本工具，程序会自动为您还原路由表。如果需要，也可以点击“手动还原路由”按钮。

---

## 🛠️ 从源码编译 (Building from Source)

1.  确保您已安装 [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)。
2.  克隆本仓库。
3.  在项目根目录打开终端，执行 `dotnet build`。
4.  要发布为“绿色软件”文件夹，请执行：
    ```shell
    dotnet publish -c Release -r win-x64 --self-contained true
    ```
    发布的文件将位于 `bin/Release/net8.0-windows/win-x64/publish/` 目录下。

---

## 捆绑的第三方工具 (Bundled Third-Party Tools)

本程序的核心功能依赖于 `ForceBindIP`，因此在发布时已将其捆绑打包。

- **工具**: ForceBindIP
- **版本**: 1.32
- **作者**: r1ch
- **项目主页**: [https://r1ch.net/projects/forcebindip](https://r1ch.net/projects/forcebindip)
- **包含文件**: `ForceBindIP.exe`, `BindIP.dll`

---

## 🙏 致谢 (Acknowledgements)

- 本工具的核心功能之一，ForceBindIP模式，是基于 [r1ch.net 的 ForceBindIP](https://r1ch.net/projects/forcebindip) 工具实现的。感谢其作者的卓越工作。
