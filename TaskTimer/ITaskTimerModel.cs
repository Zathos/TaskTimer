using System.Collections.Generic;

namespace TaskTimer
{
    public interface ITaskTimerModel
    {
        IList<TaskItem> TaskItems { get; }
    }
}