using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class FormLoad : Form
    {
        public FormLoad()
        {
            InitializeComponent();
            Size size = this.BackgroundImage.Size;
            size.Width /= 2;
            size.Height /= 2;
            this.Size = size;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
