namespace XOR
{
  class Program
  {
    string word = "Encryption test";
    string key = "it works!"
    Console.WriteLine( "\"" +word +"\"" +" encrypted: " + XOR.Encrypt(word, key) + "\n");
    Console.WriteLine(XOR.Encrypt(word, key) +" decrypted: " + "\"" + XOR.Decrypt(XOR.Encrypt(word, key), key)+"\"");
  }
}
