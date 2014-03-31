using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using TaskTimer.Annotations;
using TaskTimer.POCOs;
using TaskTimer.Properties;

namespace TaskTimer
{
    public class MenuManager : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MenuManager()
        {
            //TODO need to add another layer to only hold the data.
            //Load just the data from the XML file.
            //Then create my menu Items from the loaded list.

            //When createing a new task do the same, create the data object, then the menu item.

            //This class will have the Menu item and a POCO 
        }

        [NotNull]
        public string ClickedMenuItemName
        {
            get { return _activeMenuItem != null ? _activeMenuItem.Text : string.Empty; }
        }


        public void Activate([NotNull] string newActiveTask)
        {
            _activeMenuItem.Checked = true;
        }

        public void AddMenuItem([NotNull] string taskName)
        {
            var testMenuItem = new MenuItem(taskName, MenuItemClicked);
            _menuList.MenuItems.Add(testMenuItem);
        }

        public void AddMenuItems([NotNull] IList<TaskItem> taskItems)
        {
            foreach (TaskItem taskItem in taskItems)
            {
                AddMenuItem(taskItem.TaskName);
            }
        }

        public void Deactivate([NotNull] string activeTask)
        {
            _activeMenuItem.Checked = false;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void InitializeNewTrayIcon([NotNull] TaskTimerModel taskTimerModel)
        {
            _menuList = new MenuItem("Tasks");

            _trayIcon = new NotifyIcon
                            {
                                Icon = Resources.TasksIcon,
                                ContextMenu = new ContextMenu(new[]
                                                                  {
                                                                      _menuList,
                                                                      new MenuItem("-"),
                                                                      new MenuItem("Manage Tasks", (s, e) => new TaskTimerForm(taskTimerModel).Show()),
                                                                      new MenuItem("Exit", (s, e) => Application.Exit())
                                                                  }),
                                Visible = true
                            };
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                if (_trayIcon != null)
                {
                    _trayIcon.Dispose();
                }
            }

            _isDisposed = true;
        }

        protected virtual void OnPropertyChanged([CanBeNull] string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void MenuItemClicked([NotNull] object sender, [NotNull] EventArgs e)
        {
            if (_activeMenuItem != null)
            {
                _activeMenuItem.Checked = false;
            }

            var menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                menuItem.Checked = true;
                _activeMenuItem = menuItem;
            }

            OnPropertyChanged("MenuItemClicked");
        }

        private MenuItem _activeMenuItem;
        private bool _isDisposed;
        private MenuItem _menuList;
        private NotifyIcon _trayIcon;
    }
}