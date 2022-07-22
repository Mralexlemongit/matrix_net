using NUnit.Framework;
using MatrixNS;
using System;

namespace MatrixTest
{
    public class MatrixTest
    {
        [Test]
        public void ConstructorThrowInvalidNumColumnException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => {
                new Matrix(new int[,] { });
            } );
        }

        [Test]
        public void ConstructorThrowInvalidNumRowException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => {
                new Matrix(new int[,] { { }, { } });
            });
        }

        [Test, TestCaseSource("EqualCases")]
        public void EqualTrue(Matrix expect, Matrix actual)
        {
            Assert.IsTrue(expect == actual, "Matrix must be equal");
            Assert.AreEqual(expect, actual, "Matrix must be equal"); 
        }

        [Test, TestCaseSource("NotEqualCases"), TestCaseSource("DiferentShapeCases") ]
        public void EqualFalse(Matrix first, Matrix second)
        {
            Assert.IsFalse(first == second, "Matrix must be diferent");
            Assert.AreNotEqual(first, second, "Matrix must be diferent");
        }

        [Test, TestCaseSource("SumCases")]
        public void SumSuccessful(Matrix first, Matrix second, Matrix expect)
        {
            Matrix actual = first + second;
            Assert.AreEqual(expect, actual, "Matrix must be equal");
        }

        [Test, TestCaseSource("DiferentShapeCases")]
        public void SumThrowDiferentDimentionsException(Matrix first, Matrix second)
        {
            var ex = Assert.Throws<Exception>(() => {
                Matrix result = first + second;
            });
        }

        [Test, TestCaseSource("SubstractionCases")]
        public void SubstractionSuccessful(Matrix first, Matrix second, Matrix expect)
        {
            Matrix actual = first - second;
            Assert.AreEqual(expect, actual, "Matrix must be equal");
        }

        [Test, TestCaseSource("DiferentShapeCases")]
        public void SubstractionThrowDiferentDimentionsException(Matrix first, Matrix second)
        {
            var ex = Assert.Throws<Exception>(() => {
                Matrix result = first - second;
            });
        }

        [Test, TestCaseSource("ProductCases")]
        public void ProductSuccessful(Matrix first, Matrix second, Matrix expect)
        {
            Matrix actual = first * second;
            Assert.AreEqual(expect, actual, "Matrix must be equal");
        }

        [Test, TestCaseSource("NoMultiplicableDimensionsCases")]
        public void ProductThrowDiferentDimentionsException(Matrix first, Matrix second)
        {
            var ex = Assert.Throws<Exception>(() => {
                Matrix result = first * second;
            });
        }

        //division
        //eception para division
        //producto escalar

        /*** CASOS DE PRUEBA ***/

        static object[] EqualCases =
        {
            new object[] {
                new Matrix(new int[,] { { 1, 2 }, { 3, 5 } }),
                new Matrix(new int[,] { { 1, 2 }, { 3, 5 } })
            },
            new object[] {
                new Matrix(new int[,] { { 1 } }),
                new Matrix(new int[,] { { 1 } })
            },
            new object[] {
                new Matrix(new int[,] { { 1 }, { 5 }, { 4 } }),
                new Matrix(new int[,] { { 1 }, { 5 }, { 4 } })
            },
            new object[] {
                new Matrix(new int[,] { { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, } }),
                new Matrix(new int[,] { { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, } })
            },
        };

        static object[] DiferentShapeCases =
        {
            new object[] {
                new Matrix(new int[,] { { 1, 5, 4 } }),
                new Matrix(new int[,] { { 1 }, { 5 }, { 4 } })
            },
            new object[] {
                new Matrix(new int[,] { { 1 }, { 5 }, { 4 } }),
                new Matrix(new int[,] { { 1 } })
            },
        };

        static object[] NotEqualCases =
        {
            new object[] {
                new Matrix(new int[,] { { 1, 2 }, { 3, 5 } }),
                new Matrix(new int[,] { { 1, 2 }, { 3, 4 } })
            },
            new object[] {
                new Matrix(new int[,] { { 1 } }),
                new Matrix(new int[,] { { 2 } })
            },
        };

        static object[] SumCases =
        {
            new object[] {
                new Matrix(new int[,] { { 1, 2 }, { 3, 5 } }),
                new Matrix(new int[,] { { 1, 2 }, { 3, 4 } }),
                new Matrix(new int[,] { { 2, 4 }, { 6, 9 } })
            },
            new object[] {
                new Matrix(new int[,] { { 1 }, { 5 }, { 4 } }),
                new Matrix(new int[,] { { 1 }, { 5 }, { 0 } }),
                new Matrix(new int[,] { { 2 }, { 10 }, { 4 } }),
            },
            new object[] {
                new Matrix(new int[,] { { 1 } }),
                new Matrix(new int[,] { { 2 } }),
                new Matrix(new int[,] { { 3 } })
            },
        };

        static object[] SubstractionCases =
        {
            new object[] {
                new Matrix(new int[,] { { 1, 2 }, { 3, 5 } }),
                new Matrix(new int[,] { { 1, 2 }, { 3, 6 } }),
                new Matrix(new int[,] { { 0, 0 }, { 0, -1 } })
            },
            new object[] {
                new Matrix(new int[,] { { 2 }, { 5 }, { 0 } }),
                new Matrix(new int[,] { { 1 }, { 5 }, { 4 } }),
                new Matrix(new int[,] { { 1 }, { 0 }, { -4 } }),
            },
            new object[] {
                new Matrix(new int[,] { { 1 } }),
                new Matrix(new int[,] { { 2 } }),
                new Matrix(new int[,] { { -1 } })
            },
        };

        static object[] ProductCases =
        {
            new object[] {
                new Matrix(new int[,] { { 1 } }),
                new Matrix(new int[,] { { 1 } }),
                new Matrix(new int[,] { { 1 } })
            },
            new object[] {
                new Matrix(new int[,] { { 0 } }),
                new Matrix(new int[,] { { 0 } }),
                new Matrix(new int[,] { { 0 } })
            },
            new object[] {
                new Matrix(new int[,] { { 2 } }),
                new Matrix(new int[,] { { 2 } }),
                new Matrix(new int[,] { { 4 } })
            },
            new object[] {
                new Matrix(new int[,] { { 1, 1, 1 } }),
                new Matrix(new int[,] { { 1 }, { 1 }, { 1 }, }),
                new Matrix(new int[,] { { 3 } })
            },
            new object[] {
                new Matrix(new int[,] { { 1 }, { 1 }, { 1 }, }),
                new Matrix(new int[,] { { 1, 1, 1 } }),
                new Matrix(new int[,] { { 1, 1, 1 } ,{ 1, 1, 1 } ,{ 1, 1, 1 }  })
            },
        };

        static object[] NoMultiplicableDimensionsCases =
        {
            new object[] {
                new Matrix(new int[,] { { 1, 1, 1, 1 } }),      //1X4
                new Matrix(new int[,] { { 1 }, { 1 }, { 1 }, }) //3x1
            },
        };

    }
}