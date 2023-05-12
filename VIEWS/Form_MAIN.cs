using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Forms;

namespace HCE_QTCSVC_CLIENT.VIEW
{
    public partial class Form_MAIN : DarkForm
    {
        public Form_MAIN()
        {
            InitializeComponent();
        }

        private void Strip_CAIDAT_Click(object sender, EventArgs e)
        {
            Form_CAIDAT fcaidat = new Form_CAIDAT();
            fcaidat.ShowDialog();
        }
    }
}
