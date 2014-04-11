using System;
using System.ComponentModel;
using System.Windows.Forms;
using TaskTimer.Persistent;
using TaskTimer.POCOs;
using TaskTimer.Properties;

namespace TaskTimer.UI
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
                                    //TODO maybe make this a configuration option
                                    Interval = 10000
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

            //TODO why doesn't this actually refresh, it works in other places.
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
            //TODO need to accumulate the time before refreshing the data.
            _taskTimer.AccumulateTimeForActiveTask();
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

        private void weeklyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportForm();
            reportForm.ShowDialog();
        }

        private void exportToCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //load all XML files
            var xmlLoader = new XmlTaskLogger();
            var reportItems = xmlLoader.LoadAllTasks();

            //create 2D CSV file
            foreach (ReportTaskItem reportItem in reportItems)
            {
                
            }

            //save the data from the file to a class that makes sense.

            //for each file (date)



        }

    }
}