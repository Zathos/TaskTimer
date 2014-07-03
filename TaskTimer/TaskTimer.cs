using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TaskTimer.Persistent;
using TaskTimer.POCOs;
using TaskTimer.Properties;

namespace TaskTimer
{
    public class TaskTimer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public TaskTimer([NotNull] ITaskLogger taskLogger, [NotNull] MenuManager menuManager)
        {
            _taskLogger = taskLogger;
            _menuManager = menuManager;

            _menuManager.InitializeNewTrayIcon(this);
            _menuManager.PropertyChanged += MenuManagerOnPropertyChanged;

            _taskItems = _taskLogger.LoadTaskList();
            _menuManager.AddMenuItems(_taskItems);

            _currentDayOfMonth = GetCurrentDayOfMonth();

            Application.ApplicationExit += OnApplicationExit;
        }

        public IList<TaskItem> TaskItems
        {
            get { return _taskItems; }
        }

        public void AccumulateTimeForActiveTask()
        {
            var activeTask = GetActiveTask();
            if (activeTask != null)
            {
                AccumulateTime(activeTask, DateTime.Now);
            }
        }

        public bool IsNewDay()
        {
            if (_currentDayOfMonth == GetCurrentDayOfMonth())
            {
                return false;
            }
            _currentDayOfMonth = GetCurrentDayOfMonth();
            return true;
        }


        protected virtual void OnPropertyChanged([CanBeNull] string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private static int GetCurrentDayOfMonth()
        {
            return DateTime.Now.Day;
        }

        private void AccumulateTime(TaskItem task, DateTime now)
        {
            var totalSeconds = (int) (now - _startTime).TotalSeconds;
            if (task != null && totalSeconds >= 0)
            {
                task.ActiveSeconds += totalSeconds;
            }
            _startTime = now;
        }

        private void ActivateTask([NotNull] TaskItem task, DateTime now)
        {
            if (IsNewDay())
            {
                ResetAllTasks();
            }

            _startTime = now;
            task.Active = true;
            task.ActivatedCount += 1;
        }

        private void AddNewTask(string taskName)
        {
            if (_taskItems.Any(x => x.TaskName == taskName))
            {
                return;
            }
            _taskItems.Add(new TaskItem {TaskName = taskName});
            _taskLogger.SaveChanges(_taskItems);
        }


        private void DeactivateTask([NotNull] TaskItem task, DateTime now)
        {
            AccumulateTime(task, now);
            task.Active = false;
        }


        [CanBeNull]
        private TaskItem GetActiveTask()
        {
            return _taskItems.FirstOrDefault(x => x.Active);
        }


        [CanBeNull]
        private TaskItem LookupTask([NotNull] string taskName)
        {
            return _taskItems.FirstOrDefault(x => x.TaskName == taskName);
        }

        private void ResetAllTasks()
        {
            foreach (TaskItem task in _taskItems)
            {
                task.ActiveSeconds = 0;
                task.ActivatedCount = 0;
            }
            _taskLogger.SaveChanges(_taskItems);
        }

        private void MenuManagerOnPropertyChanged([CanBeNull] object sender, [NotNull] PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "MenuItemClicked":
                    DateTime now = DateTime.Now;

                    var activeTask = GetActiveTask();
                    if (activeTask != null)
                    {
                        DeactivateTask(activeTask, now);
                    }

                    var newActiveTask = LookupTask(_menuManager.ClickedMenuItemName);
                    if (newActiveTask != null && newActiveTask != activeTask)
                    {
                        ActivateTask(newActiveTask, now);
                    }

                    _taskLogger.SaveChanges(_taskItems);
                    break;
                case "NewlyAddedItemName":
                    AddNewTask(_menuManager.NewlyAddedItemName);
                    break;
            }
        }

        private void OnApplicationExit(object sender, EventArgs eventArgs)
        {
            TaskItem activeTask = GetActiveTask();
            if (activeTask != null)
            {
                DeactivateTask(activeTask, DateTime.Now);
                _taskLogger.SaveChanges(_taskItems);
            }
        }

        private readonly MenuManager _menuManager;
        private readonly IList<TaskItem> _taskItems;
        private readonly ITaskLogger _taskLogger;
        private int _currentDayOfMonth;
        private DateTime _startTime;
    }
}