using System.Numerics;

namespace Enderlook.Numerics
{
    public readonly partial struct BigRational
    {
        /// <summary>
        /// Converts <paramref name="value"/> into a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        public static implicit operator BigRational(int value) => new BigRational(value);

        /// <inheritdoc cref="op_Implicit(int)"/>
        public static implicit operator BigRational(uint value) => new BigRational(value);

        /// <inheritdoc cref="op_Implicit(int)"/>
        public static implicit operator BigRational(byte value) => new BigRational(value);

        /// <inheritdoc cref="op_Implicit(int)"/>
        public static implicit operator BigRational(sbyte value) => new BigRational(value);

        /// <inheritdoc cref="op_Implicit(int)"/>
        public static implicit operator BigRational(short value) => new BigRational(value);

        /// <inheritdoc cref="op_Implicit(int)"/>
        public static implicit operator BigRational(ushort value) => new BigRational(value);

        /// <inheritdoc cref="op_Implicit(int)"/>
        public static implicit operator BigRational(long value) => new BigRational(value);

        /// <inheritdoc cref="op_Implicit(int)"/>
        public static implicit operator BigRational(ulong value) => new BigRational(value);

        /// <inheritdoc cref="op_Implicit(int)"/>
        public static implicit operator BigRational(BigInteger value) => new BigRational(value);

        /// <inheritdoc cref="op_Implicit(int)"/>
        public static implicit operator BigRational(decimal value) => new BigRational(value);

        /// <inheritdoc cref="op_Implicit(int)"/>
        public static implicit operator BigRational(double value) => new BigRational(value);

        /// <inheritdoc cref="op_Implicit(int)"/>
        public static implicit operator BigRational(float value) => new BigRational(value);

        /// <summary>
        /// Converts <paramref name="value"/> into <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        public static explicit operator decimal(BigRational value)
        {
            BigRational reduced = value.Reduced;
            return (decimal)reduced.Quotient + (((decimal)reduced.Remainder) / ((decimal)reduced.Numerator));
        }

        /// <summary>
        /// Converts <paramref name="value"/> into <see cref="double"/>.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        public static explicit operator double(BigRational value) => (double)(decimal)value;

        /// <summary>
        /// Converts <paramref name="value"/> into <see cref="float"/>.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        public static explicit operator float(BigRational value) => (float)(decimal)value;

        /// <summary>
        /// Converts <paramref name="value"/> into <see cref="long"/>.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        public static explicit operator long(BigRational value) => (long)value.Quotient;

        /// <summary>
        /// Converts <paramref name="value"/> into <see cref="long"/>.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        public static explicit operator int(BigRational value) => (int)value.Quotient;

        /// <summary>
        /// Converts <paramref name="value"/> into <see cref="long"/>.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        public static explicit operator short(BigRational value) => (short)value.Quotient;

        /// <summary>
        /// Converts <paramref name="value"/> into <see cref="byte"/>.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        public static explicit operator byte(BigRational value) => (byte)value.Quotient;
    }
}
