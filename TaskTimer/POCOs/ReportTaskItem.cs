using System.Collections.Generic;

namespace TaskTimer.POCOs
{
    public class ReportTaskItem
    {
        public ReportTaskItem(string date, IList<TaskItem> taskItems)
        {
            Date = date;
            TaskItems = taskItems;
        }

        public string Date { get; private set; }
        public IList<TaskItem> TaskItems { get; private set; }
    }
}