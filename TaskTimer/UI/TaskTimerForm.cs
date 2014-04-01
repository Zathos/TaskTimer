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

            TaskDataGrid.Resize += OutputList_Resize;
            OutputList_Resize(null, null);

            RefreshDataSource();
            _refreshTimer = new Timer
                                {
                                    Interval = 1000
                                };
            _refreshTimer.Tick += RefreshTimerOnTick;
            _refreshTimer.Start();

            FormClosing += OnFormClosing;
        }

        private void CloseAction()
        {
            _refreshTimer.Stop();
            _refreshTimer.Dispose();
        }

        private void RefreshDataSource()
        {
            TaskDataGrid.DataSource = _taskTimer.TaskItems;
            TaskDataGrid.Refresh();
        }

        private void AddTaskButton_Click([CanBeNull] object sender, [CanBeNull] EventArgs e)
        {
            var newTaskForm = new TaskEntryForm();
            newTaskForm.ShowDialog();

            _taskTimer.AddNewTask(newTaskForm.TaskName);

            RefreshDataSource();
        }

        private void OnFormClosing([CanBeNull] object sender, [CanBeNull] FormClosingEventArgs formClosingEventArgs)
        {
            CloseAction();
        }

        private void OutputList_Resize([CanBeNull] object sender, [CanBeNull] EventArgs e)
        {
            const int Adjustment = 11;
            var numberOfColumns = TaskDataGrid.Columns.Count;
            for (int i = 0; i < numberOfColumns; i++)
            {
                TaskDataGrid.Columns[i].Width = (TaskDataGrid.Size.Width / numberOfColumns) - Adjustment;
            }


        }

        private void RefreshTimerOnTick([CanBeNull] object sender, [CanBeNull] EventArgs eventArgs)
        {
            RefreshDataSource();
        }

        private void RemoveTaskButton_Click([NotNull] object sender, [CanBeNull] EventArgs e)
        {
            //TODO confirm removal of task

            //TODO remove task from list and menu option
            //var selectedRows = TaskDataGrid.SelectedRows;

            //TODO task is removed from Master List
        }

        private void TaskTimerOnPropertyChanged([CanBeNull] object sender, [NotNull] PropertyChangedEventArgs e)
        {
            RefreshDataSource();
        }

        private void closeToolStripMenuItem_Click([CanBeNull] object sender, [CanBeNull] EventArgs e)
        {
            Close();
        }

        private readonly Timer _refreshTimer;
        private readonly ITaskTimerModel _taskTimer;
    }
}