using System.Collections.Generic;
using System.ComponentModel;
using TaskTimer.POCOs;
using TaskTimer.Properties;

namespace TaskTimer
{
    public interface ITaskTimerModel
    {
        event PropertyChangedEventHandler PropertyChanged;

        [NotNull]
        IList<TaskItem> TaskItems { get; }

        void AddNewTask([NotNull] string taskName);
        void AccumulateTimeForActiveTask();
    }
}