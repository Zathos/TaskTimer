using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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

        private void RefreshDataSource()
        {
            TaskDataGrid.DataSource = _taskTimer.TaskItems;
            TaskDataGrid.Refresh();
        }

        private void WriteReportToFile(IEnumerable<string> header, Dictionary<string, List<string>> fileToGenerate)
        {
            const string ReportallCsvFileName = "ReportAllGrouped.csv";
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

        private void archiveWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO verify/create the folder structure
            //TODO move files to matching year/month.

            //TODO first pass just move .XML files. Once the reports are cleaned up also move them into the year.
            MessageBox.Show("Not Implemented. Will archive anything older then a week.", "Archive", MessageBoxButtons.OK);
        }

        private void closeToolStripMenuItem_Click([CanBeNull] object sender, [CanBeNull] EventArgs e)
        {
            Close();
        }

        private void exportToCsvToolStripMenuItem_Click(object sender, EventArgs e)
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
                    AddTaskToPaddedTaskItems(headerIndex-1, paddedTaskItems, task.DailyTime);
                }
                fileToGenerate[reportItem.Date] = paddedTaskItems;
            }

            WriteReportToFile(header, fileToGenerate);

            //MessageBox.Show("Done generating report.", "Done", MessageBoxButtons.OK);
        }

        private void FirstPassexportToCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var xmlLoader = new XmlTaskLogger();
            IList<ReportTaskItem> reportItems = xmlLoader.LoadAllTasks();

            const string Seperator = ",";
            var finalCsv = string.Empty;
            foreach (ReportTaskItem reportItem in reportItems)
            {
                var csvHeader = string.Empty;
                var csvTasks = string.Empty;

                csvHeader += "Date" + Seperator;
                csvTasks += reportItem.Date + Seperator;

                foreach (TaskItem item in reportItem.TaskItems)
                {
                    csvHeader += item.TaskName + Seperator;
                    csvTasks += item.DailyTime + Seperator;
                }
                csvHeader += "\n";
                csvTasks += "\n";

                finalCsv += csvHeader + csvTasks + "\n";
            }

            const string ReportallCsvFileName = "ReportAll.csv";
            if (File.Exists(ReportallCsvFileName))
            {
                File.Delete(ReportallCsvFileName);
            }

            using (var file = new StreamWriter(ReportallCsvFileName))
            {
                file.WriteLine(finalCsv);
                file.Close();
            }
        }

        private void weeklyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportForm();
            reportForm.ShowDialog();
        }

        private readonly Timer _refreshTimer;
        private readonly ITaskTimerModel _taskTimer;
    }
}