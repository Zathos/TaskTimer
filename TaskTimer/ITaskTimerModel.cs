using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskTimer
{
    public interface ITaskTimerModel
    {
        IList<TaskItem> TaskItems { get; }
    }
}
