using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzelLibrary.Crypting
{
    public class Data
    {
        public static void Decrypt(string file, out string DecryptedData)
        {
            CryptingData.DecryptFile(file, out DecryptedData);
        }
        public static void Encrypt(string file, string plainText)
        {
            CryptingData.EncryptFile(file, plainText);
        }
    }

    internal static class CryptingData
    {
        private static readonly byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
        internal static void EncryptFile(string writeToFile, string text)
        {
            try
            {
                using FileStream myStream = new FileStream(writeToFile, FileMode.OpenOrCreate);

                using Aes aes = Aes.Create();
                aes.Key = key;

                byte[] iv = aes.IV;
                myStream.Write(iv, 0, iv.Length);

                using CryptoStream cryptStream = new CryptoStream(
                    myStream,
                    aes.CreateEncryptor(),
                    CryptoStreamMode.Write);

                using StreamWriter sWriter = new StreamWriter(cryptStream);

                sWriter.WriteLine(text);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("The encryption failed.");
                throw;
            }
        }
        internal static void DecryptFile(string readFile, out string DecryptedData)
        {
            try
            {
                using FileStream myStream = new FileStream(readFile, FileMode.Open);

                using Aes aes = Aes.Create();

                byte[] iv = new byte[aes.IV.Length];
                myStream.Read(iv, 0, aes.IV.Length);
                using CryptoStream cryptStream = new CryptoStream(
                   myStream,
                   aes.CreateDecryptor(key, iv),
                   CryptoStreamMode.Read);
                using StreamReader sReader = new StreamReader(cryptStream);
                DecryptedData = sReader.ReadToEnd().TrimEnd();
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("The decryption failed.");
                throw;
            }
        }
    }
}
