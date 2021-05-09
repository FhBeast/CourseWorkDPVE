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
        public EquationResult Result { get; } = new EquationResult();

        public EquationResult SolveGauss()
        {
            FirstTransformation();
            StairsTransformation();
            InverseGauss();
            return Result;
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

        public void InverseGauss()
        {
            Result.Z = Matrix[2][3] / Matrix[2][2];
            Result.Y = (Matrix[1][3] - (Result.Z * Matrix[1][2])) / Matrix[1][1];
            Result.X = (Matrix[0][3] - (Result.Z * Matrix[0][2]) - (Result.Y * Matrix[0][1])) / Matrix[0][0];
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
                    break;
                }

                nullLocation++;
            }

            int firstLine = nullLocation;

            double factor = -Matrix[secondLine][nullLocation] / Matrix[firstLine][nullLocation];
            AppendLines(firstLine, secondLine, factor);
        }

        private void AppendLines(int firstLine, int secondLine, double factor)
        {
            for (var i = 0; i < Matrix[0].Count; i++)
            {
                Matrix[secondLine][i] += Matrix[firstLine][i] * factor;
            }
        }
    }
}
