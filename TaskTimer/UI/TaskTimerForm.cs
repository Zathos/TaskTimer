using System;
using System.ComponentModel;
using System.Windows.Forms;
using TaskTimer.Annotations;
using TaskTimer.UI;

namespace TaskTimer
{
    public partial class TaskTimerForm : Form
    {
        public TaskTimerForm([NotNull] ITaskTimerModel taskTimer)
        {
            InitializeComponent();

            _taskTimer = taskTimer;
            _taskTimer.PropertyChanged += TaskTimerOnPropertyChanged;

            //TaskDataGrid.Resize += OutputList_Resize;
            //OutputList_Resize(null, null);

            RefreshDataSource();
        }

        private void TaskTimerOnPropertyChanged([CanBeNull] object sender, [NotNull] PropertyChangedEventArgs e)
        {
            RefreshDataSource();
            TaskDataGrid.Refresh();
        }

        private void RefreshDataSource()
        {
            TaskDataGrid.DataSource = _taskTimer.TaskItems;
        }

        private void AddTaskButton_Click([CanBeNull] object sender, [CanBeNull] EventArgs e)
        {
            var newTaskForm = new TaskEntryForm();
            newTaskForm.ShowDialog();

            _taskTimer.AddNewTask(newTaskForm.TaskName);

            RefreshDataSource();
        }

        private void OutputList_Resize([CanBeNull] object sender, [CanBeNull] EventArgs e)
        {
            const int Adjustment = 15;
            TaskDataGrid.Columns[0].Width = (TaskDataGrid.Size.Width / 3) - Adjustment;
            TaskDataGrid.Columns[1].Width = (TaskDataGrid.Size.Width / 3) - Adjustment;
            TaskDataGrid.Columns[2].Width = (TaskDataGrid.Size.Width / 3) - Adjustment;
        }

        private void RemoveTaskButton_Click([NotNull] object sender, [CanBeNull] EventArgs e)
        {
            //TODO confirm removal of task

            //TODO remove task from list and menu option
            //var selectedRows = TaskDataGrid.SelectedRows;
        }

        private readonly ITaskTimerModel _taskTimer;
    }
}