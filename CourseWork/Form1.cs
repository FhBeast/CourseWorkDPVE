using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseWork.Utils;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var textBox in Controls.OfType<TextBox>())
            {
                textBox.TextChanged += DrawPreview;
            }
            DrawPreview(sender, e);
        }

        private void DrawPreview(object sender, EventArgs e)
        {
            foreach (var textBox in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    errorProvider1.SetError(panel1, "Одна из строк пуста!");
                    return;
                }
                else if (!int.TryParse(textBox.Text, out _))
                {
                    errorProvider1.SetError(panel1, "Вводить можно только числа!");
                    return;
                }
                errorProvider1.Clear();

                double.TryParse(textBox0_0.Text, out double x1);
                double.TryParse(textBox1_0.Text, out double x2);
                double.TryParse(textBox2_0.Text, out double x3);
                double.TryParse(textBox0_1.Text, out double y1);
                double.TryParse(textBox1_1.Text, out double y2);
                double.TryParse(textBox2_1.Text, out double y3);
                double.TryParse(textBox0_2.Text, out double z1);
                double.TryParse(textBox1_2.Text, out double z2);
                double.TryParse(textBox2_2.Text, out double z3);
                double.TryParse(textBox0_3.Text, out double result1);
                double.TryParse(textBox1_3.Text, out double result2);
                double.TryParse(textBox2_3.Text, out double result3);

                labelFirstLine.Text = String.Format("{0}x {1}y {2}z = {3}",
                    x1, FormatChanger.ToEquationForm(y1), FormatChanger.ToEquationForm(z1), result1);
                labelSecondLine.Text = String.Format("{0}x {1}y {2}z = {3}",
                    x2, FormatChanger.ToEquationForm(y2), FormatChanger.ToEquationForm(z2), result2);
                labelThirdLine.Text = String.Format("{0}x {1}y {2}z = {3}",
                    x3, FormatChanger.ToEquationForm(y3), FormatChanger.ToEquationForm(z3), result3);
            }
        }
    }
}
