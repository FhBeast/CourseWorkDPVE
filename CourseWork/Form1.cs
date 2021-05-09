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
using CourseWork.Model;

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
                double x;
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    errorProvider1.SetError(panel1, "Одна из строк пуста!");
                    return;
                }
                else if (!double.TryParse(textBox.Text, out x))
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

        private void CalculateEquation()
        {
            const int lines = 3;
            const int columns = 4;
            var matrix = new List<List<double>>();
            for (var i = 0; i < lines; i++)
            {
                matrix.Add(new List<double>());
                for (var n = 0; n < columns; n++)
                {
                    matrix[i].Add(new double());
                }
            }

            matrix[0][0] = double.Parse(textBox0_0.Text);
            matrix[1][0] = double.Parse(textBox1_0.Text);
            matrix[2][0] = double.Parse(textBox2_0.Text);
            matrix[0][1] = double.Parse(textBox0_1.Text);
            matrix[1][1] = double.Parse(textBox1_1.Text);
            matrix[2][1] = double.Parse(textBox2_1.Text);
            matrix[0][2] = double.Parse(textBox0_2.Text);
            matrix[1][2] = double.Parse(textBox1_2.Text);
            matrix[2][2] = double.Parse(textBox2_2.Text);
            matrix[0][3] = double.Parse(textBox0_3.Text);
            matrix[1][3] = double.Parse(textBox1_3.Text);
            matrix[2][3] = double.Parse(textBox2_3.Text);

            var equation = new EquationsSystem(matrix);
            richTextBox1.Clear();
            ShowSolutionStep(equation);
            equation.FirstTransformation();
            ShowSolutionStep(equation);
            equation.StairsTransformation();
            ShowSolutionStep(equation);
            equation.InverseGauss();
            double x = equation.Result.X;
            double y = equation.Result.Y;
            double z = equation.Result.Z;
            richTextBox1.Text += $"x = {x}\n y = {y}\n z = {z}\n";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CalculateEquation();
        }

        private void ShowSolutionStep(EquationsSystem equation)
        {
            var text = $"|\t{equation.Matrix[0][0]}" +
                       $"\t{equation.Matrix[0][1]}" +
                       $"\t{equation.Matrix[0][2]}\t" +
                       $"|\t{equation.Matrix[0][3]}\t|\n";
            richTextBox1.Text += text;
            text = $"|\t{equation.Matrix[1][0]}" +
                   $"\t{equation.Matrix[1][1]}" +
                   $"\t{equation.Matrix[1][2]}\t" +
                   $"|\t{equation.Matrix[1][3]}\t| -->\n";
            richTextBox1.Text += text;
            text = $"|\t{equation.Matrix[2][0]}" +
                   $"\t{equation.Matrix[2][1]}" +
                   $"\t{equation.Matrix[2][2]}\t" +
                   $"|\t{equation.Matrix[2][3]}\t|\n\n";
            richTextBox1.Text += text;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(null, "Helper.chm");
        }

    }
}
