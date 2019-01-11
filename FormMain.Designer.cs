namespace NetworkCleaner
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.treeViewReg = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonFlush = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRename = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewReg
            // 
            this.treeViewReg.CheckBoxes = true;
            this.treeViewReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewReg.Location = new System.Drawing.Point(0, 25);
            this.treeViewReg.Name = "treeViewReg";
            this.treeViewReg.Size = new System.Drawing.Size(532, 346);
            this.treeViewReg.TabIndex = 0;
            this.treeViewReg.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewReg_AfterCheck);
            this.treeViewReg.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewReg_NodeMouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonFlush,
            this.toolStripButtonDel,
            this.toolStripButtonRename,
            this.toolStripButtonAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(532, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonFlush
            // 
            this.toolStripButtonFlush.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFlush.Image")));
            this.toolStripButtonFlush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFlush.Name = "toolStripButtonFlush";
            this.toolStripButtonFlush.Size = new System.Drawing.Size(90, 22);
            this.toolStripButtonFlush.Text = "刷新网络(&F)";
            this.toolStripButtonFlush.Click += new System.EventHandler(this.toolStripButtonFlush_Click);
            // 
            // toolStripButtonDel
            // 
            this.toolStripButtonDel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDel.Image")));
            this.toolStripButtonDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDel.Name = "toolStripButtonDel";
            this.toolStripButtonDel.Size = new System.Drawing.Size(117, 22);
            this.toolStripButtonDel.Text = "删除选定网络(&D)";
            this.toolStripButtonDel.Click += new System.EventHandler(this.toolStripButtonDel_Click);
            // 
            // toolStripButtonRename
            // 
            this.toolStripButtonRename.Enabled = false;
            this.toolStripButtonRename.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRename.Image")));
            this.toolStripButtonRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRename.Name = "toolStripButtonRename";
            this.toolStripButtonRename.Size = new System.Drawing.Size(92, 22);
            this.toolStripButtonRename.Text = "修改名称(&R)";
            this.toolStripButtonRename.Click += new System.EventHandler(this.toolStripButtonRename_Click);
            // 
            // toolStripButtonAbout
            // 
            this.toolStripButtonAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAbout.Image")));
            this.toolStripButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAbout.Name = "toolStripButtonAbout";
            this.toolStripButtonAbout.Size = new System.Drawing.Size(68, 22);
            this.toolStripButtonAbout.Text = "关于(&A)";
            this.toolStripButtonAbout.Click += new System.EventHandler(this.toolStripButtonAbout_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(532, 371);
            this.Controls.Add(this.treeViewReg);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows网络清理工具";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewReg;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDel;
        private System.Windows.Forms.ToolStripButton toolStripButtonRename;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbout;
        private System.Windows.Forms.ToolStripButton toolStripButtonFlush;
    }
}

