using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AssinadoCrypt
{
    public static class Cryptography
    {
        public static string ToCrypt(this string textToCrypto)
        {
            if (string.IsNullOrEmpty(textToCrypto.Trim()))
                throw new Exception("The content to be encrypted can not  be an empty string.");
            using (var rijndael = SessionRijndael("jikh231df2ghj45g", "f41sd2x31cyu56jk"))
            {
                var encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                            streamWriter.Write(textToCrypto);
                    }
                    return ArrayBytesToHexString(memoryStream.ToArray());
                }
            }
        }

        public static string ToDecrypt(this string textToDecrypt)
        {
            if (string.IsNullOrEmpty(textToDecrypt.Trim()))
                throw new Exception("The content can not be decrypted be an empty string.");
            if (textToDecrypt.Length % 2 != 0)
                throw new Exception("The content to be decrypted is invalid.");
            using (var rijndael = SessionRijndael("jikh231df2ghj45g", "f41sd2x31cyu56jk"))
            {
                var decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);
                string str;
                using (var memoryStream = new MemoryStream(HexStringToArrayBytes(textToDecrypt)))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                            str = streamReader.ReadToEnd();
                    }
                }
                return str;
            }
        }

        ///The IV must haver 16 characters
        public static string ToCrypt(this string textToCrypto, string textToKey, string textToIv)
        {
            if (string.IsNullOrEmpty(textToCrypto.Trim()))
                throw new Exception("The content to be encrypted can not  be an empty string.");
            using (var rijndael = SessionRijndael(textToKey, textToIv))
            {
                var encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                            streamWriter.Write(textToCrypto);
                    }
                    return ArrayBytesToHexString(memoryStream.ToArray());
                }
            }
        }

        ///The IV must haver 16 characters
        public static string ToDecrypt(this string textToDecrypt, string textToKey, string textToIv)
        {
            if (string.IsNullOrEmpty(textToDecrypt.Trim()))
                throw new Exception("The content can not be decrypted be an empty string.");
            if (textToDecrypt.Length % 2 != 0)
                throw new Exception("The content to be decrypted is invalid.");
            using (var rijndael = SessionRijndael(textToKey, textToIv))
            {
                var decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);
                string str;
                using (var memoryStream = new MemoryStream(HexStringToArrayBytes(textToDecrypt)))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                            str = streamReader.ReadToEnd();
                    }
                }
                return str;
            }
        }

        private static Rijndael SessionRijndael(string chave, string vetorInicializacao)
        {
            if (chave == null || chave.Length != 16 && chave.Length != 24 && chave.Length != 32)
                throw new Exception("The encryption key must haver 16, 24 or 32 characters.");
            if (vetorInicializacao == null || vetorInicializacao.Length != 16)
                throw new Exception("The IV must haver 16 characters.");
            var rijndael = Rijndael.Create();
            rijndael.Key = Encoding.ASCII.GetBytes(chave);
            rijndael.IV = Encoding.ASCII.GetBytes(vetorInicializacao);
            return rijndael;
        }

        private static string ArrayBytesToHexString(byte[] conteudo)
        {
            return string.Concat(Array.ConvertAll(conteudo, b => b.ToString("X2")));
        }

        private static byte[] HexStringToArrayBytes(string conteudo)
        {
            var length = conteudo.Length / 2;
            var numArray = new byte[length];
            for (var index = 0; index < length; ++index)
                numArray[index] = Convert.ToByte(conteudo.Substring(index * 2, 2), 16);
            return numArray;
        }
    }
}
