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
            
        }
    }
}
