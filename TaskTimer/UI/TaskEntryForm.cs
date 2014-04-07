using System.Windows.Forms;
using TaskTimer.Properties;

namespace TaskTimer.UI
{
    public partial class TaskEntryForm : Form
    {
        public TaskEntryForm()
        {
            InitializeComponent();
        }

        [NotNull]
        public string TaskName
        {
            get { return TaskNameBox.Text; }
        }
    }
}