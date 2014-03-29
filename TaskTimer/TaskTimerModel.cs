using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskTimer
{
    public class TaskTimerModel : ITaskTimerModel
    {
        public TaskTimerModel(MenuItem taskList)
        {
            _menuList = taskList;

            _taskItems = new Dictionary<string, TaskItem>();


            //##########  Testin area
            const string testName = "task1";

            var testMenuItem = new MenuItem(testName, (s, e) => TaskClicked(s, e));
            _menuList.MenuItems.Add(testMenuItem);

            var testTaskItem = new TaskItem(testMenuItem);
            _taskItems[testName] = testTaskItem;
        }

        private void TaskClicked(Object sender, System.EventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                var taskItem = _taskItems[menuItem.Text];
                if (taskItem == null)
                {
                    return;
                }

                menuItem.Checked = !menuItem.Checked;
                taskItem.Active = menuItem.Checked;
            }
        }

        public IList<TaskItem> TaskItems
        {
            get 
            {
                var taskList = new List<TaskItem>();
                foreach (KeyValuePair<string, TaskItem> task in _taskItems)
                {
                    taskList.Add(task.Value);
                }
                return taskList;
            }
        }

        private MenuItem _menuList;
        private Dictionary<string, TaskItem> _taskItems;
    }
}
