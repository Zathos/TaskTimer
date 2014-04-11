using System.Collections.Generic;
using TaskTimer.POCOs;
using TaskTimer.Properties;

namespace TaskTimer.Persistent
{
    public interface ITaskLogger
    {
        [NotNull]
        IList<TaskItem> LoadTaskList();

        IList<ReportTaskItem> LoadAllTasks();

        void SaveChanges([NotNull] IList<TaskItem> taskItems);
    }
}