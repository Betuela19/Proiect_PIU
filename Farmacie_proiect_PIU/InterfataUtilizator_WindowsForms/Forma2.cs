using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Forma2 : Form
    {
        public Forma2()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var forma = new Farmacie();
            forma.Show();
        }

        private void Forma2_Load(object sender, EventArgs e)
        {

        }
    }
}
