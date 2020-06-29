using System;
using System.Numerics;

namespace Enderlook.Numerics
{
    /// <summary>
    /// Immutable representation of a rational number of arbitrary length and precision.
    /// </summary>
    public readonly partial struct BigRational : IEquatable<BigRational>, IComparable<BigRational>
    {
        /// <summary>
        /// Gets the value that represents the number 1.
        /// </summary>
        public static readonly BigRational One = new BigRational(BigInteger.One, BigInteger.One);

        /// <summary>
        /// Gets the value that represents the number 0.
        /// </summary>
        public static readonly BigRational Zero = new BigRational(BigInteger.Zero, BigInteger.One);

        /// <summary>
        /// Numerator part.
        /// </summary>
        public readonly BigInteger Numerator;

        /// <summary>
        /// Denominator part.
        /// </summary>
        public readonly BigInteger Denominator;

        /// <summary>
        /// Recudes the fraction to its simplest form.
        /// </summary>
        public BigRational Reduced {
            get {
                if (Denominator == 1)
                    return this;
                BigInteger gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
                BigInteger numerator = Numerator / gcd;
                BigInteger denominator = Denominator / gcd;
                if (denominator < 0)
                {
                    denominator = BigInteger.Abs(denominator);
                    numerator *= -1;
                }
                return new BigRational(numerator, denominator);
            }
        }

        /// <summary>
        /// <c><see cref="Numerator"/> / <see cref="Denominator"/></c>.
        /// </summary>
        public BigInteger Quotient => Numerator / Denominator;

        /// <summary>
        /// <c><see cref="Numerator"/> % <see cref="Denominator"/></c>.
        /// </summary>
        public BigInteger Remainder => Numerator % Denominator;

        /// <summary>
        /// Indicates if this number is an integer. Otherwise it's a real number.
        /// </summary>
        public bool IsInteger => Denominator.IsOne || BigInteger.Remainder(Numerator, Denominator).IsZero; 

        /// <summary>
        /// Indicates if this number is even.
        /// </summary>
        public bool IsEven {
            get {
                BigInteger result = BigInteger.DivRem(Numerator, Denominator, out BigInteger remainder);
                return remainder.IsZero && result.IsEven;
            }
        }

        /// <summary>
        /// Indicates if this number is zero.
        /// </summary>
        public bool IsZero => Numerator.IsZero;

        /// <summary>
        /// Indicates if this number is one.
        /// </summary>
        public bool IsOne => Numerator == Denominator;

        /// <summary>
        /// Indicates if this number is invalid (<see cref="Denominator"/> is <see cref="BigInteger.Zero"/>);
        /// </summary>
        public bool IsInvalid => Denominator == BigInteger.Zero;

        /// <summary>
        /// Compares <paramref name="other"/> with the current instance.
        /// </summary>
        /// <param name="other">Element to compare.</param>
        /// <returns>Comparison value.</returns>
        public int CompareTo(BigRational other)
        {
            BigInteger integer = BigInteger.DivRem(Numerator, Denominator, out BigInteger remainder);
            BigInteger otherInteger = BigInteger.DivRem(other.Numerator, other.Denominator, out BigInteger otherRemainder);

            int comparison = integer.CompareTo(otherInteger);
            if (comparison == 0)
                comparison = remainder.CompareTo(otherRemainder);
            return comparison;
        }

        /// <summary>
        /// Determines whenever the instance <paramref name="obj"/> is equals to the current instance.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="obj"/> and this instance are equal. Otherwise <see langword="false"/>.</returns>
        public override bool Equals(object obj) => obj is BigRational rational && Equals(rational);

        /// <inheritdoc cref="Equals(object)"/> 
        public bool Equals(BigRational other)
        {
            BigRational reduced = Reduced;
            other = other.Reduced;
            return reduced.Numerator == other.Numerator && reduced.Denominator == other.Denominator;
        }

        /// <summary>
        /// Produces the hash code of this instance.
        /// </summary>
        /// <returns>Hash value of this instance.</returns>
        public override int GetHashCode()
        {
            BigRational reduced = Reduced;
            return HashCode.Combine(reduced.Numerator, reduced.Denominator);
        }

        /// <summary>
        /// Produces an <see cref="string"/> representation of this instance as a fraction.
        /// </summary>
        /// <returns><see cref="string"/> representation of this instance.</returns>
        public string ToStringFraction()
        {
            BigRational reduced = Reduced;
            if (reduced.Denominator == 1)
                return reduced.Numerator.ToString();
            return $"{reduced.Numerator}/{reduced.Denominator}";
        }

        /// <summary>
        /// Produces an <see cref="string"/> representation of this instance as a mixed fraction.
        /// </summary>
        /// <returns><see cref="string"/> representation of this instance.</returns>
        public string ToStringMixedFraction()
        {
            BigRational reduced = Reduced;

            BigInteger quotient = reduced.Quotient;
            if (quotient == 0)
                return ToStringFraction();

            BigInteger remainder = reduced.Remainder;
            if (remainder == 0)
                return quotient.ToString();

            return $"{quotient} {reduced.Remainder}/{reduced.Denominator}";
        }

        /// <summary>
        /// Produces an <see cref="string"/> representation of this instance as a decimal.
        /// </summary>
        /// <returns><see cref="string"/> representation of this instance.</returns>
        public override string ToString()
        {
            BigRational reduced = Reduced;

            if (reduced.Numerator == BigInteger.Zero)
                return "0";

            BigInteger quotient = reduced.Quotient;
            if (quotient == 0)
                return $"0.{ExtractDecimal(((decimal)reduced.Numerator) / ((decimal)reduced.Denominator))}";

            BigInteger remainder = reduced.Remainder;
            if (remainder == 0)
                return quotient.ToString();

            return $"{quotient}.{ExtractDecimal(((decimal)reduced.Remainder) / ((decimal)reduced.Denominator))}";
        }

        private string ExtractDecimal(decimal number)
        {
            string text = number.ToString();
            for (int i = 0; i < text.Length; i++) {
                if (text[i] == '.')
                    return text.Substring(i + 1);
            }
            return text;
        }
    }
}
