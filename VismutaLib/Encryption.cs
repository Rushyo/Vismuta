﻿using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace VismutaLib
{
    internal static class Encryption
    {
        private static readonly Byte[] StaticDerivationSalt = { 0xbc, 0x64, 0xba, 0xb0, 0x31, 0x63, 0xee, 0x30
                , 0x2a, 0xdf, 0xc0, 0x1b, 0x51, 0xae, 0x71, 0x99,
                0x79, 0xbf, 0xf5, 0x18, 0x9a, 0x36, 0x8a, 0x56
                , 0x18, 0x3b, 0x29, 0xb4, 0xcf, 0xdc, 0x3c, 0x86 };

        public static Byte[] AES256Encrypt(Byte[] plaintext, String key)
        {
            if (String.IsNullOrWhiteSpace(key))
                throw new ArgumentException(@"Invalid key", nameof(key));
            if (plaintext == null)
                throw new ArgumentNullException(nameof(plaintext));
            if (plaintext.Length == 0)
                throw new ArgumentException(nameof(plaintext));

            using (SHA256 lazyDeriveKey = SHA256.Create())
            {
                Byte[] saltedKey = Encoding.UTF8.GetBytes(key).Concat(StaticDerivationSalt).ToArray();
                return AES256Encrypt(plaintext, lazyDeriveKey.ComputeHash(saltedKey));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public static Byte[] AES256Encrypt(Byte[] plaintext, Byte[] key)
        {
            if(key == null)
                throw new ArgumentNullException(nameof(key));
            if(key.Length != 32)
                throw new ArgumentException(@"Key length invalid", nameof(key));
            if (plaintext == null)
                throw new ArgumentNullException(nameof(plaintext));
            if (plaintext.Length == 0)
                throw new ArgumentException(nameof(plaintext));
            

            using (var aes = new AesManaged())
            {
                aes.Key = key;
                aes.GenerateIV();
                //Just in case target system has different defaults...
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;
                aes.KeySize = 256;
                aes.BlockSize = 128;

                Byte[] ciphertext;
                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (var streamWriter = new StreamWriter(cryptoStream))
                                streamWriter.Write(plaintext);
                            ciphertext = memoryStream.ToArray();
                        }
                    }
                }

                Byte[] ciphertextWithIV = aes.IV.Concat(ciphertext).ToArray();


                using (var hmac = new HMACSHA512(key))
                {
                    Byte[] hash = hmac.ComputeHash(ciphertext);
                    Byte[] ciphertextWithHMAC = hash.Concat(ciphertextWithIV).ToArray();
                    return ciphertextWithHMAC;
                }
            }
        }
    }
}
