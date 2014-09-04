using System.Windows.Forms;
using TaskTimer.Properties;

namespace TaskTimer.UI
{
    public partial class TaskTimerForm : Form
    {
        public TaskTimerForm([NotNull] TaskTimer taskTimer)
        {
            InitializeComponent();
            TaskDataGrid.DataSource = taskTimer.TaskItems;
            taskTimer.AccumulateTimeForActiveTask();
        }
    }
}