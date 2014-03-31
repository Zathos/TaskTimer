﻿using System;
using TaskTimer.Annotations;

namespace TaskTimer.POCOs
{
    public class TaskItem
    {
        public TaskItem()
        {
            _timeFormatter = new TimeFormatter();
        }

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

        [NotNull]
        public string TaskName { get; set; }

        private readonly TimeFormatter _timeFormatter;

        [NotNull]
        public string DailyTime {
            get { return _timeFormatter.ToString(); }
            set { }
        }

        private int _activeSeconds;
    }
}