using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TaskTimer.Annotations;
using TaskTimer.POCOs;

namespace TaskTimer
{
    public class TaskTimerModel : ITaskTimerModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public TaskTimerModel([NotNull] ITaskLogger taskLogger, [NotNull] MenuManager menuManager)
        {
            _taskLogger = taskLogger;
            _menuManager = menuManager;

            _menuManager.InitializeNewTrayIcon(this);
            _menuManager.PropertyChanged += MenuManagerOnPropertyChanged;

            _taskItems = _taskLogger.LoadTaskList();
            _menuManager.AddMenuItems(_taskItems);

            //##########  Testin area
            const string TestName = "task1";
            AddNewTask(TestName);
        }

        public IList<TaskItem> TaskItems
        {
            get { return _taskItems; }
        }

        public void AddNewTask(string taskName)
        {
            if (_taskItems.Any(x => x.TaskName == taskName))
            {
                return;
            }

            _menuManager.AddMenuItem(taskName);
            _taskItems.Add(new TaskItem
                               {
                                   TaskName = taskName,
                               });
        }
        
        protected virtual void OnPropertyChanged([CanBeNull] string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ActivateTask([NotNull] TaskItem task, DateTime now)
        {
            _startTime = now;
            task.Active = true;
        }

        private void DeactivateTask([NotNull] TaskItem task, DateTime now)
        {
            task.ActiveSeconds += (int) (now - _startTime).TotalSeconds;
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

        private void MenuManagerOnPropertyChanged([CanBeNull] object sender, [NotNull] PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "MenuItemClicked":
                    var now = DateTime.Now;

                    var newActiveTask = LookupTask(_menuManager.ClickedMenuItemName);
                    if (newActiveTask == null)
                    {
                        return;
                    }

                    var activeTask = GetActiveTask();
                    if (activeTask != null)
                    {
                        DeactivateTask(activeTask, now);
                    }

                    if (newActiveTask != activeTask)
                    {
                        ActivateTask(newActiveTask, now);
                    }

                    _taskLogger.SaveChanges(_taskItems);
                    OnPropertyChanged("MenuItemClicked");
                    break;
            }
        }

        private readonly MenuManager _menuManager;
        private readonly IList<TaskItem> _taskItems;
        private readonly ITaskLogger _taskLogger;
        private DateTime _startTime;
    }
}