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
            _taskList = taskList;

            var testTask = new TaskItem("task1", (s, e) => TaskClicked(s, e));
            _taskList.MenuItems.Add(testTask);
        }

        private void TaskClicked(Object sender, System.EventArgs e)
        {
            var menuItem = sender as TaskItem;
            if (menuItem != null)
            {
                menuItem.Checked = !menuItem.Checked;
            }
        }

        public IList<TaskItem> TaskItems
        {
            get 
            {
                var taskList = new List<TaskItem>();
                foreach (TaskItem task in _taskList.MenuItems)
                {
                    taskList.Add(task);
                }
                return taskList;
                //return _taskList.MenuItems; 
            }
        }

        private MenuItem _taskList;

    }
}
