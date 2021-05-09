namespace CourseWork.Component
{
    public class EquationResult
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public EquationResult()
        {
        }

        public EquationResult(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
