using NUnit.Framework;
using MatrixNS;

namespace MatrixTest
{
    public class FractionTest
    {
        [Test, TestCaseSource("EqualCases")]
        public void EqualTrue(Fraction expected, Fraction actual)
        {
            Assert.IsTrue(expected == actual, "Must be same fraction");
            Assert.AreEqual(expected, actual, "Must be same fraction");
        }

        [Test, TestCaseSource("SumCases")]
        public void SumSuccessful(Fraction first, Fraction second, Fraction expected)
        {
            Fraction actual = first + second;
            Assert.AreEqual(expected, actual);
        }

        static object[] SumCases =
        {
            new object[] {
                new Fraction(1),
                new Fraction(1,3),
                new Fraction(4,3),
            },
            new object[] {
                new Fraction(-1),
                new Fraction(1,3),
                new Fraction(-2,3),
            },
            new object[] {
                new Fraction(0),
                new Fraction(1,3),
                new Fraction(1,3),
            },
            new object[] {
                new Fraction(4,3),
                new Fraction(2,3),
                new Fraction(2),
            },
        };

        static object[] EqualCases =
        {
            new object[] {
                new Fraction(1),
                new Fraction(1,1),
            },
            new object[] {
                new Fraction(-1,3),
                new Fraction(1,-3),
            },
            new object[] {
                new Fraction(0),
                new Fraction(0,3),
            },
            new object[] {
                new Fraction(1,2),
                new Fraction(2,4),
            },
        };
    }
}
