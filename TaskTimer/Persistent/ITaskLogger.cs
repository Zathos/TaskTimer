using System.Collections.Generic;
using TaskTimer.POCOs;
using TaskTimer.Properties;

namespace TaskTimer.Persistent
{
    public interface ITaskLogger
    {
        IEnumerable<string> LoadAllTaskFileNames();
        IList<ReportTaskItem> LoadAllTasks();

        [NotNull]
        IList<TaskItem> LoadTaskList();

        void SaveChanges([NotNull] IList<TaskItem> taskItems);
    }
}