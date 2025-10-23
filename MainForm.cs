using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.IO;
using System.Text.Json;
using System.Drawing;

namespace War3NetHelper;

public partial class MainForm : Form
{
    private const string SettingsFileName = "settings.json";

    private class AdapterInfo
    {
        public string? DisplayName { get; set; }
        public NetworkInterface? Adapter { get; set; }
        public override string ToString() => DisplayName ?? "";
    }

    private class PortableSettings
    {
        public string? GamePath { get; set; }
        public string? LastAdapterId { get; set; }
        public bool IsDelayChecked { get; set; }
        public decimal RouteMetric { get; set; }
    }

    private string? _appliedRouteSubnet = null;

    public MainForm()
    {
        InitializeComponent();
        this.Load += new System.EventHandler(this.MainForm_Load);
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);

        this.btnBrowseF.Click += new System.EventHandler(this.btnBrowse_Click);
        this.btnLaunchF.Click += new System.EventHandler(this.btnLaunchF_Click);
        this.btnBrowseR.Click += new System.EventHandler(this.btnBrowse_Click);
        this.btnApplyRoute.Click += new System.EventHandler(this.btnApplyRoute_Click);
        this.btnRestoreRoute.Click += new System.EventHandler(this.btnRestoreRoute_Click);
        this.btnViewRoutes.Click += new System.EventHandler(this.btnViewRoutes_Click);
        this.btnLaunchR.Click += new System.EventHandler(this.btnLaunchR_Click);
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        LoadNetworkAdapters();
        LoadSettings();
    }

    private void LoadSettings()
    {
        try
        {
            var settingsPath = Path.Combine(Application.StartupPath, SettingsFileName);
            if (!File.Exists(settingsPath)) return;

            var json = File.ReadAllText(settingsPath);
            var settings = JsonSerializer.Deserialize<PortableSettings>(json);

            if (settings == null) return;

            if (!string.IsNullOrEmpty(settings.GamePath) && File.Exists(settings.GamePath))
            {
                txtGamePathF.Text = settings.GamePath;
                txtGamePathR.Text = settings.GamePath;
            }

            if (!string.IsNullOrEmpty(settings.LastAdapterId))
            {
                var itemToSelect = comboAdaptersF.Items.OfType<AdapterInfo>().FirstOrDefault(item => item.Adapter?.Id == settings.LastAdapterId);
                if (itemToSelect != null)
                {
                    comboAdaptersF.SelectedItem = itemToSelect;
                    comboAdaptersR.SelectedItem = itemToSelect;
                }
            }

            chkForceBindIpDelay.Checked = settings.IsDelayChecked;
            if (settings.RouteMetric >= numMetric.Minimum && settings.RouteMetric <= numMetric.Maximum)
            {
                numMetric.Value = settings.RouteMetric;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"加载配置文件 (settings.json) 时出错:\n{ex.Message}", "加载错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SaveSettings()
    {
        try
        {
            var settings = new PortableSettings
            {
                GamePath = txtGamePathF.Text,
                IsDelayChecked = chkForceBindIpDelay.Checked,
                RouteMetric = numMetric.Value
            };

            if (comboAdaptersF.SelectedItem is AdapterInfo selectedAdapter)
            {
                settings.LastAdapterId = selectedAdapter.Adapter?.Id ?? "";
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(settings, options);
            var settingsPath = Path.Combine(Application.StartupPath, SettingsFileName);
            File.WriteAllText(settingsPath, json);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"保存配置文件 (settings.json) 时出错:\n{ex.Message}", "保存错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadNetworkAdapters()
    {
        var adapters = NetworkInterface.GetAllNetworkInterfaces()
            .Where(a => a.OperationalStatus == OperationalStatus.Up)
            .Where(a => a.GetIPProperties().UnicastAddresses.Any(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork))
            .Select(a => {
                var ipProps = a.GetIPProperties();
                var ipv4 = ipProps.UnicastAddresses.FirstOrDefault(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork);
                return new AdapterInfo
                {
                    Adapter = a,
                    DisplayName = $"{a.Description} ({ipv4?.Address})"
                };
            })
            .ToList();

        comboAdaptersF.DataSource = adapters.ToList(); 
        comboAdaptersF.DisplayMember = "DisplayName";

        comboAdaptersR.DataSource = adapters.ToList();
        comboAdaptersR.DisplayMember = "DisplayName";
    }

    private void btnBrowse_Click(object? sender, EventArgs e)
    {
        using (var ofd = new OpenFileDialog())
        {
            ofd.Title = "请选择《魔兽争霸III》的可执行文件";
            ofd.Filter = "War3 Executable|war3.exe;Frozen Throne.exe|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtGamePathF.Text = ofd.FileName;
                txtGamePathR.Text = ofd.FileName;
            }
        }
    }

    private void btnLaunchF_Click(object? sender, EventArgs e)
    {
        if (comboAdaptersF.SelectedItem is not AdapterInfo selectedAdapter || selectedAdapter.Adapter == null)
        {
            MessageBox.Show("请先从下拉列表中选择一个网络适配器。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var gamePath = txtGamePathF.Text;
        if (string.IsNullOrEmpty(gamePath) || !File.Exists(gamePath))
        {
            MessageBox.Show("游戏路径无效或未设置，请通过“浏览”按钮选择正确的 war3.exe 或 Frozen Throne.exe。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var forceBindIpPath = Path.Combine(Application.StartupPath, "forcebindip", "ForceBindIP.exe");
        if (!File.Exists(forceBindIpPath))
        {
            MessageBox.Show($"核心文件 ForceBindIP.exe 未找到，请确保它位于以下路径：\n{forceBindIpPath}", "致命错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            var identifier = selectedAdapter.Adapter.Id;

            string arguments = $"{identifier} \"{gamePath}\"";
            if (chkForceBindIpDelay.Checked)
            {
                arguments = $"-i {arguments}";
            }

            Process.Start(forceBindIpPath, arguments);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"启动游戏时发生错误：\n{ex.Message}", "启动失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnApplyRoute_Click(object? sender, EventArgs e)
    {
        if (_appliedRouteSubnet != null)
        {
            MessageBox.Show($"已有路由规则(针对 {_appliedRouteSubnet} 网段)正在生效中。\n请先点击“手动还原路由”，然后再应用新规则。", "操作被阻止", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (comboAdaptersR.SelectedItem is not AdapterInfo selectedAdapter || selectedAdapter.Adapter == null)
        {
            MessageBox.Show("请先从下拉列表中选择一个网络适配器。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var ipv4Info = selectedAdapter.Adapter.GetIPProperties().UnicastAddresses
            .FirstOrDefault(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork);

        if (ipv4Info == null)
        {
            MessageBox.Show("无法获取所选网络适配器的有效IPv4地址信息。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var ipAddress = ipv4Info.Address;
        var subnetMask = ipv4Info.IPv4Mask;
        var networkAddress = GetNetworkAddress(ipAddress, subnetMask);
        var subnetString = networkAddress.ToString();
        var metric = numMetric.Value;

        string command = $"route add {subnetString} mask {subnetMask} {ipAddress} metric {metric}";
        string output = RunCommand(command);

        if (output.Contains("The object already exists.") || output.Contains("对象已存在") || output.Contains("操作完成") || string.IsNullOrEmpty(output.Trim()))
        {
            _appliedRouteSubnet = subnetString;
            MessageBox.Show($"成功为网段 {subnetString} 应用路由规则！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshRouteView(subnetString);
        }
        else
        {
            MessageBox.Show($"应用路由失败。\n\n命令输出:\n{output}", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private System.Net.IPAddress GetNetworkAddress(System.Net.IPAddress address, System.Net.IPAddress subnetMask)
    {
        byte[] ipAdressBytes = address.GetAddressBytes();
        byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

        if (ipAdressBytes.Length != subnetMaskBytes.Length)
            throw new ArgumentException("Lengths of IP address and subnet mask do not match.");

        byte[] broadcastAddress = new byte[ipAdressBytes.Length];
        for (int i = 0; i < broadcastAddress.Length; i++)
        {
            broadcastAddress[i] = (byte)(ipAdressBytes[i] & (subnetMaskBytes[i]));
        }
        return new System.Net.IPAddress(broadcastAddress);
    }

    private void btnRestoreRoute_Click(object? sender, EventArgs e)
    {
        RestoreRoute(true);
    }

    private void RestoreRoute(bool showMessage)
    {
        if (_appliedRouteSubnet == null)
        {
            if (showMessage)
            {
                MessageBox.Show("当前没有已应用的路由规则。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return;
        }

        string command = $"route delete {_appliedRouteSubnet}";
        string output = RunCommand(command);

        if (output.Contains("操作完成") || string.IsNullOrEmpty(output.Trim()) || output.Contains("not found"))
        {
            if (showMessage)
            {
                MessageBox.Show($"已成功还原网段 {_appliedRouteSubnet} 的路由规则！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            _appliedRouteSubnet = null;
            RefreshRouteView();
        }
        else
        {
            if (showMessage)
            {
                MessageBox.Show($"还原路由失败。\n\n命令输出:\n{output}", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnViewRoutes_Click(object? sender, EventArgs e)
    {
        RefreshRouteView();
    }

    private void RefreshRouteView(string? stringToHighlight = null)
    {
        txtRouteInfo.Text = "正在获取路由表信息...";
        Application.DoEvents();
        var output = RunCommand("route print");
        txtRouteInfo.Text = output;

        if (!string.IsNullOrEmpty(stringToHighlight))
        {
            string[] lines = txtRouteInfo.Lines;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Trim().StartsWith(stringToHighlight))
                {
                    int lineStartIndex = txtRouteInfo.GetFirstCharIndexFromLine(i);
                    int lineLength = lines[i].Length;
                    if (lineStartIndex >= 0 && lineLength > 0)
                    {
                        txtRouteInfo.Select(lineStartIndex, lineLength);
                        txtRouteInfo.SelectionColor = Color.Yellow;
                        txtRouteInfo.SelectionFont = new Font(txtRouteInfo.Font, FontStyle.Bold);
                        txtRouteInfo.ScrollToCaret();
                    }
                    break;
                }
            }
        }
    }

    private string RunCommand(string command)
    {
        try
        {
            var psi = new ProcessStartInfo("cmd.exe", $"/c {command}")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(psi))
            {
                if (process == null) return "无法启动进程。";
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();
                return string.IsNullOrEmpty(error) ? output : error;
            }
        }
        catch (Exception ex)
        {
            return $"执行命令时出错: \n{ex.Message}";
        }
    }

    private void btnLaunchR_Click(object? sender, EventArgs e)
    {
        var gamePath = txtGamePathR.Text;
        if (string.IsNullOrEmpty(gamePath) || !File.Exists(gamePath))
        {
            MessageBox.Show("游戏路径无效或未设置，请通过“浏览”按钮选择正确的 war3.exe 或 Frozen Throne.exe。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            Process.Start(gamePath);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"启动游戏时发生错误：\n{ex.Message}", "启动失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        SaveSettings();
        RestoreRoute(false);
    }
}

