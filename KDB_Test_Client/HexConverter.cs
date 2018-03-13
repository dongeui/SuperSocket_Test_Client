using System;
using System.Linq;
using System.Text;

namespace Kdb.Util
{
    public static class HexConverter
    {
        public static byte[] ToHexBytes(this string message)
        {
            return Enumerable.Range(0, message.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(message.Substring(x, 2), 16))
                    .ToArray();
        }
        public static string ToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }


    }
}
