using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTimer
{
    public class TaskItem : MenuItem
    {
        public TaskItem(string taskName, EventHandler onClick)
            : base(taskName, onClick)
        {

        }

        public string TaskName { get; set; }
        public DateTime DailyTime { get; set; }
        public bool Active { get;set;}
    }
}
