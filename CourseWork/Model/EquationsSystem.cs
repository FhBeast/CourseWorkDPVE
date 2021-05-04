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
        private readonly List<List<double>> _originMatrix;

        public EquationsSystem(List<List<double>> matrix)
        {
            _originMatrix = matrix;
            MatrixEdit = matrix;
        }

        public List<List<double>> MatrixEdit { get; }

        public EquationResult SolveGauss()
        {
            return new EquationResult(1, 2, 3);
        }

        public void FirstTransformation()
        {
            var i = 0;
            foreach (var line in _originMatrix)
            {
                if (line[0] == 1)
                {
                    MatrixEdit.Swap(i, 0);
                }
                i++;
            }
        }
    }
}
