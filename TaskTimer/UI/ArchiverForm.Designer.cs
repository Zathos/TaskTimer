namespace TaskTimer.UI
{
    partial class ArchiverForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiverForm));
            this.ActiveTaskGridControl = new DevExpress.XtraGrid.GridControl();
            this.ActiveTaskGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ActiveGroupControl = new DevExpress.XtraEditors.GroupControl();
            this.ArchivedGroupControl = new DevExpress.XtraEditors.GroupControl();
            this.ArchivedGridControl = new DevExpress.XtraGrid.GridControl();
            this.ArchiveGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ExitButton = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveTaskGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveTaskGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveGroupControl)).BeginInit();
            this.ActiveGroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArchivedGroupControl)).BeginInit();
            this.ArchivedGroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArchivedGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArchiveGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ActiveTaskGridControl
            // 
            this.ActiveTaskGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActiveTaskGridControl.Location = new System.Drawing.Point(2, 21);
            this.ActiveTaskGridControl.MainView = this.ActiveTaskGrid;
            this.ActiveTaskGridControl.Name = "ActiveTaskGridControl";
            this.ActiveTaskGridControl.Size = new System.Drawing.Size(381, 488);
            this.ActiveTaskGridControl.TabIndex = 0;
            this.ActiveTaskGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ActiveTaskGrid});
            // 
            // ActiveTaskGrid
            // 
            this.ActiveTaskGrid.GridControl = this.ActiveTaskGridControl;
            this.ActiveTaskGrid.Name = "ActiveTaskGrid";
            this.ActiveTaskGrid.OptionsView.ShowFooter = true;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ActiveGroupControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.ArchivedGroupControl);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(799, 511);
            this.splitContainerControl1.SplitterPosition = 385;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ActiveGroupControl
            // 
            this.ActiveGroupControl.Controls.Add(this.ActiveTaskGridControl);
            this.ActiveGroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActiveGroupControl.Location = new System.Drawing.Point(0, 0);
            this.ActiveGroupControl.Name = "ActiveGroupControl";
            this.ActiveGroupControl.Size = new System.Drawing.Size(385, 511);
            this.ActiveGroupControl.TabIndex = 1;
            this.ActiveGroupControl.Text = "Active Logs";
            // 
            // ArchivedGroupControl
            // 
            this.ArchivedGroupControl.Controls.Add(this.ArchivedGridControl);
            this.ArchivedGroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchivedGroupControl.Location = new System.Drawing.Point(0, 0);
            this.ArchivedGroupControl.Name = "ArchivedGroupControl";
            this.ArchivedGroupControl.Size = new System.Drawing.Size(409, 511);
            this.ArchivedGroupControl.TabIndex = 3;
            this.ArchivedGroupControl.Text = "Archived Logs";
            // 
            // ArchivedGridControl
            // 
            this.ArchivedGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchivedGridControl.Location = new System.Drawing.Point(2, 21);
            this.ArchivedGridControl.MainView = this.ArchiveGrid;
            this.ArchivedGridControl.Name = "ArchivedGridControl";
            this.ArchivedGridControl.Size = new System.Drawing.Size(405, 488);
            this.ArchivedGridControl.TabIndex = 2;
            this.ArchivedGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ArchiveGrid});
            // 
            // ArchiveGrid
            // 
            this.ArchiveGrid.GridControl = this.ArchivedGridControl;
            this.ArchiveGrid.Name = "ArchiveGrid";
            this.ArchiveGrid.OptionsView.ShowFooter = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ExitButton);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 515);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(803, 36);
            this.panelControl1.TabIndex = 3;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(716, 6);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Exit";
            this.ExitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.splitContainerControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(803, 515);
            this.panelControl2.TabIndex = 4;
            // 
            // ArchiverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 551);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ArchiverForm";
            this.Text = "Log Files";
            ((System.ComponentModel.ISupportInitialize)(this.ActiveTaskGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveTaskGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ActiveGroupControl)).EndInit();
            this.ActiveGroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArchivedGroupControl)).EndInit();
            this.ArchivedGroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArchivedGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArchiveGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl ActiveTaskGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView ActiveTaskGrid;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl ArchivedGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView ArchiveGrid;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton ExitButton;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl ActiveGroupControl;
        private DevExpress.XtraEditors.GroupControl ArchivedGroupControl;
    }
}