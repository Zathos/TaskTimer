using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTimer.UI
{
    public partial class TaskEntryForm : Form
    {
        public TaskEntryForm()
        {
            InitializeComponent();
        }

        public MenuItem TaskName
        {
            get { return new MenuItem(TaskNameBox.Text); }
        }
    }
}
