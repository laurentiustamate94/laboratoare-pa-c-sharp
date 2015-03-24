using System;

namespace p3
{
    class Bill
    {
        const int MODULO = 9901;
        const int MAX_TERM = 19;

        public int N { get; private set; }
        public int R { get; private set; }

        public Bill(int N, int R)
        {
            this.N = N;
            this.R = R;
        }

        public int CountSolutions()
        {
            int[,] count = new int[N + 1, 100];

            /* TODO count[i][j] = cate sume exista care au i termeni
             * si care dau restul j la impartirea prin 100
             */

            for (int t = 0; t <= MAX_TERM; ++t)
            {
                // TODO Initializati linia 1 a dinamicii
            }


            /* TODO Calculati liniile 2..N ale dinamicii
             * Pentru a determina numarul de sume cu i termeni puteti considera ca
             * mai adaugati un termen la sumele care au (i - 1) termeni
             */

            for (int i = 2; i <= N; ++i)
            {

            }

            return count[N, R];
        }

        public int CountSolutionsLog()
        {
            int[,] matrix = new int[100, 100];
            int[] count = new int[100];

            /* TODO count[i] = cate sume cu un termen 
             * dau restul i la impartirea prin 100
             */

            for (int t = 0; t <= MAX_TERM; ++t)
            {

            }

            /* TODO Initializati matricea A
             * Hint: vreti ca (A * count) sa fie un vector in care elementul i sa
             * reprezinte numarul de moduri in care putem construi secvente cu N
             * termeni a caror suma sa dea restul i la impartirea prin 100
             */


            /* TODO Ridicati matricea A la putere folosind functia logPowMatrix
             * Faceti acest lucru dupa ce ati completat functia logPowMatrix
             */


            count = MultiplyMatrixVector(matrix, count);

            return count[R];
        }

        private int[,] PowMatrixLog(int[,] matrix, int p)
        {
            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(0)];

            for (int i = 0; i < result.Length; ++i)
                result[i, i] = 1;


            /* TODO Caculati result = PowMatrixLog(matrix, p) */


            return result;
        }

        private int[] MultiplyMatrixVector(int[,] matrix, int[] vector)
        {
            int[] result = new int[matrix.Length];

            for (int i = 0; i < matrix.GetLength(0); ++i)
                for (int j = 0; j < vector.Length; ++j)
                    result[i] = (result[i] + matrix[i, j] * vector[j]) % MODULO;

            return result;
        }

        private int[,] MultiplyMatrix(int[,] first, int[,] second)
        {
            int[,] result = new int[first.GetLength(0), second.GetLength(0)];

            for (int i = 0; i < first.GetLength(0); ++i)
                for (int j = 0; j < second.GetLength(0); ++j)
                    for (int k = 0; k < first.GetLength(0); ++k)
                        result[i, j] = (result[i, j] + first[i, k] * second[k, j]) % MODULO;

            return result;
        }
    }
}
