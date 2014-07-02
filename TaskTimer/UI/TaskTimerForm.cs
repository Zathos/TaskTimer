using System.Collections.Generic;
using System.Windows.Forms;
using TaskTimer.POCOs;
using TaskTimer.Properties;

namespace TaskTimer.UI
{
    public partial class TaskTimerForm : Form
    {
        public TaskTimerForm([NotNull] IList<TaskItem> taskItems)
        {
            InitializeComponent();
            TaskDataGrid.DataSource = taskItems;
        }
    }
}