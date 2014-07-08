using System.Collections.Generic;
using TaskTimer.Persistent;
using TaskTimer.POCOs;

namespace TaskTimer.UI
{
    public partial class ArchiverForm : DevExpress.XtraEditors.XtraForm
    {
        public ArchiverForm(ITaskLogger taskLogger)
        {
            _taskLogger = taskLogger;
            InitializeComponent();

            var allTasks = _taskLogger.LoadAllTasks();
            var taskGridItems = GetTaskGridItems(allTasks);
            ActiveTaskGridControl.DataSource = taskGridItems;

            var archivedTasks = _taskLogger.LoadArchivedTasks();
            var archiveTaskGridItems = GetTaskGridItems(archivedTasks);
            ArchivedGridControl.DataSource = archiveTaskGridItems;

        }

        private IEnumerable<TaskGridView> GetTaskGridItems(IEnumerable<ReportTaskItem> allTasks)
        {
            var gridItems = new List<TaskGridView>();
            foreach (ReportTaskItem task in allTasks)
            {
                foreach (TaskItem item in task.TaskItems)
                {
                    gridItems.Add(new TaskGridView
                                      {
                                          Date = task.Date,
                                          DailyTime = item.DailyTime,
                                          Task = item.TaskName,
                                          ActivatedCount = item.ActivatedCount,
                                      });
                }
            }
            return gridItems;
        }
        
        private void ExitButtonClick(object sender, System.EventArgs e)
        {
            Close();
        }

        private readonly ITaskLogger _taskLogger;
    }
}