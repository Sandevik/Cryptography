namespace XOR
{
  class Program
  {
    static void Main(string args[]){
      string word = "Encryption test";
      string key = "it works!"
      Console.WriteLine( "\"" +word +"\"" +" encrypted: " + EncryptionDecryption.Encrypt(word, key) + "\n");   // Logs: "2c1a435|162|1f1a4e7|5454121c6|"
      Console.WriteLine(EncryptionDecryption.Encrypt(word, key) +" decrypted: " + "\"" + XOR.Decrypt(XOR.Encrypt(word, key), key)+"\""); // Logs: "Encryption test"
    }
  }
}
