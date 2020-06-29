using System;
using System.Numerics;

namespace Enderlook.Numerics
{
    public readonly partial struct BigRational
    {
        /// <summary>
        /// Gets the absolute value of a <paramref name="value"/>.
        /// </summary>
        /// <param name="value">A number.</param>
        /// <returns>Absolute value of <paramref name="value"/>.</returns>
        public static BigRational Abs(BigRational value)
            => new BigRational(BigInteger.Abs(value.Numerator), BigInteger.Abs(value.Denominator));

        /// <summary>
        /// Raises <paramref name="value"/> to the power specified by <paramref name="exponent"/>.
        /// </summary>
        /// <param name="value">Number to raise.</param>
        /// <param name="exponent">Exponent to raise by.</param>
        /// <returns>Result of raising <paramref name="value"/> to the <paramref name="exponent"/> power.</returns>
        public static BigRational Pow(BigRational value, int exponent)
        {
            if (exponent > 0)
                return new BigRational(BigInteger.Pow(value.Numerator, exponent), BigInteger.Pow(value.Denominator, exponent));
            if (exponent < 0)
            {
                int exp = Math.Abs(exponent);
                return new BigRational(BigInteger.Pow(value.Denominator, exp), BigInteger.Pow(value.Numerator, exp));
            }

            return One;
        }

        /// <summary>
        /// Returns the base 10 logarithm of a specified number.
        /// </summary>
        /// <param name="value">Number whose logarithm is to be found.</param>
        /// <returns>The base 10 logarithm of <paramref name="value"/>.</returns>
        public static double Log10(BigRational value) => BigInteger.Log10(value.Numerator) - BigInteger.Log10(value.Denominator);

        /// <summary>
        /// Returns the natural logarithm of a specified number.
        /// </summary>
        /// <param name="value">Number whose logarithm is to be found.</param>
        /// <returns>The natural logarithm of <paramref name="value"/>.</returns>
        public static double Log(BigRational value) => BigInteger.Log(value.Numerator) - BigInteger.Log(value.Denominator);

        /// <summary>
        /// Returns the base <paramref name="base"/> logarithm of a specified number.
        /// </summary>
        /// <param name="value">Number whose logarithm is to be found.</param>
        /// <param name="base">Base of the logarithm.</param>
        /// <returns>The base <paramref name="base"/> logarithm of <paramref name="value"/>.</returns>
        public static double Log(BigRational value, double @base) => BigInteger.Log(value.Numerator, @base) - BigInteger.Log(value.Denominator, @base);
    }
}
