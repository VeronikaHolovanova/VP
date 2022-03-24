
namespace QuadraticEquationSolver
{
    public abstract class QuadraticEquationRoot
    {
        public decimal RealPart { get; set; }
        public decimal ImaginaryPart { get; set; }
        
        public QuadraticEquationRoot(decimal x = 0, decimal y = 0)
        {
            RealPart = x;
            ImaginaryPart = y;
        }
    }

    public class QuadraticEquationRealRoot : QuadraticEquationRoot
    {
        public QuadraticEquationRealRoot(decimal x = 0) : base(x, 0) {}
    }

    public class QuadraticEquationComplexRoot : QuadraticEquationRoot
    {
        public QuadraticEquationComplexRoot(decimal x, decimal y) : base(x, y) {}
    }
}
