using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseWork.Extension;

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
                else if (!double.TryParse(textBox.Text, out _))
                {
                    errorProvider1.SetError(panel1, "Вводить можно только числа!");
                    return;
                }
                errorProvider1.Clear();
            }

            var x1 = double.Parse(textBox0_0.Text);
            var x2 = double.Parse(textBox1_0.Text);
            var x3 = double.Parse(textBox2_0.Text);
            var y1 = double.Parse(textBox0_1.Text);
            var y2 = double.Parse(textBox1_1.Text);
            var y3 = double.Parse(textBox2_1.Text);
            var z1 = double.Parse(textBox0_2.Text);
            var z2 = double.Parse(textBox1_2.Text);
            var z3 = double.Parse(textBox2_2.Text);
            var result1 = double.Parse(textBox0_3.Text);
            var result2 = double.Parse(textBox1_3.Text);
            var result3 = double.Parse(textBox2_3.Text);

            labelFirstLine.Text = $@"{x1}x {y1.ToEquationForm()}y {z1.ToEquationForm()}z = {result1}";
            labelSecondLine.Text = $@"{x2}x {y2.ToEquationForm()}y {z2.ToEquationForm()}z = {result2}";
            labelThirdLine.Text = $@"{x3}x {y3.ToEquationForm()}y {z3.ToEquationForm()}z = {result3}";
        }

        private static void CalculateEquation()
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CalculateEquation();
        }
    }
}
