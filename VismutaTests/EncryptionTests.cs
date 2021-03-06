﻿using System;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VismutaLib;

namespace VismutaTests
{
    [TestClass]
    public class EncryptionTests
    {
        // ReSharper disable once UnusedMember.Local
        private const String Keyphrase = @"☀☁☂☃☄★☆☇☈☉☊☋☌☍☎";
        private const String Plaintext = @"ᚻᛖ ᚳᚹᚫᚦ ᚦᚫᛏ ᚻᛖ ᛒᚢᛞᛖ ᚩᚾ ᚦᚫᛗ ᛚᚪᚾᛞᛖ ᚾᚩᚱᚦᚹᛖᚪᚱᛞᚢᛗ ᚹᛁᚦ ᚦᚪ ᚹᛖᛥᚫ";

        [TestMethod]
        public void AES256Encrypt()
        {
            Byte[] expected = { 0x50, 0xC5, 0xB0, 0x33, 0x77, 0xA8, 0xDC, 0xB5, 0xA9, 0x0F, 0x74, 0x2E, 0x6E, 0xD8, 0xDC, 0x8A, 0xB6, 0x7A, 0x5E, 0x8F, 0xB5, 0xA8, 0xF5, 0x97, 0x71, 0xAF, 0xBE, 0xFE, 0x01, 0x3B, 0xFB, 0x52, 0x1A, 0x53, 0x69, 0xBC, 0x34, 0xD2, 0xAF, 0x08, 0x61, 0xD3, 0x4C, 0xF8, 0xF5, 0x0A, 0x7A, 0x9A, 0xEB, 0x68, 0x73, 0x1D, 0x4C, 0xA2, 0x04, 0xAE, 0x7B, 0x4F, 0x89, 0x7A, 0xEB, 0x08, 0x46, 0xB9, 0xC2, 0xEE, 0x9A, 0x20, 0x21, 0x46, 0x63, 0x22, 0x4F, 0x60, 0x75, 0xC0, 0x26, 0x4E, 0xA7, 0x22, 0xCE, 0x4F, 0x44, 0xD6, 0x02, 0x77, 0x91, 0x47, 0x18, 0x13, 0xAF, 0xAC, 0x19, 0xAC, 0x3C, 0x42, 0x95, 0x55, 0x74, 0x9B, 0x4A, 0xE6, 0xCC, 0x89, 0x50, 0x3E, 0x20, 0xA1, 0x35, 0x77, 0x59, 0xC4, 0x8F, 0x34, 0x11, 0xA9, 0xCD, 0x13, 0xA8, 0xA2, 0x82, 0x5D, 0x90, 0xE2, 0x89, 0x06, 0xA5, 0x0B, 0x99, 0xBE, 0x42, 0x5D, 0x98, 0x19, 0x2B, 0xEE, 0xAD, 0xE7, 0xD4, 0x32, 0xF0, 0x94, 0xF0, 0x56, 0x1A, 0xFF, 0xCD, 0xB4, 0xCE, 0x9C, 0xCC, 0x20, 0x0C, 0x53, 0xBB, 0x64, 0x82, 0xA4, 0x84, 0xEB, 0x83, 0xBC, 0xCA, 0x09, 0x16, 0xED, 0x6F, 0xC0, 0x2E, 0x3C, 0xAC, 0xD3, 0xD5, 0xF1, 0xF2, 0x0A, 0x26, 0xDA, 0xDE, 0x26, 0x26, 0x43, 0x1F, 0x97, 0x33, 0xE1, 0xDB, 0xBD, 0xC9, 0x97, 0x8C, 0xE3, 0x0A, 0x79, 0x7A, 0xFE, 0x86, 0xAD, 0x0F, 0x42, 0x2C, 0x7C, 0xEF, 0xBA, 0xFE, 0xF8, 0x90, 0x1C, 0xA3, 0x6C, 0x88, 0x5C, 0xE9, 0x0D, 0xD6, 0xBD, 0xC3, 0x31, 0x72, 0xFE, 0xF3, 0x14, 0x52, 0xBC, 0x04, 0xE9, 0x27, 0xF7, 0xFF, 0xA7, 0x40, 0x61, 0x4B, 0x53, 0xD6, 0xA3, 0x8C, 0x77, 0xDD, 0x45 };
            Byte[] plaintextBytes = Encoding.UTF8.GetBytes(Plaintext);
            Byte[] key =
            {
                0xE3, 0x0C, 0xBE, 0x71, 0x2D, 0x92, 0x3B, 0x2E, 0xB2, 0xD3, 0x1D, 0xA2, 0x32, 0x12, 0x20, 0x16,
                0x46, 0x77, 0x24, 0xDD, 0x99, 0x8B, 0xB0, 0xA7, 0x49, 0xF4, 0x04, 0xA5, 0x62, 0xD6, 0x2E, 0xBF
            };

            Byte[] iv = { 0xc2, 0xee, 0x9a, 0x20, 0x21, 0x46, 0x63, 0x22, 0x4f, 0x60, 0x75, 0xc0, 0x26, 0x4e, 0xa7, 0x22 };

            Byte[] ciphertext = Encryption.AES256Encrypt(plaintextBytes, key, iv);
            Debug.Write(BitConverter.ToString(ciphertext));

            CollectionAssert.AreEqual(expected, ciphertext);
        }
    }
}
