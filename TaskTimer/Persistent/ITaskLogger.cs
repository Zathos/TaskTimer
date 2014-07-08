using System.Collections.Generic;
using TaskTimer.POCOs;
using TaskTimer.Properties;

namespace TaskTimer.Persistent
{
    public interface ITaskLogger
    {
        IEnumerable<string> LoadActiveTaskFileNames();
        IList<ReportTaskItem> LoadAllTasks();
        IList<ReportTaskItem> LoadArchivedTasks();

        [NotNull]
        IList<TaskItem> LoadTaskList();

        void SaveChanges([NotNull] IList<TaskItem> taskItems);
    }
}