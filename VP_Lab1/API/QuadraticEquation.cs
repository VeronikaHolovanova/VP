using System;

namespace QuadraticEquationSolver
{
    public class QuadraticEquation
    {
        public decimal QuadraticCoefficient { get; set; }
        public decimal LinearCoefficient { get; set; }
        public decimal Constant { get; set; }

        public decimal Discriminant 
        {
            get
            {
                return LinearCoefficient * LinearCoefficient - 4 * QuadraticCoefficient * Constant;
            }
        }
        public decimal DiscriminantSquareRoot 
        {
            get
            {
                return Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(Math.Abs(Discriminant))));
            }
        }

        public QuadraticEquationRoot FirstRoot 
        {
            get
            {
                if (Discriminant >= 0)
                {
                    QuadraticEquationRealRoot realRoot = new QuadraticEquationRealRoot(
                        x: (-LinearCoefficient - DiscriminantSquareRoot) / 2 * QuadraticCoefficient);
                    return realRoot;
                }
                else
                {
                    QuadraticEquationComplexRoot complexRoot = new QuadraticEquationComplexRoot(
                        x: -LinearCoefficient / (2 * QuadraticCoefficient),
                        y: DiscriminantSquareRoot / (2 * QuadraticCoefficient));
                    return complexRoot;
                }
            }
        }
        public QuadraticEquationRoot SecondRoot
        {
            get
            {
                if (Discriminant >= 0)
                {
                    QuadraticEquationRealRoot realRoot = new QuadraticEquationRealRoot(
                        x: (-LinearCoefficient + DiscriminantSquareRoot) / 2 * QuadraticCoefficient);
                    return realRoot;
                }
                else
                {
                    QuadraticEquationComplexRoot complexRoot = new QuadraticEquationComplexRoot(
                        x: -LinearCoefficient / (2 * QuadraticCoefficient),
                        y: -DiscriminantSquareRoot / (2 * QuadraticCoefficient));
                    return complexRoot;
                }
            }
        }

        public QuadraticEquation(decimal a = 1, decimal b = 0, decimal c = 0)
        {
            if (a == 0)
            {
                throw new Exception("Quadratic coefficient must not be equal to 0, then the equation will be linear, not quadratic.");
            }
            else
            {
                QuadraticCoefficient = a;
                LinearCoefficient = b;
                Constant = c;
            }
        }
    }
}
