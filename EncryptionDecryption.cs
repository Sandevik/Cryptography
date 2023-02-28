namespace XOR
{
  public class EncryptionDecryption
  {
    
    /* -----------------First Technique------------------------ */
    
    public static string Encrypt_1(string word, string key){
            // Returs encrypted string
            int[] resultChars = new int[word.Length];
            string result = "";
            int[] wChars = new int[word.Length];
            //KChars needs to be the same length as word
            int[] kChars = new int[word.Length];
            // Convert to int[] and make the key array the same length as the word array by repeating the keys letters until it is the same length
            for(int i = 0; i < word.Length; i++){
                wChars[i] = (int)word[i];
                int j = i % key.Length;
                kChars[i] = (int)key[j];
            }
            // Encode the letter with the letter of the letter of the key at the same position
            for(int i = 0; i < wChars.Length; i++){
                resultChars[i] = wChars[i] ^ kChars[i];
            }
            // Covert each encoded letter to base 16 and add a pipe after if the letters length (as an int) is less than 2. Then append the character to the final string
             foreach(int i in resultChars){
                string c = Convert.ToString(i,16);
                if(c.Length != 1){
                    result += c;
                }else{
                    result += c+"|";
                }
            }            
            return result;
        }

        public static string Decrypt_1(string hash, string key){
            string result = "";
            List<int> kChars = new List<int>();
            List<string> hList = new List<string>();
            List<string> cList = new List<string>();
            List<int> finalList = new List<int>();
            string lastBunch = hash.Split('|')[hash.Split('|').Length - 1];
            string current = "";
            // Find any single characters by looking where the pipes are. And add the previous characters to the list and then follow with the single character
            for(int i = 0; i < hash.Length; i++){
                if(i+1 < hash.Length){
                    if(hash[i] == '|') continue;
                    if(hash[i+1] == '|'){
                        hList.Add(current);
                        current = "";
                        hList.Add(hash[i].ToString().Trim());
                    }else{
                        current += hash[i].ToString().Trim();
                    }
                }
            }
            hList.Add(lastBunch);
            // Split the strings in the array to make them pairs of two except for the single characters 
            foreach(string s in hList){
                if(s.Length > 2){
                    foreach(char[] cl in s.Chunk(2)){
                        int count = 0;
                        string segment = "";
                        foreach(char c in cl){
                            segment += c;
                            count++;
                            if(count == 2){
                                cList.Add(segment.Trim());
                                segment = "";
                                count = 0;
                            }
                        }
                    }
                }else{
                    cList.Add(s);
                }
            }    
            // Convert from base 16 to decimal
            foreach(string s in cList){
                int i = 0;
                if(int.TryParse(s, System.Globalization.NumberStyles.HexNumber, null, out i)){
                    finalList.Add(i);
                }
            }
            // Make a list of the keys characters until the length matches the length of the character list
            for(int i = 0; i < finalList.Count; i++){
                int j = i % key.Length;
                kChars.Add((int)key[j]);
            }
            // Convert the hashed characters back to the original characters by xoring them with the corresponding key character
            for(int i = 0; i < finalList.Count; i++){
                result += (char) (finalList[i] ^ kChars[i]);
            }
            return result;
        }
    
    
    
    /*-----------------Second Technique-----------------------*/
    
    public static string Encrypt_2(string word, string key){
            // Returs encrypted string
            int[] resultChars = new int[word.Length];
            string result = "";
            int[] wChars = new int[word.Length];
            //KChars needs to be the same length as word
            int[] kChars = new int[word.Length];
            // Make a hash of the key
            int kHash = 0;
            foreach(int i in key){
                kHash ^= i;
            }
            // Convert word to int[]
            for(int i = 0; i < word.Length; i++){
                wChars[i] = (int)word[i];
            }
            // Encode each letter with the hashed key
            for(int i = 0; i < wChars.Length; i++){
                resultChars[i] = wChars[i] ^ kHash;
            }
            // Shift the number a litte more and convert to char
            foreach(int i in resultChars){
                result += (char)(i + 58);
            }            
            return result;
        }

        public static string Decrypt_2(string hash, string key){
            string result = "";
            List<int> hList = new List<int>();
            // Create hash of key
            int kHash = 0;
            foreach(int c in key){
                kHash ^= c;
            }
            Remove the shift from each char of the word
            foreach(int s in hash){
                hList.Add(s-58);
            }
            // Dehash by xoring with the key hash
            for(int i = 0; i < hList.Count; i++){
                result += (char) (hList[i] ^ kHash);
            }
            return result;
        }
    
    
    
  }
}
