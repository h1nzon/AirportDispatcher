using AirportDispatcher.Model;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace AirportDispatcher.Classes
{
    internal class AuthenticationClass
    {
        private static byte[] key = new byte[16];
        private static byte[] iv = new byte[16];

        public static Core db = new Core();

        public static void RegisterUser(string username, string password)
        {
            // Генерация ключа и вектора инициализации
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                aes.GenerateIV();
                key = aes.Key;
                iv = aes.IV;
            }

            byte[] encryptedPassword = EncryptString(password);
            string encryptedPasswordBase64 = Convert.ToBase64String(encryptedPassword);

            // Сохранение зарегистрированного пользователя в базу данных или другое хранилище

            var user = new Users
            {
                Login = username,
                Password = encryptedPasswordBase64,
                RoleID = 1
            };
            db.context.Users.Add(user);
            db.context.SaveChanges();
            var userID = db.context.Users.Where(u => u.Login == username).First().UserID;
            var encryptionKey = new EncryptionKeys
            {
                UserID = userID,
                EncryptionIV = Convert.ToBase64String(iv),
                EncryptionKey = Convert.ToBase64String(key)
            };
            db.context.EncryptionKeys.Add(encryptionKey);
            db.context.SaveChanges();
        }

        public static bool AuthenticateUser(string username, string password)
        {
            // Получение зашифрованного пароля пользователя из базы данных или другого хранилища

            try
            {
                string encryptedPasswordBase64 = GetEncryptedPasswordFromDatabase(username);
                byte[] encryptedPassword = Convert.FromBase64String(encryptedPasswordBase64);

                byte[] decryptedPassword = DecryptBytes(encryptedPassword);
                string decryptedPasswordString = Encoding.UTF8.GetString(decryptedPassword);

                return password == decryptedPasswordString;

                throw new Exception("Не удалось найти пользователя");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение: " + ex.Message);
            }
            return false;
        }

        private static byte[] EncryptString(string input)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                        cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    }

                    return memoryStream.ToArray();
                }
            }
        }

        private static byte[] DecryptBytes(byte[] inputBytes)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream(inputBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return Encoding.UTF8.GetBytes(streamReader.ReadToEnd());
                        }
                    }
                }
            }
        }

        private static string GetEncryptedPasswordFromDatabase(string username)
        {
            var user = db.context.Users.Where(u => u.Login == username).First();
            key = Convert.FromBase64String(db.context.EncryptionKeys.Where(u => u.UserID == user.UserID).First().EncryptionKey);
            iv = Convert.FromBase64String(db.context.EncryptionKeys.Where(u => u.UserID == user.UserID).First().EncryptionIV);
            return user.Password;
        }
    }
}
