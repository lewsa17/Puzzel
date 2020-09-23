using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Xml;

namespace PuzzelLibrary.Settings
{
    public class SetSettings : ISettings
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Version { get; set; }


        public XmlWriter CreateSettingsFile()
        {
            XmlWriter writer = null;
            XmlWriterSettings settings = new XmlWriterSettings();
            writer = XmlWriter.Create("Settings.xml", settings);
            //writer.WriteStartDocument(true);
            writer.WriteStartElement("Settings");
            settings.Encoding = System.Text.Encoding.UTF8;
            settings.Indent = true;
            return writer;
        }

        public static XmlWriter CreateSettingValues(XmlWriter writer)
        {
            foreach (var Value in typeof(Values).GetProperties())
            {
                writer.WriteStartElement(Value.Name);
                writer.WriteAttributeString("Type", Value.PropertyType.Name);
                writer.WriteString(Value.GetValue(null).ToString());
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


        public void Save()
        {
            XmlTextWriter writer = new XmlTextWriter("Settings.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Settings");
            writer.WriteStartElement("Credentials");
            SetValue("UserName", UserName, writer);
            SetValue("Password", Password, writer);
            writer.WriteEndElement();
            SetValue("Version", Version, writer);
            writer.WriteEndDocument();
            writer.Close();
            Console.WriteLine("XML File created ! ");
        }
        private void SetValue(string Name, string Value, XmlTextWriter writer)
        {
            writer.WriteStartElement(Name);
            if (Name == "Password")
                Value = (EncryptPassword(Value));
            writer.WriteString(Value.ToString());
            writer.WriteEndElement();
        }        
        public string EncryptPassword(string source)
        {
            string hash;
            using (Aes aesHash = Aes.Create())
            {
                hash = EncryptStringToBytes_Aes(source, aesHash.Key,aesHash.IV);
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
