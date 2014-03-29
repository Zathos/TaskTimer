using System;
using System.Windows.Forms;
using TaskTimer.Annotations;

namespace TaskTimer
{
    public class TaskItem
    {
        public TaskItem([NotNull] MenuItem menuItem)
        {
            _menuItem = menuItem;
            TaskName = menuItem.Text;
        }

        protected TaskItem()
        {
            //TODO need to add another layer to only hold the data.
            //Load just the data from the XML file.
            //Then create my menu Items from the loaded list.

            //When createing a new task do the same, create the data object, then the menu item.

            //This class will have the Menu item and a POCO 
        }

        public bool Active
        {
            get { return _menuItem.Checked; }
            set { _menuItem.Checked = value; }
        }

        public int ActiveSeconds { get; set; }

        [NotNull]
        public string DailyTime
        {
            get { return string.Format("{0:00}:{1:00}:{2:00}", ActiveSeconds / 3600, ActiveSeconds / 60, ActiveSeconds % 60); }
        }

        [NotNull]
        public string TaskName { get; set; }

        public void StartTiming(DateTime now)
        {
            _startTime = now;
            Active = true;
        }

        public void StopTiming(DateTime now)
        {
            TimeSpan time = now - _startTime;
            ActiveSeconds += (int) time.TotalSeconds;
            Active = false;
        }

        private readonly MenuItem _menuItem;
        private DateTime _startTime;
    }
}