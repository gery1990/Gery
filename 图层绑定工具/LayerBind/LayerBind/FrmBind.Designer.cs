namespace LayerBind
{
    partial class FrmBind
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBind));
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMxd = new System.Windows.Forms.TextBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonBd = new System.Windows.Forms.Button();
            this.openFileDialogMXD = new System.Windows.Forms.OpenFileDialog();
            this.textBoxServerN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbServiceName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mxdName = new System.Windows.Forms.TextBox();
            this.txServicesName = new System.Windows.Forms.TextBox();
            this.lbSvrName = new System.Windows.Forms.Label();
            this.btDataSet = new System.Windows.Forms.Button();
            this.lbServiceUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "MXD路径";
            // 
            // textBoxMxd
            // 
            this.textBoxMxd.Location = new System.Drawing.Point(93, 27);
            this.textBoxMxd.Name = "textBoxMxd";
            this.textBoxMxd.ReadOnly = true;
            this.textBoxMxd.Size = new System.Drawing.Size(166, 21);
            this.textBoxMxd.TabIndex = 7;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(369, 25);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 8;
            this.buttonOpen.Tag = "1";
            this.buttonOpen.Text = "打开MXD";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonBd
            // 
            this.buttonBd.Location = new System.Drawing.Point(369, 66);
            this.buttonBd.Name = "buttonBd";
            this.buttonBd.Size = new System.Drawing.Size(75, 23);
            this.buttonBd.TabIndex = 9;
            this.buttonBd.Tag = "2";
            this.buttonBd.Text = "绑定MXD";
            this.buttonBd.UseVisualStyleBackColor = true;
            this.buttonBd.Click += new System.EventHandler(this.buttonBd_Click);
            // 
            // openFileDialogMXD
            // 
            this.openFileDialogMXD.FileName = "openFileDialog1";
            // 
            // textBoxServerN
            // 
            this.textBoxServerN.Location = new System.Drawing.Point(93, 68);
            this.textBoxServerN.Name = "textBoxServerN";
            this.textBoxServerN.Size = new System.Drawing.Size(166, 21);
            this.textBoxServerN.TabIndex = 13;
            this.textBoxServerN.Tag = "5";
            this.textBoxServerN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxServerN_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "GIS服务器";
            // 
            // tbServiceName
            // 
            this.tbServiceName.Location = new System.Drawing.Point(265, 68);
            this.tbServiceName.Name = "tbServiceName";
            this.tbServiceName.Size = new System.Drawing.Size(81, 21);
            this.tbServiceName.TabIndex = 16;
            this.tbServiceName.Tag = "6";
            this.tbServiceName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbServiceName_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "服务别名";
            // 
            // mxdName
            // 
            this.mxdName.Location = new System.Drawing.Point(93, 106);
            this.mxdName.Name = "mxdName";
            this.mxdName.Size = new System.Drawing.Size(253, 21);
            this.mxdName.TabIndex = 18;
            this.mxdName.Tag = "7";
            // 
            // txServicesName
            // 
            this.txServicesName.Location = new System.Drawing.Point(265, 27);
            this.txServicesName.Name = "txServicesName";
            this.txServicesName.Size = new System.Drawing.Size(81, 21);
            this.txServicesName.TabIndex = 20;
            this.txServicesName.Tag = "4";
            this.txServicesName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txServicesName_KeyUp);
            // 
            // lbSvrName
            // 
            this.lbSvrName.AutoSize = true;
            this.lbSvrName.Location = new System.Drawing.Point(34, 150);
            this.lbSvrName.Name = "lbSvrName";
            this.lbSvrName.Size = new System.Drawing.Size(53, 12);
            this.lbSvrName.TabIndex = 21;
            this.lbSvrName.Text = "服务地址";
            // 
            // btDataSet
            // 
            this.btDataSet.Location = new System.Drawing.Point(369, 106);
            this.btDataSet.Name = "btDataSet";
            this.btDataSet.Size = new System.Drawing.Size(75, 23);
            this.btDataSet.TabIndex = 23;
            this.btDataSet.Tag = "8";
            this.btDataSet.Text = "数据库设置";
            this.btDataSet.UseVisualStyleBackColor = true;
            this.btDataSet.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbServiceUrl
            // 
            this.lbServiceUrl.Location = new System.Drawing.Point(93, 146);
            this.lbServiceUrl.Name = "lbServiceUrl";
            this.lbServiceUrl.ReadOnly = true;
            this.lbServiceUrl.Size = new System.Drawing.Size(351, 21);
            this.lbServiceUrl.TabIndex = 24;
            // 
            // FrmBind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 195);
            this.Controls.Add(this.lbServiceUrl);
            this.Controls.Add(this.btDataSet);
            this.Controls.Add(this.lbSvrName);
            this.Controls.Add(this.txServicesName);
            this.Controls.Add(this.mxdName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbServiceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxServerN);
            this.Controls.Add(this.buttonBd);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.textBoxMxd);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmBind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图层绑定工具";
            this.Load += new System.EventHandler(this.FrmBind_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMxd;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonBd;
        private System.Windows.Forms.OpenFileDialog openFileDialogMXD;
        private System.Windows.Forms.TextBox textBoxServerN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbServiceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mxdName;
        private System.Windows.Forms.TextBox txServicesName;
        private System.Windows.Forms.Label lbSvrName;
        private System.Windows.Forms.Button btDataSet;
        private System.Windows.Forms.TextBox lbServiceUrl;
    }
}

