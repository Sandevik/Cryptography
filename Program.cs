namespace XOR
{
  class Program
  {
    static void Main(string[] args){
      string word = "Encryption test";
      string key = "it works!"
        
      // Encrypt_1 & Decrypt_1 
        
      Console.WriteLine( "\"" +word +"\"" +" encrypted: " + Cryptography.Encrypt_1(word, key) + "\n");
      // Logs: "2c1a435|162|1f1a4e7|5454121c6|"
      
      Console.WriteLine(Cryptography.Encrypt(word, key) +" decrypted: " + "\"" + Cryptography.Decrypt_1(Cryptography.Encrypt_1(word, key), key)+"\"");
      // Logs: "Encryption test"
      
      /*--------------------------------------------------------------------------------------------------*/
      
      // Encrypt_2 & Decrypt_2
      
      Console.WriteLine( "\"" +word +"\"" +" encrypted: " + Cryptography.Encrypt_2(word, key) + "\n");
      // Logs: "e:GVQXTA;:TEWT"
      
      Console.WriteLine(Cryptography.Encrypt(word, key) +" decrypted: " + "\"" + Cryptography.Decrypt_2(Cryptography.Encrypt_2(word, key), key)+"\"");
      // Logs: "Encryption test"
      
      /*---------------------------------------------------------------------------------------------------*/
      
      // Encryption with both 
      
       string encrypted = Cryptography.Encrypt_2(Cryptography.Encrypt_1(word, key), key);
       string decrypted = Cryptography.Decrypt_1(Cryptography.Decrypt_2(encrypted, key), key);
      
       Console.WriteLine( "\"" +word +"\"" +" encrypted: " + encrypted + "\n");
       // Logs: "GILLBIELGL"
      
       Console.WriteLine(encrypted +" decrypted: " + "\"" + decrypted +"\n");
       // Logs: "Encryption test"
      
      
    }
  }
}
