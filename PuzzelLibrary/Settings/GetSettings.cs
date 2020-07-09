using PuzzelLibrary.AD.Connection.Credential;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PuzzelLibrary.Settings
{
    public class GetSettings : ISettings
    {
        public string UserName { get => GetValuesFromXml("Settings.xml", "UserName"); }
        public string Password { get => DecryptPassword(GetValuesFromXml("Settings.xml", "Password")); }
        public string Version { get => ""; set { } }
        public string CustomLogon { get; set; }
        public bool CredentialsAvailable 
        { 
            get 
            { 
                if (UserName != null && UserName != string.Empty) 
                    return true; 
                return false; 
            } 
        }
        public GetSettings()
        {

        }

        private string DecryptPassword(string source)
        {
            string hash = string.Empty;
            try
            {
                using (Aes aesHash = Aes.Create())
                {
                    var data = source.Split("==");
                    hash = DecryptStringFromBytes_Aes(Convert.FromBase64String(data[0] + "=="), Convert.FromBase64String(data[2]), Convert.FromBase64String(data[1] + "=="));
                }
            }
            catch (System.FormatException) { System.Windows.Forms.MessageBox.Show("Brak hasła"); }
            return hash;
        }


        private string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
        public static string GetValuesFromXml(string XmlFile, string valueToGet)
        {
            string value = string.Empty;
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),XmlFile);
            if (File.Exists(filePath))
                using (System.Xml.XmlReader reader = System.Xml.XmlReader.Create(XmlFile))
                {
                    var setsettings = new SetSettings();
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            if (valueToGet == reader.Name.ToString())
                                value = reader.ReadString();
                        }
                    }
                }
            else System.Windows.Forms.MessageBox.Show(new System.Windows.Forms.Form { TopMost = true }, "Nie znaleziono pliku " + filePath, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            return value;
        }   
    }
}
