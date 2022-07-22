using System;
using Newtonsoft.Json;

namespace MatrixNS
{
    public class Matrix
    {
        public int[,] data;
        public int numColumns;
        public int numRows;

        private Matrix() { }

        public Matrix(int[,] dataInput)
        {
            numRows = dataInput.GetLength(0);
            if (numRows <= 0) 
                throw new ArgumentOutOfRangeException("Bad number of Rows");

            numColumns = dataInput.GetLength(1); 
            if (numColumns <= 0) 
                throw new ArgumentOutOfRangeException("Bad number of Columns");
            data = dataInput.Clone() as int[,];
        }

        public override string ToString()
        {
            return "Matrix: "  + JsonConvert.SerializeObject(this.data);
        }

        public void set(int row, int col, int val)
        {
            this.data[row - 1, col - 1] = val;
        }

        public int get(int row, int col)
        {
            return this.data[row - 1, col - 1];
        }

        public bool HasSameDimensionsThan(Matrix b)
        {
            return numColumns == b.numColumns && numRows == b.numRows;
        }

        public bool HasMultiplicableDimensionsFor(Matrix b)
        {
            return numColumns == b.numRows;
        }

        public override int GetHashCode() { return 0; }
        public override bool Equals(object obj) 
        {
            var matrix = obj as Matrix;
            return this == matrix;
        }

        public static Boolean operator ==(Matrix first, Matrix second)
        {
            if (!first.HasSameDimensionsThan(second)) return false;

            for (int r = 1; r <= first.numRows; r++)
                for (int c = 1; c <= first.numColumns; c++ )
                    if (first.get(r, c) != second.get(r, c)) return false;

            return true;
        }

        public static Boolean operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }

        public static Matrix operator +(Matrix first, Matrix second)
        {
            if (!first.HasSameDimensionsThan(second))
                throw new Exception("DiferentDimentionsException");

            Matrix result = new Matrix(new int[first.numRows, first.numColumns]);
            
           for (int r = 1; r <= first.numRows; r++)
                for (int c = 1; c <= first.numColumns; c++)
                    result.set(r, c, first.get(r, c) + second.get(r,c));

            return result;
        }

        public static Matrix operator -(Matrix first, Matrix second)
        {
            if (!first.HasSameDimensionsThan(second))
                throw new Exception("DiferentDimentionsException");

            Matrix result = new Matrix(new int[first.numRows, first.numColumns]);

            for (int c = 1; c <= first.numColumns; c++)
                for (int r = 1; r <= first.numRows; r++)
                    result.set(r, c, first.get(r, c) - second.get(r, c));

            return result;
        }

        public static Matrix operator *(Matrix first, Matrix second)
        {
            if (!first.HasMultiplicableDimensionsFor(second))
                throw new Exception("NoMultiplicableDimensionsException");

            Matrix result = new Matrix(new int[first.numRows, second.numColumns]);

            for (int r = 1; r <= first.numRows; r++)
                for (int c = 1; c <= second.numColumns; c++)
                {
                    int total = 0;
                    for (int i = 1; i <= first.numColumns; i++)
                        total += first.get(r, i) * second.get(i,c);
                    result.set(r, c, total);
                }

            return result;
        }

        public static void Main()
        {
            Fraction first = new Fraction(2,6);

            Console.WriteLine("Matrix master");
        }
    }
}
