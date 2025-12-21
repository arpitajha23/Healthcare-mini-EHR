using DomainLayer.DTOs;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.CommonMethod
{
    public class EncryptionDecrypt
    {
        private readonly EncryptionSettings _settings;
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public EncryptionDecrypt(IOptions<EncryptionSettings> settings)
        {
            if (settings?.Value == null)
                throw new ArgumentNullException(nameof(settings));

            _key = Convert.FromBase64String(settings.Value.Key);
            _iv = Convert.FromBase64String(settings.Value.IV);

            // 🔐 Hard validation (prevents runtime crashes)
            if (_key.Length != 16 && _key.Length != 24 && _key.Length != 32)
                throw new Exception("AES key must be 16, 24, or 32 bytes.");

            if (_iv.Length != 16)
                throw new Exception("AES IV must be exactly 16 bytes.");
        }

        public string Encrypt(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
                return plainText;

            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;

            using var encryptor = aes.CreateEncryptor();
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using var sw = new StreamWriter(cs, Encoding.UTF8);

            sw.Write(plainText);
            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }

        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrWhiteSpace(cipherText))
                return cipherText;

            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;

            using var decryptor = aes.CreateDecryptor();
            using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs, Encoding.UTF8);

            return sr.ReadToEnd();
        }
    }
}
