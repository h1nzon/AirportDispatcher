using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AirportDispatcher.Classes
{
    internal class DataEncryption
    {
        /// <summary>
        /// Класс для шифрования алгоритмом AES (Advanced Encryption Standard), 
        /// в режиме ECB (Electronic Codebook), всех входящих данных.
        /// </summary>

        private static byte[] key = Encoding.UTF8.GetBytes("EhP#?Sw0c?hF"); // 16, 24, or 32 bytes
        private static byte[] iv = Encoding.UTF8.GetBytes("xAQ?dLuYXeRd"); // 16 bytes

        /// <summary>
        /// Метод для шифрования входящих данных.
        /// </summary>
        /// <param name="data">
        /// Входящие данные для шифрования.</param>
        /// <returns>Возвращает строку в зашифрованном виде.</returns>
        public static string Encrypt(string data)
        {
            byte[] encrypted;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(data);
                        }

                        encrypted = ms.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// Метод для расшифровки входящих данных.
        /// </summary>
        /// <param name="data">
        /// Входящие данные.
        /// </param>
        /// <returns>
        /// Возвращает строку в открытом виде.
        /// </returns>
        public static string Decrypt(string data)
        {
            byte[] cipherBytes = Convert.FromBase64String(data);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
