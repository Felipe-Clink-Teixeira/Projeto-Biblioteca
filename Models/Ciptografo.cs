using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace Biblioteca.Models
{
    public class Ciptrografo
    {
        public static string TextoCriptografado(string txt)
        {
            MD5 MD5Hasher = MD5.Create();

            byte[] By = Encoding.Default.GetBytes(txt);
            byte[] bytesCriptografados = MD5Hasher.ComputeHash(By);

            StringBuilder SB = new StringBuilder();

            foreach (byte b in bytesCriptografados)
            {
                string DebugB = b.ToString("x2");
                SB.Append(DebugB);
            }

            return SB.ToString();
        }
    }
}