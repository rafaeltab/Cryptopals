using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafaeltab.Cryptopals.Set2.Common
{
    public static class Padding
    {
        public static byte[] PKCS7(byte[] data, int blockSize) {
            var padAmount = (int)(Math.Floor(blockSize/(double)data.Length)*blockSize - data.Length);
            if (padAmount == 0) return data;

            Array.Resize(ref data, data.Length + blockSize);

            for (int i = 0; i < padAmount; i++)
            {
                data[data.Length + i - blockSize] = 0x04;
            }

            return data;
        }
    }
}
