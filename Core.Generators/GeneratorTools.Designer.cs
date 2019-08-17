namespace Core.Generators
{
    partial class GeneratorTools
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratorTools));
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabCodeGenerator = new System.Windows.Forms.TabPage();
            this.tabBaseSettings = new System.Windows.Forms.TabPage();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabsettings = new System.Windows.Forms.TabControl();
            this.tabs.SuspendLayout();
            this.tabBaseSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabCodeGenerator);
            this.tabs.Controls.Add(this.tabBaseSettings);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1200, 741);
            this.tabs.TabIndex = 0;
            // 
            // tabCodeGenerator
            // 
            this.tabCodeGenerator.Location = new System.Drawing.Point(4, 22);
            this.tabCodeGenerator.Name = "tabCodeGenerator";
            this.tabCodeGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.tabCodeGenerator.Size = new System.Drawing.Size(1192, 715);
            this.tabCodeGenerator.TabIndex = 0;
            this.tabCodeGenerator.Text = "代码生成";
            this.tabCodeGenerator.UseVisualStyleBackColor = true;
            // 
            // tabBaseSettings
            // 
            this.tabBaseSettings.Controls.Add(this.tabsettings);
            this.tabBaseSettings.Location = new System.Drawing.Point(4, 22);
            this.tabBaseSettings.Name = "tabBaseSettings";
            this.tabBaseSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaseSettings.Size = new System.Drawing.Size(1192, 715);
            this.tabBaseSettings.TabIndex = 1;
            this.tabBaseSettings.Text = "基础数据设置";
            this.tabBaseSettings.UseVisualStyleBackColor = true;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "add_edit_24px.png");
            this.imageList.Images.SetKeyName(1, "database_24px.png");
            this.imageList.Images.SetKeyName(2, "edit_24px.png");
            this.imageList.Images.SetKeyName(3, "folder_24px.png");
            this.imageList.Images.SetKeyName(4, "generate_tables_24px.png");
            this.imageList.Images.SetKeyName(5, "refresh_24px.png");
            this.imageList.Images.SetKeyName(6, "remove_24px.png");
            this.imageList.Images.SetKeyName(7, "server_24px.png");
            this.imageList.Images.SetKeyName(8, "table_24px.png");
            this.imageList.Images.SetKeyName(9, "dialog_ok_24px.png");
            this.imageList.Images.SetKeyName(10, "error_24px.png");
            // 
            // tabsettings
            // 
            this.tabsettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsettings.Location = new System.Drawing.Point(3, 3);
            this.tabsettings.Name = "tabsettings";
            this.tabsettings.SelectedIndex = 0;
            this.tabsettings.Size = new System.Drawing.Size(1186, 709);
            this.tabsettings.TabIndex = 0;
            // 
            // GeneratorTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 741);
            this.Controls.Add(this.tabs);
            this.Name = "GeneratorTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GeneratorTools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GeneratorTools_Load);
            this.tabs.ResumeLayout(false);
            this.tabBaseSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabCodeGenerator;
        private System.Windows.Forms.TabPage tabBaseSettings;
        public System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TabControl tabsettings;
    }
}

