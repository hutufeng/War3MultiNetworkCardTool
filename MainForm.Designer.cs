namespace War3NetHelper
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabForceBindIP = new System.Windows.Forms.TabPage();
            this.chkForceBindIpDelay = new System.Windows.Forms.CheckBox();
            this.lblAdapterF = new System.Windows.Forms.Label();
            this.comboAdaptersF = new System.Windows.Forms.ComboBox();
            this.btnLaunchF = new System.Windows.Forms.Button();
            this.btnBrowseF = new System.Windows.Forms.Button();
            this.txtGamePathF = new System.Windows.Forms.TextBox();
            this.lblGamePathF = new System.Windows.Forms.Label();
            this.tabRoute = new System.Windows.Forms.TabPage();
            this.numMetric = new System.Windows.Forms.NumericUpDown();
            this.lblMetric = new System.Windows.Forms.Label();
            this.lblAdapterR = new System.Windows.Forms.Label();
            this.comboAdaptersR = new System.Windows.Forms.ComboBox();
            this.btnLaunchR = new System.Windows.Forms.Button();
            this.btnBrowseR = new System.Windows.Forms.Button();
            this.txtGamePathR = new System.Windows.Forms.TextBox();
            this.lblGamePathR = new System.Windows.Forms.Label();
            this.btnApplyRoute = new System.Windows.Forms.Button();
            this.btnRestoreRoute = new System.Windows.Forms.Button();
            this.btnViewRoutes = new System.Windows.Forms.Button();
            this.txtRouteInfo = new System.Windows.Forms.RichTextBox();
            this.tabControl.SuspendLayout();
            this.tabForceBindIP.SuspendLayout();
            this.tabRoute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMetric)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabForceBindIP);
            this.tabControl.Controls.Add(this.tabRoute);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(584, 461);
            this.tabControl.TabIndex = 0;
            // 
            // tabForceBindIP
            // 
            this.tabForceBindIP.Controls.Add(this.chkForceBindIpDelay);
            this.tabForceBindIP.Controls.Add(this.lblAdapterF);
            this.tabForceBindIP.Controls.Add(this.comboAdaptersF);
            this.tabForceBindIP.Controls.Add(this.btnLaunchF);
            this.tabForceBindIP.Controls.Add(this.btnBrowseF);
            this.tabForceBindIP.Controls.Add(this.txtGamePathF);
            this.tabForceBindIP.Controls.Add(this.lblGamePathF);
            this.tabForceBindIP.Location = new System.Drawing.Point(4, 24);
            this.tabForceBindIP.Name = "tabForceBindIP";
            this.tabForceBindIP.Padding = new System.Windows.Forms.Padding(3);
            this.tabForceBindIP.Size = new System.Drawing.Size(576, 433);
            this.tabForceBindIP.TabIndex = 0;
            this.tabForceBindIP.Text = "ForceBindIP 模式";
            this.tabForceBindIP.UseVisualStyleBackColor = true;
            // 
            // chkForceBindIpDelay
            // 
            this.chkForceBindIpDelay.AutoSize = true;
            this.chkForceBindIpDelay.Location = new System.Drawing.Point(23, 135);
            this.chkForceBindIpDelay.Name = "chkForceBindIpDelay";
            this.chkForceBindIpDelay.Size = new System.Drawing.Size(195, 19);
            this.chkForceBindIpDelay.TabIndex = 5;
            this.chkForceBindIpDelay.Text = "延迟注入(增强兼容性, -i 参数)";
            this.chkForceBindIpDelay.UseVisualStyleBackColor = true;
            // 
            // lblAdapterF
            // 
            this.lblAdapterF.AutoSize = true;
            this.lblAdapterF.Location = new System.Drawing.Point(20, 23);
            this.lblAdapterF.Name = "lblAdapterF";
            this.lblAdapterF.Size = new System.Drawing.Size(56, 15);
            this.lblAdapterF.TabIndex = 0;
            this.lblAdapterF.Text = "选择网卡:";
            // 
            // comboAdaptersF
            // 
            this.comboAdaptersF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAdaptersF.FormattingEnabled = true;
            this.comboAdaptersF.Location = new System.Drawing.Point(23, 41);
            this.comboAdaptersF.Name = "comboAdaptersF";
            this.comboAdaptersF.Size = new System.Drawing.Size(530, 23);
            this.comboAdaptersF.TabIndex = 1;
            // 
            // btnLaunchF
            // 
            this.btnLaunchF.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLaunchF.Location = new System.Drawing.Point(23, 170);
            this.btnLaunchF.Name = "btnLaunchF";
            this.btnLaunchF.Size = new System.Drawing.Size(531, 50);
            this.btnLaunchF.TabIndex = 4;
            this.btnLaunchF.Text = "使用 ForceBindIP 启动游戏";
            this.btnLaunchF.UseVisualStyleBackColor = true;
            // 
            // btnBrowseF
            // 
            this.btnBrowseF.Location = new System.Drawing.Point(479, 97);
            this.btnBrowseF.Name = "btnBrowseF";
            this.btnBrowseF.Size = new System.Drawing.Size(75, 25);
            this.btnBrowseF.TabIndex = 3;
            this.btnBrowseF.Text = "浏览...";
            this.btnBrowseF.UseVisualStyleBackColor = true;
            // 
            // txtGamePathF
            // 
            this.txtGamePathF.Location = new System.Drawing.Point(23, 98);
            this.txtGamePathF.Name = "txtGamePathF";
            this.txtGamePathF.Size = new System.Drawing.Size(450, 23);
            this.txtGamePathF.TabIndex = 2;
            // 
            // lblGamePathF
            // 
            this.lblGamePathF.AutoSize = true;
            this.lblGamePathF.Location = new System.Drawing.Point(20, 80);
            this.lblGamePathF.Name = "lblGamePathF";
            this.lblGamePathF.Size = new System.Drawing.Size(83, 15);
            this.lblGamePathF.TabIndex = 0;
            this.lblGamePathF.Text = "War3 游戏路径:";
            // 
            // tabRoute
            // 
            this.tabRoute.Controls.Add(this.numMetric);
            this.tabRoute.Controls.Add(this.lblMetric);
            this.tabRoute.Controls.Add(this.lblAdapterR);
            this.tabRoute.Controls.Add(this.comboAdaptersR);
            this.tabRoute.Controls.Add(this.btnLaunchR);
            this.tabRoute.Controls.Add(this.btnBrowseR);
            this.tabRoute.Controls.Add(this.txtGamePathR);
            this.tabRoute.Controls.Add(this.lblGamePathR);
            this.tabRoute.Controls.Add(this.btnApplyRoute);
            this.tabRoute.Controls.Add(this.btnRestoreRoute);
            this.tabRoute.Controls.Add(this.btnViewRoutes);
            this.tabRoute.Controls.Add(this.txtRouteInfo);
            this.tabRoute.Location = new System.Drawing.Point(4, 24);
            this.tabRoute.Name = "tabRoute";
            this.tabRoute.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoute.Size = new System.Drawing.Size(576, 433);
            this.tabRoute.TabIndex = 1;
            this.tabRoute.Text = "路由表模式";
            this.tabRoute.UseVisualStyleBackColor = true;
            // 
            // numMetric
            // 
            this.numMetric.Location = new System.Drawing.Point(212, 75);
            this.numMetric.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.numMetric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numMetric.Name = "numMetric";
            this.numMetric.Size = new System.Drawing.Size(60, 23);
            this.numMetric.TabIndex = 13;
            this.numMetric.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblMetric
            // 
            this.lblMetric.AutoSize = true;
            this.lblMetric.Location = new System.Drawing.Point(159, 78);
            this.lblMetric.Name = "lblMetric";
            this.lblMetric.Size = new System.Drawing.Size(47, 15);
            this.lblMetric.TabIndex = 12;
            this.lblMetric.Text = "跃点数:";
            // 
            // lblAdapterR
            // 
            this.lblAdapterR.AutoSize = true;
            this.lblAdapterR.Location = new System.Drawing.Point(20, 23);
            this.lblAdapterR.Name = "lblAdapterR";
            this.lblAdapterR.Size = new System.Drawing.Size(56, 15);
            this.lblAdapterR.TabIndex = 5;
            this.lblAdapterR.Text = "选择网卡:";
            // 
            // comboAdaptersR
            // 
            this.comboAdaptersR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAdaptersR.FormattingEnabled = true;
            this.comboAdaptersR.Location = new System.Drawing.Point(23, 41);
            this.comboAdaptersR.Name = "comboAdaptersR";
            this.comboAdaptersR.Size = new System.Drawing.Size(530, 23);
            this.comboAdaptersR.TabIndex = 6;
            // 
            // btnLaunchR
            // 
            this.btnLaunchR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLaunchR.Location = new System.Drawing.Point(23, 162);
            this.btnLaunchR.Name = "btnLaunchR";
            this.btnLaunchR.Size = new System.Drawing.Size(531, 30);
            this.btnLaunchR.TabIndex = 10;
            this.btnLaunchR.Text = "2. 启动游戏";
            this.btnLaunchR.UseVisualStyleBackColor = true;
            // 
            // btnBrowseR
            // 
            this.btnBrowseR.Location = new System.Drawing.Point(479, 132);
            this.btnBrowseR.Name = "btnBrowseR";
            this.btnBrowseR.Size = new System.Drawing.Size(75, 25);
            this.btnBrowseR.TabIndex = 9;
            this.btnBrowseR.Text = "浏览...";
            this.btnBrowseR.UseVisualStyleBackColor = true;
            // 
            // txtGamePathR
            // 
            this.txtGamePathR.Location = new System.Drawing.Point(23, 133);
            this.txtGamePathR.Name = "txtGamePathR";
            this.txtGamePathR.Size = new System.Drawing.Size(450, 23);
            this.txtGamePathR.TabIndex = 8;
            // 
            // lblGamePathR
            // 
            this.lblGamePathR.AutoSize = true;
            this.lblGamePathR.Location = new System.Drawing.Point(20, 115);
            this.lblGamePathR.Name = "lblGamePathR";
            this.lblGamePathR.Size = new System.Drawing.Size(83, 15);
            this.lblGamePathR.TabIndex = 7;
            this.lblGamePathR.Text = "War3 游戏路径:";
            // 
            // btnApplyRoute
            // 
            this.btnApplyRoute.Location = new System.Drawing.Point(23, 70);
            this.btnApplyRoute.Name = "btnApplyRoute";
            this.btnApplyRoute.Size = new System.Drawing.Size(130, 30);
            this.btnApplyRoute.TabIndex = 6;
            this.btnApplyRoute.Text = "1. 应用路由";
            this.btnApplyRoute.UseVisualStyleBackColor = true;
            // 
            // btnRestoreRoute
            // 
            this.btnRestoreRoute.Location = new System.Drawing.Point(280, 70);
            this.btnRestoreRoute.Name = "btnRestoreRoute";
            this.btnRestoreRoute.Size = new System.Drawing.Size(130, 30);
            this.btnRestoreRoute.TabIndex = 7;
            this.btnRestoreRoute.Text = "手动还原路由";
            this.btnRestoreRoute.UseVisualStyleBackColor = true;
            // 
            // btnViewRoutes
            // 
            this.btnViewRoutes.Location = new System.Drawing.Point(416, 70);
            this.btnViewRoutes.Name = "btnViewRoutes";
            this.btnViewRoutes.Size = new System.Drawing.Size(138, 30);
            this.btnViewRoutes.TabIndex = 11;
            this.btnViewRoutes.Text = "查看当前路由表";
            this.btnViewRoutes.UseVisualStyleBackColor = true;
            // 
            // txtRouteInfo
            // 
            this.txtRouteInfo.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtRouteInfo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRouteInfo.ForeColor = System.Drawing.SystemColors.Info;
            this.txtRouteInfo.Location = new System.Drawing.Point(23, 200);
            this.txtRouteInfo.Name = "txtRouteInfo";
            this.txtRouteInfo.ReadOnly = true;
            this.txtRouteInfo.Size = new System.Drawing.Size(530, 220);
            this.txtRouteInfo.TabIndex = 12;
            this.txtRouteInfo.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "War3NetHelper by Gemini";
            this.tabControl.ResumeLayout(false);
            this.tabForceBindIP.ResumeLayout(false);
            this.tabForceBindIP.PerformLayout();
            this.tabRoute.ResumeLayout(false);
            this.tabRoute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMetric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabForceBindIP;
        private System.Windows.Forms.TabPage tabRoute;
        private System.Windows.Forms.Label lblAdapterF;
        private System.Windows.Forms.ComboBox comboAdaptersF;
        private System.Windows.Forms.Button btnLaunchF;
        private System.Windows.Forms.Button btnBrowseF;
        private System.Windows.Forms.TextBox txtGamePathF;
        private System.Windows.Forms.Label lblGamePathF;
        private System.Windows.Forms.CheckBox chkForceBindIpDelay;
        private System.Windows.Forms.Label lblAdapterR;
        private System.Windows.Forms.ComboBox comboAdaptersR;
        private System.Windows.Forms.Button btnLaunchR;
        private System.Windows.Forms.Button btnBrowseR;
        private System.Windows.Forms.TextBox txtGamePathR;
        private System.Windows.Forms.Label lblGamePathR;
        private System.Windows.Forms.Button btnApplyRoute;
        private System.Windows.Forms.Button btnRestoreRoute;
        private System.Windows.Forms.Button btnViewRoutes;
        private System.Windows.Forms.RichTextBox txtRouteInfo;
        private System.Windows.Forms.Label lblMetric;
        private System.Windows.Forms.NumericUpDown numMetric;
    }
}