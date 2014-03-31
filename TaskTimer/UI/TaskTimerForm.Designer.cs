﻿namespace TaskTimer
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
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.RemoveTaskButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DailyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TaskDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.TaskDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskDataGrid.Location = new System.Drawing.Point(0, 0);
            this.TaskDataGrid.Name = "TaskDataGrid";
            this.TaskDataGrid.ReadOnly = true;
            this.TaskDataGrid.Size = new System.Drawing.Size(371, 265);
            this.TaskDataGrid.TabIndex = 0;
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.Location = new System.Drawing.Point(13, 13);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(75, 23);
            this.AddTaskButton.TabIndex = 1;
            this.AddTaskButton.Text = "Add Task";
            this.AddTaskButton.UseVisualStyleBackColor = true;
            this.AddTaskButton.Click += new System.EventHandler(this.AddTaskButton_Click);
            // 
            // RemoveTaskButton
            // 
            this.RemoveTaskButton.Location = new System.Drawing.Point(94, 13);
            this.RemoveTaskButton.Name = "RemoveTaskButton";
            this.RemoveTaskButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveTaskButton.TabIndex = 2;
            this.RemoveTaskButton.Text = "Remove Task";
            this.RemoveTaskButton.UseVisualStyleBackColor = true;
            this.RemoveTaskButton.Click += new System.EventHandler(this.RemoveTaskButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RemoveTaskButton);
            this.panel1.Controls.Add(this.AddTaskButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 49);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TaskDataGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(371, 265);
            this.panel2.TabIndex = 5;
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
            this.ClientSize = new System.Drawing.Size(371, 314);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TaskTimerForm";
            this.Text = "Manage Tasks";
            ((System.ComponentModel.ISupportInitialize)(this.TaskDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TaskDataGrid;
        private System.Windows.Forms.Button AddTaskButton;
        private System.Windows.Forms.Button RemoveTaskButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DailyTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;

    }
}

