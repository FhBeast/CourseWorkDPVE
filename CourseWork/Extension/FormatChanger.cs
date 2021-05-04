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
