# rsaencryptor
Simple RSA 2048 Public Key Encryptor Command Line Application. 
 Works with .net framework 4.0 and above

 1. Encrypts given string with given RSA 2048 public key 
 2. Converts encrypted binary to Base64 String  
 3. Saves Base64 string as text file to given path


**APPLICATION START PARAMETERS**
 1. Text to encrypt
 2. XML Public Key File
 3. Encrpted text output

**EXAMPLE**

    RSAEncryptor.exe "textToEncrypt" "C:\Users\gulteking\Desktop\pubKey.xml" "C:\Users\gulteking\Desktop\encryptedText.txt"

**RETURN CODES**

    SUCCESS = 0
    
    AN_ERROR_OCCURED_WHILE_READING_PUBLIC_KEY = -5

    AN_ERROR_OCCURED_WHILE_INITIALIZING_RSA_KEY = -10

    AN_ERROR_OCCURED_WHILE_ENCRYPTING_TEXT = -15

    AN_ERROR_OCCURED_WHILE_WRITING_ENCRPTED_TEXT_TO_FILE = -20


  
   **SAMPLE XML PUBLIC KEY FILE**

    <RSAKeyValue><Modulus>MODULUS HERE</Modulus><Exponent>EXPONENT HERE</Exponent></RSAKeyValue>
