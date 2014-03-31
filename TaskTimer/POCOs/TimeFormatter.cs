using TaskTimer.Annotations;

namespace TaskTimer.POCOs
{
    public class TimeFormatter
    {
        public void SetTime(int seconds)
        {
            _seconds = seconds;
        }

        public override string ToString()
        {
            return string.Format("{0:00}:{1:00}:{2:00}", _seconds / 3600, _seconds / 60, _seconds % 60);
        }

        private int _seconds;
    }
}