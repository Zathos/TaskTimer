namespace TaskTimer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskTimerForm));
            this.TaskDataGrid = new System.Windows.Forms.DataGridView();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DailyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.Active});
            this.TaskDataGrid.Location = new System.Drawing.Point(12, 12);
            this.TaskDataGrid.Name = "TaskDataGrid";
            this.TaskDataGrid.ReadOnly = true;
            this.TaskDataGrid.Size = new System.Drawing.Size(483, 150);
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
            // TaskTimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 236);
            this.Controls.Add(this.TaskDataGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TaskTimerForm";
            this.Text = "Manage Tasks";
            ((System.ComponentModel.ISupportInitialize)(this.TaskDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TaskDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DailyTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;

    }
}

