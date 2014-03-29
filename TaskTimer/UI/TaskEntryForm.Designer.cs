namespace TaskTimer.UI
{
    partial class TaskEntryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TaskNameBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelTaskButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Name of New Task:";
            // 
            // TaskNameBox
            // 
            this.TaskNameBox.Location = new System.Drawing.Point(12, 25);
            this.TaskNameBox.Name = "TaskNameBox";
            this.TaskNameBox.Size = new System.Drawing.Size(260, 20);
            this.TaskNameBox.TabIndex = 1;
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(116, 49);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelTaskButton
            // 
            this.CancelTaskButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelTaskButton.Location = new System.Drawing.Point(197, 49);
            this.CancelTaskButton.Name = "CancelTaskButton";
            this.CancelTaskButton.Size = new System.Drawing.Size(75, 23);
            this.CancelTaskButton.TabIndex = 3;
            this.CancelTaskButton.Text = "Cancel";
            this.CancelTaskButton.UseVisualStyleBackColor = true;
            // 
            // TaskEntryForm
            // 
            this.AcceptButton = OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = CancelTaskButton;
            this.ClientSize = new System.Drawing.Size(284, 79);
            this.Controls.Add(this.CancelTaskButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TaskNameBox);
            this.Controls.Add(this.label1);
            this.Name = "TaskEntryForm";
            this.Text = "TaskEntryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TaskNameBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelTaskButton;
    }
}