using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork.Component;
using CourseWork.Extension;

namespace CourseWork.Model
{
    class EquationsSystem
    {
        public EquationsSystem(List<List<double>> matrix)
        {
            Matrix = matrix;
        }

        public List<List<double>> Matrix { get; }

        public EquationResult SolveGauss()
        {
            FirstTransformation();
            StairsTransformation();
            return new EquationResult(1, 2, 3);
        }

        public void FirstTransformation()
        {
            int i = 0;
            foreach (var line in Matrix)
            {
                if (line[0] == 1)
                {
                    Matrix.Swap(i, 0);
                    break;
                }

                i++;
            }
        }

        public void StairsTransformation()
        {
            int lines = Matrix.Count();
            int counter = 1;
            int subCounter = counter + 1;
            while (subCounter <= lines)
            {
                GettingZero(counter);
                counter++;
                if (counter >= lines)
                {
                    counter = subCounter;
                    subCounter++;
                }
            }
        }

        private void GettingZero(int secondLine)
        {
            if (secondLine <= 0)
            {
                return;
            }

            int nullLocation = 0;
            foreach (var number in Matrix[secondLine])
            {
                if (number != 0)
                {
                    return;
                }

                nullLocation++;
            }

            int firstLine = 0;
            foreach (var line in Matrix)
            {
                if (line[nullLocation] == 0)
                {
                    return;
                }

                firstLine++;
            }

            double factor = -Matrix[secondLine][nullLocation] / Matrix[firstLine][nullLocation];
            AppendLines(firstLine, secondLine, factor);
        }

        private void AppendLines(int firstLine, int secondLine, double factor)
        {
            for (var i = 0; i < Matrix[0].Count; i++)
            {
                Matrix[secondLine][i] = Matrix[firstLine][i] * factor;
            }
        }
    }
}
