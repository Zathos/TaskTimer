using System.Collections.Generic;
using TaskTimer.POCOs;
using TaskTimer.Properties;

namespace TaskTimer.Persistent
{
    public interface ITaskLogger
    {
        [NotNull]
        IList<TaskItem> LoadTaskList();

        void SaveChanges([NotNull] IList<TaskItem> taskItems);
    }
}