using System.Collections.Generic;
using TaskTimer.POCOs;

namespace TaskTimer.Persistent
{
    public class Exporter
    {
        public Exporter()
        {
            _xmlLogger = new XmlTaskLogger();
        }

        public void ExportToCsvToolStripMenuItemClick()
        {
            IList<ReportTaskItem> reportItems = _xmlLogger.LoadAllTasks();

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

            _xmlLogger.WriteReportToFile(header, fileToGenerate);
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

        private readonly XmlTaskLogger _xmlLogger;
    }
}