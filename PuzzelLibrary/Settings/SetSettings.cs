using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml;

namespace PuzzelLibrary.Settings
{
    public class SetSettings
    {
        public XmlWriter CreateSettingsFile()
        {
            XmlWriter writer = null;
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Encoding = System.Text.Encoding.UTF8,
                Indent = true,
                OmitXmlDeclaration = true,
                NewLineOnAttributes = true
            };
            writer = XmlWriter.Create("Settings.xml", settings);
            writer.WriteStartElement("Settings");
            return writer;
        }

        public static XmlWriter CreateSettingValues(XmlWriter writer)
        {
            foreach (var Value in typeof(Values).GetProperties())
            {
                writer.WriteStartElement(Value.Name);
               // writer.WriteAttributeString("Type", Value.PropertyType.Name);
                var data = Value.GetValue(null);
                if (data == null)
                    data = (object)string.Empty;
                writer.WriteValue(data);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            return writer;
        }

        public static void CloseSettingsFile(XmlWriter writer)
        {
            writer.Flush();
            writer.Close();
        }

        public string EncryptPassword(string source)
        {
            string hash;
            using (Aes aesHash = Aes.Create())
            {
                hash = EncryptStringToBytes_Aes(source, aesHash.Key, aesHash.IV);
            }
            return hash;
        }
        private static string EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return Convert.ToBase64String(encrypted)+ Convert.ToBase64String(IV) + Convert.ToBase64String(Key);
        }
    }
}
