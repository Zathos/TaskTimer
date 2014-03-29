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
        public TaskItem(MenuItem menuItem)
        {
            TaskName = menuItem.Text;
            _menuItem = menuItem;
        }

        public string TaskName { get; private set; }
        public string DailyTime 
        {
            get
            {
                return string.Format("{0}:{1}:{2}", _activeSeconds / 3600, _activeSeconds / 60, _activeSeconds % 60);
            }
        }
        public bool Active { get; set;}

        public void AddTime(int secondsToAdd)
        {
            _activeSeconds += secondsToAdd;
        }

        private int _activeSeconds;
        [NonSerialized]
        private MenuItem _menuItem;
    }
}
