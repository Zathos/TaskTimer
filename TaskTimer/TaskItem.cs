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

        public bool Active
        {
            get { return _menuItem.Checked; }
            set
            {
                _menuItem.Checked = value;
            }
        }

        [NotNull]
        public string DailyTime
        {
            get { return string.Format("{0:00}:{1:00}:{2:00}", _activeSeconds / 3600, _activeSeconds / 60, _activeSeconds % 60); }
        }

        [NotNull]
        public string TaskName { get; private set; }

        public void StartTiming(DateTime now)
        {
            _startTime = now;
            Active = true;
        }

        public void StopTiming(DateTime now)
        {
            TimeSpan time = now - _startTime;
            _activeSeconds += (int) time.TotalSeconds;
            Active = false;
        }

        private readonly MenuItem _menuItem;
        private int _activeSeconds;
        private DateTime _startTime;
    }
}