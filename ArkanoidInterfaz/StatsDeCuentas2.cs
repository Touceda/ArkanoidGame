using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidInterfaz
{
    public partial class StatsDeCuentas2 : Form
    {
        private DataTable Logs;
        public StatsDeCuentas2(DataTable logs)
        {
            this.Logs = logs;
            InitializeComponent();
        }

        private void StatsDeCuentas2_Load(object sender, EventArgs e)
        {
            dgvLogs.DataSource = Logs;
        }
    }
}
