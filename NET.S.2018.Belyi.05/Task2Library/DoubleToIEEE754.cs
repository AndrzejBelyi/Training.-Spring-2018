using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task2Library
{
    public static class DoubleToIEEE754
    {
        public static string DoubleTo64BinaryString(this double number)
        {
            DoubleToLongStruct bytes = new DoubleToLongStruct();
            bytes.Double64bits = number;
            string binaryString = string.Empty;
            long bits = bytes.Long64bits;
            for (int n = 0; n < 64; n++)
            {
                if ((bits & 1) == 1)
                {
                    binaryString += "1";
                }
                else
                {
                    binaryString += "0";
                }

                bits >>= 1;
            }

           return new string(binaryString.Reverse().ToArray());
        }

        /// <summary>
        /// Struct which gives bytes of number
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            private readonly long long64bits;

            [FieldOffset(0)]
            private double double64bits;

            public double Double64bits
            {
                set
                {
                    double64bits = value;
                }
            }
        
            public long Long64bits
            {
                get
                {
                    return long64bits;
                }
            }
        }
    }
}
