using Fatec.LabEngSoftIII.Zhang.Api.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Fatec.LabEngSoftIII.Zhang.API.Utils
{
    public class Criptografia
    {
        private byte[] _key { get; set; }
        public Criptografia()
        {
            Config config = new Config();
            this._key = Encoding.UTF8.GetBytes(config.ChaveCriptografia);
        }

        public string Criptografar(string texto)
        {
            try
            {
                Random rnd = new Random();

                byte[] salt = new byte[16];
                rnd.NextBytes(salt);

                Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(this._key, salt, 100);

                byte[] iv = new byte[16];
                rnd.NextBytes(iv);
                byte[] encrypted;

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = pbkdf2.GetBytes(32);
                    aesAlg.IV = iv;
                    aesAlg.Padding = PaddingMode.PKCS7;
                    aesAlg.Mode = CipherMode.CBC;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor();

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(texto);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }

                List<byte> ret = new List<byte>();
                ret.AddRange(salt);
                ret.AddRange(iv);
                ret.AddRange(encrypted);

                return Convert.ToBase64String(ret.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Decriptografar(string texto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(texto))
                    return "";

                byte[] cipherBytes = Convert.FromBase64String(texto);
                using (Aes encryptor = Aes.Create())
                {
                    var salt = cipherBytes.Take(16).ToArray();
                    var iv = cipherBytes.Skip(16).Take(16).ToArray();
                    var encrypted = cipherBytes.Skip(32).ToArray();
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(this._key, salt, 100);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.Padding = PaddingMode.PKCS7;
                    encryptor.Mode = CipherMode.CBC;
                    encryptor.IV = iv;
                    using (MemoryStream ms = new MemoryStream(encrypted))
                    {
                        using (StreamReader reader = new StreamReader(
                                           new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Read),
                                           Encoding.UTF8))
                        {
                            return reader.ReadToEnd();

                        };
                    }
                };
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
