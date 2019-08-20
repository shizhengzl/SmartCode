namespace Core.Generators
{
    partial class SelectEntitys
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treedto = new System.Windows.Forms.TreeView();
            this.dataGridViewColumns = new System.Windows.Forms.DataGridView();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // treedto
            // 
            this.treedto.Location = new System.Drawing.Point(34, 92);
            this.treedto.Name = "treedto";
            this.treedto.Size = new System.Drawing.Size(422, 618);
            this.treedto.TabIndex = 1;
            this.treedto.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treedto_BeforeCheck);
            this.treedto.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treedto_NodeMouseDoubleClick);
            // 
            // dataGridViewColumns
            // 
            this.dataGridViewColumns.AllowUserToAddRows = false;
            this.dataGridViewColumns.AllowUserToDeleteRows = false;
            this.dataGridViewColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewColumns.Location = new System.Drawing.Point(475, 38);
            this.dataGridViewColumns.Name = "dataGridViewColumns";
            this.dataGridViewColumns.RowTemplate.Height = 23;
            this.dataGridViewColumns.Size = new System.Drawing.Size(609, 672);
            this.dataGridViewColumns.TabIndex = 2;
            // 
            // txtClassName
            // 
            this.txtClassName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClassName.Location = new System.Drawing.Point(34, 727);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(422, 26);
            this.txtClassName.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(485, 727);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(582, 727);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSearch.Location = new System.Drawing.Point(34, 38);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(422, 35);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // SelectEntitys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 790);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.dataGridViewColumns);
            this.Controls.Add(this.treedto);
            this.Name = "SelectEntitys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectEntitys";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treedto;
        private System.Windows.Forms.DataGridView dataGridViewColumns;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSearch;
    }
}