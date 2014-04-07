using TaskTimer.Properties;

namespace TaskTimer.POCOs
{
    public class TaskItem
    {
        private readonly TimeFormatter _timeFormatter;
        private int _activeSeconds;

        public TaskItem()
        {
            _timeFormatter = new TimeFormatter();
        }

        public bool Active { get; set; }

        public int ActivatedCount { get; set; }

        public int ActiveSeconds
        {
            get { return _activeSeconds; }
            set
            {
                _activeSeconds = value;
                _timeFormatter.SetTime(_activeSeconds);
            }
        }

        [NotNull]
        public string DailyTime
        {
            get { return _timeFormatter.ToString(); }
            set { }
        }

        [NotNull]
        public string TaskName { get; set; }
    }
}