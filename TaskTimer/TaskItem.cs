using System.Windows.Forms;

namespace TaskTimer
{
    public class TaskItem
    {
        public TaskItem(MenuItem menuItem)
        {
            TaskName = menuItem.Text;
        }

        public bool Active { get; set; }

        public string DailyTime
        {
            get { return string.Format("{0}:{1}:{2}", _activeSeconds / 3600, _activeSeconds / 60, _activeSeconds % 60); }
        }

        public string TaskName { get; private set; }

        public void AddTime(int secondsToAdd)
        {
            _activeSeconds += secondsToAdd;
        }

        private int _activeSeconds;
    }
}