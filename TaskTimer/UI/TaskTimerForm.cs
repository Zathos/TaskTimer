using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskTimer.Properties;

namespace TaskTimer
{
    public partial class TaskTimerForm : Form
    {
        public TaskTimerForm(ITaskTimerModel taskTimer)
        {
            InitializeComponent();

            _taskTimer = taskTimer;

            TaskDataGrid.DataSource = _taskTimer.TaskItems;
        }

        private ITaskTimerModel _taskTimer;
    }
}
