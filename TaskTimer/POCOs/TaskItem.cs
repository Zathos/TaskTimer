using System.Xml.Serialization;
using TaskTimer.Properties;

namespace TaskTimer.POCOs
{
    public class TaskItem
    {
        public TaskItem()
        {
            _timeFormatter = new TimeFormatter();
        }

        public int ActivatedCount { get; set; }

        [XmlIgnore]
        public bool Active { get; set; }

        public int ActiveSeconds
        {
            get { return _activeSeconds; }
            set
            {
                _activeSeconds = value;
                _timeFormatter.SetTime(_activeSeconds);
            }
        }

        [NotNull,XmlIgnore]
        public string DailyTime
        {
            get { return _timeFormatter.ToString(); }
            set { }
        }

        [NotNull]
        public string TaskName { get; set; }

        private readonly TimeFormatter _timeFormatter;
        private int _activeSeconds;
    }
}