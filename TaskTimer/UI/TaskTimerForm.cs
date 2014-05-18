using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using TaskTimer.Persistent;
using TaskTimer.POCOs;
using TaskTimer.Properties;

namespace TaskTimer.UI
{
    public partial class TaskTimerForm : Form
    {
        private const string ReportallCsvFileName = "ReportAllGrouped.csv";

        public TaskTimerForm([NotNull] ITaskTimerModel taskTimer)
        {
            InitializeComponent();

            _taskTimer = taskTimer;
            _taskTimer.PropertyChanged += TaskTimerOnPropertyChanged;

            TaskDataGrid.Resize += OutputListResize;
            OutputListResize(null, null);

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

        private void AddTaskToPaddedTaskItems(int headerIndex, IList<string> paddedTaskItems, string task)
        {
            for (int i = paddedTaskItems.Count - 1; i <= headerIndex; i++)
            {
                paddedTaskItems.Add(string.Empty);
            }

            if (headerIndex < paddedTaskItems.Count)
            {
                paddedTaskItems[headerIndex] = task;
            }
        }

        private void CloseAction()
        {
            _refreshTimer.Stop();
            _refreshTimer.Dispose();
        }

        private int FindHeaderIndex(IList<string> header, string taskName)
        {
            for (int i = 0; i < header.Count; i++)
            {
                if (header[i] == taskName)
                {
                    return i;
                }
            }
            header.Add(taskName);
            return header.Count - 1;
        }

        private DateTime GetLastSunday()
        {
            var now = DateTime.Now;
            var lastSunday = now.DayOfWeek - DayOfWeek.Sunday;
            if (lastSunday < 0)
            {
                lastSunday += 7;
            }
            return now.AddDays(-lastSunday);
        }

        private void OpenReportFile()
        {
            System.Diagnostics.Process.Start(ReportallCsvFileName);
        }

        private void RefreshDataSource()
        {
            TaskDataGrid.DataSource = _taskTimer.TaskItems;
            TaskDataGrid.Refresh();
        }

        private void WriteReportToFile(IEnumerable<string> header, Dictionary<string, List<string>> fileToGenerate)
        {
            if (File.Exists(ReportallCsvFileName))
            {
                File.Delete(ReportallCsvFileName);
            }

            const string Seperator = ",";

            var outputString = string.Empty;
            foreach (string activity in header)
            {
                outputString += activity + Seperator;
            }
            outputString.Substring(0, outputString.Length - 1);
            outputString += "\n";

            foreach (KeyValuePair<string, List<string>> valuePair in fileToGenerate)
            {
                outputString += valuePair.Key + Seperator;
                foreach (string dailyTime in valuePair.Value)
                {
                    outputString += dailyTime + Seperator;
                }
                outputString.Substring(0, outputString.Length - 1);
                outputString += "\n";
            }


            using (var file = new StreamWriter(ReportallCsvFileName))
            {
                file.Write(outputString);
                file.Close();
            }
        }

        private void AddTaskButtonClick([CanBeNull] object sender, [CanBeNull] EventArgs e)
        {
            var newTaskForm = new TaskEntryForm();
            newTaskForm.ShowDialog();

            _taskTimer.AddNewTask(newTaskForm.TaskName);

            //TODO why doesn't this actually refresh, it works in other places. Different thread?
            RefreshDataSource();
        }

        private void ArchiveWeekToolStripMenuItemClick(object sender, EventArgs e)
        {
            var xmlLoader = new XmlTaskLogger();
            var fileNames = xmlLoader.LoadAllTaskFileNames();
            var lastSunday = GetLastSunday();

            //remove any file created after last sunday from the list
            

            //loop over list
            //   put each file in year(4)/month (name)


            //TODO verify/create the folder structure
            //TODO move files to matching year/month.

            //TODO first pass just move .XML files. Once the reports are cleaned up also move them into the year.
            MessageBox.Show("Not Implemented. Will archive anything older then a week.", "Archive", MessageBoxButtons.OK);
        }

        private void CloseToolStripMenuItemClick([CanBeNull] object sender, [CanBeNull] EventArgs e)
        {
            Close();
        }

        private void ExportToCsvToolStripMenuItemClick(object sender, EventArgs e)
        {
            var xmlLoader = new XmlTaskLogger();
            IList<ReportTaskItem> reportItems = xmlLoader.LoadAllTasks();

            var header = new List<string> {string.Empty};

            var fileToGenerate = new Dictionary<string, List<string>>();

            foreach (ReportTaskItem reportItem in reportItems)
            {
                var paddedTaskItems = new List<string>();
                foreach (TaskItem task in reportItem.TaskItems)
                {
                    int headerIndex = FindHeaderIndex(header, task.TaskName);
                    AddTaskToPaddedTaskItems(headerIndex - 1, paddedTaskItems, task.DailyTime);
                }
                fileToGenerate[reportItem.Date] = paddedTaskItems;
            }

            WriteReportToFile(header, fileToGenerate);

            OpenReportFile();
        }

        private void OnFormClosing([CanBeNull] object sender, [CanBeNull] FormClosingEventArgs formClosingEventArgs)
        {
            CloseAction();
        }

        private void OutputListResize([CanBeNull] object sender, [CanBeNull] EventArgs e)
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
            _taskTimer.AccumulateTimeForActiveTask();
            RefreshDataSource();
        }

        private void RemoveTaskButtonClick([NotNull] object sender, [CanBeNull] EventArgs e)
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

        private void WeeklyToolStripMenuItemClick(object sender, EventArgs e)
        {
            var reportForm = new ReportForm();
            reportForm.ShowDialog();
        }

        private readonly Timer _refreshTimer;
        private readonly ITaskTimerModel _taskTimer;
    }
}