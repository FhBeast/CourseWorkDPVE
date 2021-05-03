using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Utils
{
    static class FormatChanger
    {
        public static string ToEquationForm(double number)
        {
            string str;
            if (number >= 0)
            {
                str = String.Format("+ {0}", number);
            }
            else
            {
                str = String.Format("- {0}", -number);
            }
            return str;
        }
    }
}
