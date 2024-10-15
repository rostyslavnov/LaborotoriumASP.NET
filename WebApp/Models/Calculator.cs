using System;

namespace WebApp.Models
{
    public class Calculator
    {
        public Operators? op { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }

        public string Op
        {
            get
            {
                switch (op)
                {
                    case Operators.Add:
                        return "+";
                    case Operators.Sub:
                        return "-";
                    case Operators.Mul:
                        return "*";
                    case Operators.Div:
                        return "/";
                    case Operators.Pow:
                        return "^";
                    case Operators.Sin:
                        return "sin";
                    default:
                        return "";
                }
            }
        }

        public bool IsValid()
        {
            return op != null && X != null && (op != Operators.Sin ? Y != null : true);
        }

        public double Calculate()
        {
            switch (op)
            {
                case Operators.Add:
                    return (double)(X + Y);
                case Operators.Sub:
                    return (double)(X - Y);
                case Operators.Mul:
                    return (double)(X * Y);
                case Operators.Div:
                    if (Y == 0)
                    {
                        throw new DivideByZeroException("Nie można dzielić przez zero.");
                    }
                    return (double)(X / Y);
                case Operators.Pow:
                    return Math.Pow(X.Value, Y.Value);
                case Operators.Sin:
                    return Math.Sin(X.Value);
                default:
                    return double.NaN;
            }
        }
    }

    public enum Operators
    {
        Add, Sub, Mul, Div, Pow, Sin
    }
}
