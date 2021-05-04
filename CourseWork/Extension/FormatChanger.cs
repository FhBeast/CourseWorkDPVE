using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Extension
{
    static class FormatChanger
    {
        public static string ToEquationForm(this double number)
        {
            return number >= 0 ? $"+ {number}" : $"- {-number}";
        }
    }
}
