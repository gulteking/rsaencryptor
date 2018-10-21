using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RSAEncryptor
{
    class Program
    {
        private const int AN_ERROR_OCCURED_WHILE_READING_PUBLIC_KEY = -5;
        private const int AN_ERROR_OCCURED_WHILE_INITIALIZING_RSA_KEY = -10;
        private const int AN_ERROR_OCCURED_WHILE_ENCRYPTING_TEXT = -15;
        private const int AN_ERROR_OCCURED_WHILE_WRITING_ENCRPTED_TEXT_TO_FILE = -20;

        private string stringToEncrypt;
        private string publicKeyPath;
        private string encryptedTextOutPath;

        public Program(string[] args)
        {
            if (args.Length != 3)
            {
                Environment.Exit(-1);
            }
            else
            {
                stringToEncrypt = args[0];
                publicKeyPath = args[1];
                encryptedTextOutPath = args[2];
            }
        }

        public string ReadPublicKey()
        {
            try
            {
                return File.ReadAllText(publicKeyPath);
            }
            catch (Exception)
            {
                Environment.Exit(AN_ERROR_OCCURED_WHILE_READING_PUBLIC_KEY);
                return null;
            }
        }

        public RSACryptoServiceProvider InitializeRSAKey(string publicKeyStr)
        {
            try
            {
                RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(2048);
                rsaProvider.FromXmlString(publicKeyStr);
                return rsaProvider;
            }
            catch (Exception)
            {
                Environment.Exit(AN_ERROR_OCCURED_WHILE_INITIALIZING_RSA_KEY);
                return null;
            }
        }

        public string EncryptText(RSACryptoServiceProvider rsaProvider)
        {
            try
            {
                byte[] bytesPlainTextData = Encoding.Unicode.GetBytes(stringToEncrypt);
                byte[] bytesEncryptedText = rsaProvider.Encrypt(bytesPlainTextData, false);
                return Convert.ToBase64String(bytesEncryptedText);
            }
            catch (Exception)
            {
                Environment.Exit(AN_ERROR_OCCURED_WHILE_ENCRYPTING_TEXT);
                return null;
            }
        }

        public void WriteEncryptedTextToFile(string encryptedText)
        {
            try
            {
                File.WriteAllText(encryptedTextOutPath, encryptedText);
            }
            catch (Exception)
            {
                Environment.Exit(AN_ERROR_OCCURED_WHILE_WRITING_ENCRPTED_TEXT_TO_FILE);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program(args);
            string publicKeyStr = program.ReadPublicKey();
            RSACryptoServiceProvider csp = program.InitializeRSAKey(publicKeyStr);
            string encryptedText = program.EncryptText(csp);
            program.WriteEncryptedTextToFile(encryptedText);
        }
    }
}
