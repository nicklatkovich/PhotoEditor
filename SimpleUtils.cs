using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public static List<byte> ToBytes(this Point point) {
            List<byte> result = new List<byte>( );
            result.AddRange(BitConverter.GetBytes(point.X));
            result.AddRange(BitConverter.GetBytes(point.Y));
            return result;
        }

    }
}
