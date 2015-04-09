using System;
using System.IO;
using System.Security.Cryptography;

namespace Encryption
{
    public static class Symmetric
    {
        private const int KeySize = 256;
        private static readonly byte[] Salt = { 1, 2, 23, 234, 37, 48, 134, 63, 248, 4 };

        public static string GenerateIV()
        {
            var aesEncryption = new RijndaelManaged
            {
                KeySize = KeySize,
                BlockSize = 128,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };
            aesEncryption.GenerateIV();
            return DecimalByteArrayToHexString(aesEncryption.IV);
        }

        private static string DecimalByteArrayToHexString(byte[] array)
        {
            return BitConverter.ToString(array).Replace("-", string.Empty);
        }

        //public static byte[] Encrypt(byte[] plain, string password)
        //{
        //    MemoryStream memoryStream;
        //    CryptoStream cryptoStream;
        //    Rijndael rijndael = Rijndael.Create();
        //    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, SALT);
        //    rijndael.Key = pdb.GetBytes(32);
        //    rijndael.IV = pdb.GetBytes(16);
        //    memoryStream = new MemoryStream();
        //    cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
        //    cryptoStream.Write(plain, 0, plain.Length);
        //    cryptoStream.Close();
        //    return memoryStream.ToArray();
        //}

        //public static byte[] Decrypt(byte[] cipher, string password)
        //{
        //    MemoryStream memoryStream;
        //    CryptoStream cryptoStream;
        //    Rijndael rijndael = Rijndael.Create();
        //    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, SALT);
        //    rijndael.Key = pdb.GetBytes(32);
        //    rijndael.IV = pdb.GetBytes(16);
        //    memoryStream = new MemoryStream();
        //    cryptoStream = new CryptoStream(memoryStream, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
        //    cryptoStream.Write(cipher, 0, cipher.Length);
        //    cryptoStream.Close();
        //    return memoryStream.ToArray();
        //}
        private static byte[] EncryptToBytes(string keyPhrase, byte[] originalBytes)
        {
            var pdb = new Rfc2898DeriveBytes(keyPhrase, Salt);
            var aesEncryption = new RijndaelManaged
            {
                KeySize = KeySize,
                BlockSize = 128,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                IV = pdb.GetBytes(16),
                Key = pdb.GetBytes(32)
            };
            var encryptor = aesEncryption.CreateEncryptor();
            return encryptor.TransformFinalBlock(originalBytes, 0, originalBytes.Length);
        }

        public static byte[] DecryptToBytes(string keyPhrase, byte[] cipherTextBytes)
        {
            var pdb = new Rfc2898DeriveBytes(keyPhrase, Salt);
            var aesEncryption = new RijndaelManaged
            {
                KeySize = KeySize,
                BlockSize = 128,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                IV = pdb.GetBytes(16),
                Key = pdb.GetBytes(32)
            };
            var decryptor = aesEncryption.CreateDecryptor();
            return decryptor.TransformFinalBlock(cipherTextBytes, 0, cipherTextBytes.Length);
        }

        public static string EncryptFile(string plainTextFilePath, string secret, string targetDirectory, string encryptedFilename = null)
        {
            try
            {
                var fileStream = new FileStream(plainTextFilePath, FileMode.Open, FileAccess.Read);
                var binaryReader = new BinaryReader(fileStream);
                var plainTextFile = new FileInfo(plainTextFilePath);
                var numBytes = plainTextFile.Length;
                var bytes = binaryReader.ReadBytes((int)numBytes);

                var encryptedBytes = EncryptToBytes(secret, bytes);

                var newFilename = encryptedFilename ?? Path.GetRandomFileName();
                if(encryptedFilename!=null)
                    File.Delete(Path.Combine(targetDirectory, encryptedFilename));

                var fullPath = Path.Combine(targetDirectory, newFilename);

                binaryReader.Close();
                binaryReader.Dispose();
                fileStream.Close();
                fileStream.Dispose();

                File.WriteAllBytes(fullPath, encryptedBytes);

                return newFilename;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string DecryptFile(string encryptedFilepath, string secret, string targetDirectory)
        {
            var fileStream = new FileStream(encryptedFilepath, FileMode.Open, FileAccess.Read);
            var binaryReader = new BinaryReader(fileStream);
            var plainTextFile = new FileInfo(encryptedFilepath);
            var numBytes = plainTextFile.Length;
            var cipherTextBytes = binaryReader.ReadBytes((int)numBytes);

            var decryptedBytes = DecryptToBytes(secret, cipherTextBytes);

            var newFilename = Path.GetRandomFileName();
            var fullPath = Path.Combine(targetDirectory, newFilename);

            binaryReader.Close();
            binaryReader.Dispose();
            fileStream.Close();
            fileStream.Dispose();

            File.WriteAllBytes(fullPath, decryptedBytes);

            return fullPath;
        }

        static byte[] GetBytes(string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            var chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        public static string EncryptString(string plainText, string key)
        {
            var bytes = GetBytes(plainText);
            var encryptToBytes = EncryptToBytes(key, bytes);
            return GetString(encryptToBytes);
        }

        public static string DecryptString(string cypherText, string key)
        {
            var cypherBytes = GetBytes(cypherText);
            var decryptToBytes = DecryptToBytes(key, cypherBytes);
            return GetString(decryptToBytes);
        }
    }
}
