namespace TaskTimer.UI
{
    partial class TaskTimerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskTimerForm));
            this.TaskDataGrid = new System.Windows.Forms.DataGridView();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DailyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ActiveSeconds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivatedCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TaskDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TaskDataGrid
            // 
            this.TaskDataGrid.AllowUserToAddRows = false;
            this.TaskDataGrid.AllowUserToDeleteRows = false;
            this.TaskDataGrid.AllowUserToOrderColumns = true;
            this.TaskDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaskDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskName,
            this.DailyTime,
            this.Active,
            this.ActiveSeconds,
            this.ActivatedCount});
            this.TaskDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskDataGrid.Location = new System.Drawing.Point(0, 0);
            this.TaskDataGrid.Name = "TaskDataGrid";
            this.TaskDataGrid.ReadOnly = true;
            this.TaskDataGrid.Size = new System.Drawing.Size(543, 275);
            this.TaskDataGrid.TabIndex = 0;
            // 
            // TaskName
            // 
            this.TaskName.DataPropertyName = "TaskName";
            this.TaskName.HeaderText = "Task Name";
            this.TaskName.Name = "TaskName";
            this.TaskName.ReadOnly = true;
            // 
            // DailyTime
            // 
            this.DailyTime.DataPropertyName = "DailyTime";
            this.DailyTime.HeaderText = "Daily Time";
            this.DailyTime.Name = "DailyTime";
            this.DailyTime.ReadOnly = true;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            // 
            // ActiveSeconds
            // 
            this.ActiveSeconds.DataPropertyName = "ActiveSeconds";
            this.ActiveSeconds.HeaderText = "Active Seconds";
            this.ActiveSeconds.Name = "ActiveSeconds";
            this.ActiveSeconds.ReadOnly = true;
            // 
            // ActivatedCount
            // 
            this.ActivatedCount.DataPropertyName = "ActivatedCount";
            this.ActivatedCount.HeaderText = "Activated Count";
            this.ActivatedCount.Name = "ActivatedCount";
            this.ActivatedCount.ReadOnly = true;
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 5000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimerTick);
            // 
            // TaskTimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 275);
            this.Controls.Add(this.TaskDataGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TaskTimerForm";
            this.Text = "Active Tasks";
            ((System.ComponentModel.ISupportInitialize)(this.TaskDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TaskDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DailyTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActiveSeconds;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivatedCount;
        private System.Windows.Forms.Timer UpdateTimer;

    }
}

