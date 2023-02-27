namespace XOR
{
  public class EncryptionDecryption
  {
    public static string Encrypt_1(string word, string key){
            // Returs encrypted string
            int[] resultChars = new int[word.Length];
            string result = "";
            int[] wChars = new int[word.Length];
            //KChars needs to be the same length as word
            int[] kChars = new int[word.Length];
            // Convert to int[]
            for(int i = 0; i < word.Length; i++){
                wChars[i] = (int)word[i];
                int j = i % key.Length;
                kChars[i] = (int)key[j];
            }
            for(int i = 0; i < wChars.Length; i++){
                resultChars[i] = wChars[i] ^ kChars[i];
            }
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
            foreach(string s in cList){
                int i = 0;
                if(int.TryParse(s, System.Globalization.NumberStyles.HexNumber, null, out i)){
                    finalList.Add(i);
                }
            }
            for(int i = 0; i < finalList.Count; i++){
                int j = i % key.Length;
                kChars.Add((int)key[j]);
            }
            for(int i = 0; i < finalList.Count; i++){
                result += (char) (finalList[i] ^ kChars[i]);
            }
            return result;
        }
    
    public static string Encrypt_2(string word, string key){
            // Returs encrypted string
            int[] resultChars = new int[word.Length];
            string result = "";
            int[] wChars = new int[word.Length];
            //KChars needs to be the same length as word
            int[] kChars = new int[word.Length];
            int kHash = 0;
            foreach(int i in key){
                kHash ^= i;
            }
            // Convert to int[]
            for(int i = 0; i < word.Length; i++){
                wChars[i] = (int)word[i];
            }
            for(int i = 0; i < wChars.Length; i++){
                resultChars[i] = wChars[i] ^ kHash;
            }
            foreach(int i in resultChars){
                result += (char)(i + 58);
            }            
            return result;
        }

        public static string Decrypt_2(string hash, string key){
            string result = "";
            int kHash = 0;
            List<int> hList = new List<int>();
            foreach(int c in key){
                kHash ^= c;
            }
            foreach(int s in hash){
                hList.Add(s-58);
            }
            for(int i = 0; i < hList.Count; i++){
                result += (char) (hList[i] ^ kHash);
            }
            return result;
        }
    
    
    
  }
}
