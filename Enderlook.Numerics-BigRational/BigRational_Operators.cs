using System;
using System.Numerics;

namespace Enderlook.Numerics
{
    public readonly partial struct BigRational
    {
        /// <summary>
        /// Determines if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </summary>
        /// <param name="left">Element to compare.</param>
        /// <param name="right">Element to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are equal. Otherwise <see langword="false"/>.</returns>
        public static bool operator ==(BigRational left, BigRational right) => left.Equals(right);

        /// <summary>
        /// Determines if <paramref name="left"/> and <paramref name="right"/> are different.
        /// </summary>
        /// <param name="left">Element to compare.</param>
        /// <param name="right">Element to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are different. Otherwise <see langword="false"/>.</returns>
        public static bool operator !=(BigRational left, BigRational right) => !left.Equals(right);

        /// <summary>
        /// Determines if <paramref name="left"/> is greater than <paramref name="right"/>.
        /// </summary>
        /// <param name="left">Element to compare.</param>
        /// <param name="right">Element to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> is greater than <paramref name="right"/>. Otherwise <see langword="false"/>.</returns>
        public static bool operator >(BigRational left, BigRational right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Determines if <paramref name="left"/> is lesser than <paramref name="right"/>.
        /// </summary>
        /// <param name="left">Element to compare.</param>
        /// <param name="right">Element to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> is lesser than <paramref name="right"/>. Otherwise <see langword="false"/>.</returns>
        public static bool operator <(BigRational left, BigRational right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Determines if <paramref name="left"/> is greater or equal than <paramref name="right"/>.
        /// </summary>
        /// <param name="left">Element to compare.</param>
        /// <param name="right">Element to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> is greater or equal than <paramref name="right"/>. Otherwise <see langword="false"/>.</returns>
        public static bool operator >=(BigRational left, BigRational right) => left.CompareTo(right) >= 0;

        /// <summary>
        /// Determines if <paramref name="left"/> is lesser or equal than <paramref name="right"/>.
        /// </summary>
        /// <param name="left">Element to compare.</param>
        /// <param name="right">Element to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> is lesser or equal than <paramref name="right"/>. Otherwise <see langword="false"/>.</returns>
        public static bool operator <=(BigRational left, BigRational right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Does nothing
        /// </summary>
        /// <param name="value">Value to return</param>
        /// <returns><paramref name="value"/>.</returns>
        public static BigRational operator +(BigRational value) => value;

        /// <summary>
        /// Negates the value
        /// </summary>
        /// <param name="value">Value to negate.</param>
        /// <returns>Negated value.</returns>
        public static BigRational operator -(BigRational value) => new BigRational(-value.Numerator, value.Denominator);

        /// <summary>
        /// Adds of <paramref name="left"/> with <paramref name="right"/>.
        /// </summary>
        /// <param name="left">First operand.</param>
        /// <param name="right">Second operand.</param>
        /// <returns>Sum of <paramref name="left"/> and <paramref name="right"/>.</returns>
        public static BigRational operator +(BigRational left, BigRational right)
            => new BigRational(left.Numerator * right.Denominator + right.Numerator * left.Denominator, left.Denominator * right.Denominator);

        /// <summary>
        /// Substracts <paramref name="right"/> to <paramref name="left"/>.
        /// </summary>
        /// <param name="left">First operand.</param>
        /// <param name="right">Second operand.</param>
        /// <returns>Substraction of <paramref name="right"/> to <paramref name="left"/>.</returns>
        public static BigRational operator -(BigRational left, BigRational right)
            => new BigRational(left.Numerator * right.Denominator - right.Numerator * left.Denominator, left.Denominator * right.Denominator);

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>.
        /// </summary>
        /// <param name="left">First operand.</param>
        /// <param name="right">Second operand.</param>
        /// <returns>Multiplication of <paramref name="left"/> and <paramref name="right"/>.</returns>
        public static BigRational operator *(BigRational left, BigRational right)
            => new BigRational(left.Numerator * right.Numerator, left.Denominator * right.Denominator);

        /// <summary>
        /// Divides <paramref name="left"/> with <paramref name="right"/>.
        /// </summary>
        /// <param name="left">First operand.</param>
        /// <param name="right">Second operand.</param>
        /// <returns>Division of <paramref name="left"/> and <paramref name="right"/>.</returns>
        /// <exception cref="DivideByZeroException">Thrown when <c><paramref name="right"/>.<see cref="Numerator"/></c> is 0.</exception>
        public static BigRational operator /(BigRational left, BigRational right)
        {
            if (right.Numerator == BigInteger.Zero) throw new DivideByZeroException();
            return new BigRational(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
        }

        /// <summary>
        /// Increment by one.
        /// </summary>
        /// <param name="value">Operand to increment.</param>
        /// <returns><paramref name="value"/> incremented by one</returns>
        public static BigRational operator ++(BigRational value)
            => new BigRational(value.Numerator + value.Denominator, value.Denominator);

        /// <summary>
        /// Decrement by one.
        /// </summary>
        /// <param name="value">Operand to decrement.</param>
        /// <returns><paramref name="value"/> decremented by one</returns>
        public static BigRational operator --(BigRational value)
            => new BigRational(value.Numerator - value.Denominator, value.Denominator);

        /// <summary>
        /// Divides <paramref name="left"/> with <paramref name="right"/> and returns its module.
        /// </summary>
        /// <param name="left">First operand.</param>
        /// <param name="right">Second operand.</param>
        /// <returns>Module of division between <paramref name="left"/> and <paramref name="right"/>.</returns>
        /// <exception cref="DivideByZeroException">Thrown when <c><paramref name="right"/>.<see cref="Numerator"/></c> is 0.</exception>
        public static BigInteger operator %(BigRational left, BigRational right)
        {
            if (right.Numerator == BigInteger.Zero) throw new DivideByZeroException();
            return (left.Numerator * right.Denominator) % (left.Denominator * right.Numerator);
        }
    }
}
