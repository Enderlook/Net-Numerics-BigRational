using Enderlook.Numerics;

using System;
using System.Text;

using Xunit;

namespace Enderlook.Numerics_BicgRation_Test
{
    public class BigRationalTest
    {
        [Fact]
        public void Conversions()
        {
            Random random = new Random(0);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 100000; i++)
            {
                builder.Clear();
                builder.Append(random.Next());
                builder.Append(".");
                builder.Append(random.Next());

                decimal m = decimal.Parse(builder.ToString());
                BigRational number = m;
                Assert.True(number == m);

                double d = random.NextDouble();
                number = d;
                Assert.True(number == d);

                float f = (float)random.NextDouble();
                number = f;
                Assert.True(number == f);

                long i64 = (long)random.Next() + random.Next();
                number = i64;
                Assert.True(number == i64);
                    
                int i32 = random.Next();
                number = i32;
                Assert.True(number == i32);

                short i16 = unchecked((short)random.Next());
                number = i16;
                Assert.True(number == i16);

                byte u8 = unchecked((byte)random.Next());
                number = u8;
                Assert.True(number == u8);

                ulong u64 = unchecked((ulong)i64);
                number = u64;
                Assert.True(number == u64);

                uint u32 = unchecked((uint)i32);
                number = u32;
                Assert.True(number == u32);

                ushort u16 = unchecked((ushort)i16);
                number = u16;
                Assert.True(number == u16);

                sbyte i8 = unchecked((sbyte)u8);
                number = i8;
                Assert.True(number == i8);
            }
        }
    }
}
