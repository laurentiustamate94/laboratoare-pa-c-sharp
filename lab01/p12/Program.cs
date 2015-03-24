using System;

namespace p12
{
    class Program
    {
        static void Main(string[] args)
        {
            /* TODO Calculati radicalul pentru trei valori alese de voi,
             * folosind functia sqrt definita mai jos. Cel putin o valoare
             * trebuie sa fie subunitara. Precizia va fi de 0.001
             *
             * Decideti care va fi valoarea upper folosita.
             * Hint: ce se intampla cand x < 1 ?
             */
        }

        static bool Equal(double x, double y, double precision)
        {
            return Math.Abs(x - y) < precision;
        }

        static double Sqrt(double x, double lower, double upper, double precision)
        {
            /* TODO Cautati intre lower si upper o valoare care ridicata
             * la patrat sa dea x.
             * La calcularea pozitiei de mijloc folositi
             *       double m = lower + (upper - lower) / 2;
             * pentru a evita overflow la adunarea pe double
             * Folositi functia equal pentru a verifica cu aproximare egalitatea
             */

            return 0;
        }
    }
}
