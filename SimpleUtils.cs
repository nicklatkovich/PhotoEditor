using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEditor {
    public static class SimpleUtils {

        public static List<byte> ToBytes(this string str) {
            List<byte> result = new List<byte>( );
            result.AddRange(BitConverter.GetBytes(str.Length));
            for (uint i = 0; i < str.Length; i++) {
                char ch = str[(int)i];
                result.AddRange(BitConverter.GetBytes(ch));
            }
            return result;
        }

    }
}
