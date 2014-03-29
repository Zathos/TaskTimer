using System;
using System.Windows.Forms;
using TaskTimer.UI;

namespace TaskTimer
{
    public partial class TaskTimerForm : Form
    {
        public TaskTimerForm(ITaskTimerModel taskTimer)
        {
            InitializeComponent();

            _taskTimer = taskTimer;

            TaskDataGrid.Resize += OutputList_Resize;
            TaskDataGrid.DataSource = _taskTimer.TaskItems;

            OutputList_Resize(null, null);
        }

        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            var newTaskForm = new TaskEntryForm();
            newTaskForm.ShowDialog();

            //TODO save new task to taskDataGrid and some how update menu?
            var newTask = new TaskItem(newTaskForm.TaskName);
            _taskTimer.TaskItems.Add(newTask);
        }

        private void RemoveTaskButton_Click(object sender, EventArgs e)
        {
            //TODO confirm removal of task
            //TODO remove task from list and menu option
            //var selectedRows = TaskDataGrid.SelectedRows;
        }

        private void OutputList_Resize(object sender, EventArgs e)
        {
            const int Adjustment = 15;
            TaskDataGrid.Columns[0].Width = (TaskDataGrid.Size.Width / 3) - Adjustment;
            TaskDataGrid.Columns[1].Width = (TaskDataGrid.Size.Width / 3) - Adjustment;
            TaskDataGrid.Columns[2].Width = (TaskDataGrid.Size.Width / 3) - Adjustment;
        }

        private ITaskTimerModel _taskTimer;
    }
}