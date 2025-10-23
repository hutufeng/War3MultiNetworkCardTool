# War3NetHelper 技术说明文档

## 1. 概述

### 1.1. 项目目标
开发一个C#桌面工具，解决《魔兽争霸III》在多网卡环境下的局域网联机问题。工具提供两种核心模式：修改系统路由表和使用ForceBindIP进行注入。同时，它也作为一个方便的游戏启动器。

### 1.2. 技术栈
- **语言**: C#
- **框架**: .NET 6+ & Windows Forms (WinForms)
- **环境**: Windows

### 1.3. 最终交付物
一个独立的、无需安装的绿色 `.exe` 文件。

---

## 2. 核心功能实现

### 2.1. 网络适配器检测
- **核心API**: `System.Net.NetworkInformation.NetworkInterface`
- **实现细节**:
  1. 程序启动时，调用 `NetworkInterface.GetAllNetworkInterfaces()`。
  2. 筛选出状态为 `OperationalStatus.Up` 且支持 IPv4 的网络适配器。
  3. 提取每个适配器的描述性名称 (`Description`) 和 IPv4 地址 (`GetIPProperties().UnicastAddresses`)。
  4. 将适配器信息（名称+IP地址）加载到UI下拉框中供用户选择。

### 2.2. 路由表模式
- **核心工具**: Windows 系统自带的 `route.exe`。
- **C#交互**: 使用 `System.Diagnostics.Process` 类来启动和控制 `route.exe` 进程。
- **权限管理**:
  - 执行路由修改时，设置 `ProcessStartInfo.Verb = "runas"`，以请求管理员权限（UAC弹窗）。
- **添加路由**:
  - 执行命令: `route add <目标网段> MASK <子网掩码> <网关IP> METRIC 5`。
  - 程序会根据用户选择的网卡IP自动计算出目标网段和子网掩码。
- **状态管理**:
  - 程序在内存中记录下当前应用的路由规则（如目标网段 `192.168.1.0`），以便后续精确删除。
- **恢复路由**:
  - 执行命令: `route delete <目标网段>`。
  - 触发时机:
    1. 用户点击“手动还原”按钮。
    2. 用户关闭主窗口时，在 `Form.FormClosing` 事件中自动触发。

### 2.3. ForceBindIP 模式
- **核心工具**: `ForceBindIP.exe` (v1.32)。
- **集成方式**:
  1. 将 `ForceBindIP.exe` 文件作为资源添加到 `.csproj` 项目文件中。
  2. 设置其属性为 `CopyToOutputDirectory = "CopyIfNewer"`，确保编译后 `ForceBindIP.exe` 会自动出现在主程序旁边。
- **C#交互**: 同样使用 `System.Diagnostics.Process` 类。
- **执行命令**: `ForceBindIP.exe <用户选择的IP地址> "<War3游戏路径>"`。

### 2.4. 配置持久化
- **核心API**: `Properties.Settings.Default` (C#/.NET 标准设置功能)。
- **存储内容**:
  - 用户最后选择的网络适配器的唯一ID (`NetworkInterface.Id`)。
  - 用户最后设置的War3游戏可执行文件路径。
- **实现细节**:
  - **保存**: 在 `Form.FormClosing` 事件中，将当前的选择保存到用户配置文件。
  - **加载**: 在 `Form.Load` 事件中，读取配置并尝试在UI上恢复之前的选择。

---

## 3. UI/UX 设计
- **主窗口**: `System.Windows.Forms.Form`。
- **选项卡**: 使用 `System.Windows.Forms.TabControl` 控件，包含两个 `TabPage`。
  - **默认Tab**: “ForceBindIP模式”将作为默认选中的选项卡。
- **通用控件**:
  - `ComboBox`: 用于选择网络适配器。
  - `TextBox` + `Button`: 用于浏览和设置游戏路径。
  - `Button`: 用于执行核心操作（应用路由、启动游戏等）。
  - `RichTextBox`: 用于显示路由表查询结果。
- **统一启动器**: 两个选项卡下都包含完整的游戏路径设置和“启动游戏”按钮。

---

## 4. 打包与部署
- **方法**: 使用 `dotnet` 命令行工具的 `publish` 功能。
- **命令示例**:
  ```shell
  dotnet publish -r win-x64 -c Release --self-contained true -p:PublishSingleFile=true
  ```
- **最终成果**: 在 `publish` 目录下生成一个独立的 `.exe` 文件，包含了.NET运行时、所有依赖库以及 `ForceBindIP.exe` 资源。
