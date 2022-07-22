using System;

namespace MatrixNS
{
    public class Fraction
    {
        public int numerator;
        public int denominator;

        private Fraction() { }

        public Fraction(int numeratorInput, int denominatorInput)
        {
            numerator = numeratorInput;
            denominator = denominatorInput;
            this.Simplify();
        }

        public Fraction(int numeratorInput)
        {
            numerator = numeratorInput;
            denominator = 1;
        }

        public int GetGreatestCommonDivisor(int a, int b)
        {
            if (b == 0) return a;
            return this.GetGreatestCommonDivisor(b, a % b);
        }

        public void Simplify()
        {
            int greatestCommonDivisor = this.GetGreatestCommonDivisor(this.numerator, this.denominator);
            this.numerator /= greatestCommonDivisor;
            this.denominator /= greatestCommonDivisor;
        }
        
        public override bool Equals(object obj)
        {
            var fraction = obj as Fraction;
            return this == fraction;
        }

        public override string ToString()
        {
            if (this.denominator == 1 ) 
                return this.numerator.ToString();
            return this.numerator.ToString() + "/" + this.denominator.ToString();
        }

        public static bool operator ==(Fraction first, Fraction second)
        {
            return first.numerator * second.denominator == first.denominator * second.numerator;
        }

        public static bool operator !=(Fraction first, Fraction second)
        {
            return !(first==second);
        }

        public static Fraction operator +(Fraction first, Fraction second)
        {
            int numerator = first.numerator * second.denominator + first.denominator * second.numerator;
            int denominator = first.denominator * second.denominator;
            Fraction result = new Fraction(numerator, denominator);
            return result;
        }
    }
}
