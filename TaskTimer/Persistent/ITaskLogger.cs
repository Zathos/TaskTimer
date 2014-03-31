using System.Collections.Generic;
using TaskTimer.Annotations;
using TaskTimer.POCOs;

namespace TaskTimer
{
    public interface ITaskLogger
    {
        [NotNull]
        IList<TaskItem> LoadTaskList();

        void SaveChanges([NotNull] IList<TaskItem> taskItems);
    }
}