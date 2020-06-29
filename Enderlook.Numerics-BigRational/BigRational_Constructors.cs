using System;
using System.Numerics;

namespace Enderlook.Numerics
{
    public readonly partial struct BigRational
    {
        private static readonly BigInteger ten = new BigInteger(10);

        /// <summary>
        /// Produces a representation of a rational number of arbitrary length and precision.
        /// </summary>
        /// <param name="numerator">Numerator of this number.</param>
        /// <param name="denominator">Denominator of this number.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="denominator"/> is 0.</exception>
        public BigRational(BigInteger numerator, BigInteger denominator)
        {
            if (denominator == 0) throw new ArgumentOutOfRangeException(nameof(denominator), denominator, "Can't be 0.");
            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Produces a representation of a rational number of arbitrary length and precision.
        /// </summary>
        /// <param name="value">Numerator of this number.</param>
        public BigRational(BigInteger value)
        {
            Numerator = value;
            Denominator = BigInteger.One;
        }

        /// <inheritdoc cref="BigRational(BigInteger)"/>
        public BigRational(int value) : this(new BigInteger(value)) { }

        /// <inheritdoc cref="BigRational(BigInteger)"/>
        public BigRational(uint value) : this(new BigInteger(value)) { }

        /// <inheritdoc cref="BigRational(BigInteger)"/>
        public BigRational(byte value) : this(new BigInteger(value)) { }

        /// <inheritdoc cref="BigRational(BigInteger)"/>
        public BigRational(sbyte value) : this(new BigInteger(value)) { }

        /// <inheritdoc cref="BigRational(BigInteger)"/>
        public BigRational(short value) : this(new BigInteger(value)) { }

        /// <inheritdoc cref="BigRational(BigInteger)"/>
        public BigRational(ushort value) : this(new BigInteger(value)) { }

        /// <inheritdoc cref="BigRational(BigInteger)"/>
        public BigRational(long value) : this(new BigInteger(value)) { }

        /// <inheritdoc cref="BigRational(BigInteger)"/>
        public BigRational(ulong value) : this(new BigInteger(value)) { }

        /// <inheritdoc cref="BigRational(BigInteger)"/>
        public BigRational(decimal value)
        {
            if (value == 0)
            {
                Numerator = BigInteger.Zero;
                Denominator = BigInteger.One;
            }

            int sign = Math.Sign(value);
            value = Math.Abs(value);
            BigInteger numerator = new BigInteger(value);
            BigInteger denominator = BigInteger.One;

            while (true)
            {
                value = (value - Math.Floor(value)) * 10;
                if (value == 0)
                    break;
                numerator *= ten;
                numerator += new BigInteger(value);
                denominator *= ten;
            }

            numerator *= sign;

            BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);

            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        /// <inheritdoc cref="BigRational(BigInteger)"/>
        public BigRational(double value)
        {
            if (value == 0)
            {
                Numerator = BigInteger.Zero;
                Denominator = BigInteger.One;
            }

            int sign = Math.Sign(value);
            value = Math.Abs(value);
            BigInteger numerator = new BigInteger(value);
            BigInteger denominator = BigInteger.One;

            while (true)
            {
                value = (value - Math.Floor(value)) * 10;
                if (value == 0)
                    break;
                numerator *= ten;
                numerator += new BigInteger(value);
                denominator *= ten;
            }

            numerator *= sign;

            BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);

            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        /// <inheritdoc cref="BigRational(BigInteger)"/>
        public BigRational(float value)
        {
            if (value == 0)
            {
                Numerator = BigInteger.Zero;
                Denominator = BigInteger.One;
            }

            int sign = Math.Sign(value);
            value = Math.Abs(value);
            BigInteger numerator = new BigInteger(value);
            BigInteger denominator = BigInteger.One;

            while (true)
            {
                // TODO: Use with Mathf instead of Math
                value = (value - (float)Math.Floor(value)) * 10;
                if (value == 0)
                    break;
                numerator *= ten;
                numerator += new BigInteger(value);
                denominator *= ten;
            }

            numerator *= sign;

            BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);

            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        /// <summary>
        /// Produces a representation of a rational number of arbitrary length and precision from an integer number and a fraction.
        /// </summary>
        /// <param name="integer">Integer of the mixed fraction.</param>
        /// <param name="numerator">Numerator of the mixed fraction.</param>
        /// <param name="denominator">Denominator of the mixed fraction.</param>
        public BigRational(BigInteger integer, BigInteger numerator, BigInteger denominator)
        {
            Numerator = integer * denominator + numerator;
            Denominator = BigInteger.One;
        }

        /// <inheritdoc cref="BigRational(BigInteger, BigInteger, BigInteger)"/>
        public BigRational(int integer, int numerator, int denominator)
            : this(new BigInteger(integer), new BigInteger(numerator), new BigInteger(denominator)) { }

        /// <inheritdoc cref="BigRational(BigInteger, BigInteger, BigInteger)"/>
        public BigRational(uint integer, uint numerator, uint denominator)
            : this(new BigInteger(integer), new BigInteger(numerator), new BigInteger(denominator)) { }

        /// <inheritdoc cref="BigRational(BigInteger, BigInteger, BigInteger)"/>
        public BigRational(byte integer, byte numerator, byte denominator)
            : this(new BigInteger(integer), new BigInteger(numerator), new BigInteger(denominator)) { }

        /// <inheritdoc cref="BigRational(BigInteger, BigInteger, BigInteger)"/>
        public BigRational(sbyte integer, sbyte numerator, sbyte denominator)
            : this(new BigInteger(integer), new BigInteger(numerator), new BigInteger(denominator)) { }

        /// <inheritdoc cref="BigRational(BigInteger, BigInteger, BigInteger)"/>
        public BigRational(short integer, short numerator, short denominator)
            : this(new BigInteger(integer), new BigInteger(numerator), new BigInteger(denominator)) { }

        /// <inheritdoc cref="BigRational(BigInteger, BigInteger, BigInteger)"/>
        public BigRational(ushort integer, ushort numerator, ushort denominator)
            : this(new BigInteger(integer), new BigInteger(numerator), new BigInteger(denominator)) { }

        /// <inheritdoc cref="BigRational(BigInteger, BigInteger, BigInteger)"/>
        public BigRational(long integer, long numerator, long denominator)
            : this(new BigInteger(integer), new BigInteger(numerator), new BigInteger(denominator)) { }

        /// <inheritdoc cref="BigRational(BigInteger, BigInteger, BigInteger)"/>
        public BigRational(ulong integer, ulong numerator, ulong denominator)
            : this(new BigInteger(integer), new BigInteger(numerator), new BigInteger(denominator)) { }
    }
}
