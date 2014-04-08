using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using TaskTimer.POCOs;
using TaskTimer.Properties;
using TaskTimer.UI;

namespace TaskTimer
{
    public class MenuManager : INotifyPropertyChanged, IDisposable
    {
        private const string NoActiveTaskMessage = "No Active Task";
        public event PropertyChangedEventHandler PropertyChanged;

        public MenuManager()
        {
        }

        [NotNull]
        public string ClickedMenuItemName
        {
            get { return _activeMenuItem != null ? _activeMenuItem.Text : string.Empty; }
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

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
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
                                Visible = true,
                                ContextMenu = new ContextMenu(new[]
                                                                  {
                                                                      _menuList,
                                                                      new MenuItem("-"),
                                                                      new MenuItem("Manage Tasks", (s, e) => new TaskTimerForm(taskTimerModel).Show()),
                                                                      new MenuItem("Exit", (s, e) => Application.Exit())
                                                                  }),
                                Text = NoActiveTaskMessage,
                            };
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
        ///     unmanaged resources.
        /// </param>
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
                _trayIcon.Text = NoActiveTaskMessage;
            }

            var menuItem = sender as MenuItem;
            if (menuItem == null)
            {
                return;
            }

            if (_activeMenuItem == menuItem)
            {
                _activeMenuItem = null;
            }
            else
            {
                menuItem.Checked = true;
                _trayIcon.Text = menuItem.Text;
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