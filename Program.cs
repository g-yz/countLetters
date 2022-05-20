
using System;

namespace Marketplace
{
    internal class Program
    {
        static void Main(string[] args){
            string sentence2 = "Lorem Ipsum is simply dummy ";
            FindMostRepeatedLetterDictionary(sentence2);

            string sentence = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."; 
            FindMostRepeatedWordFor(sentence);
            FindMostRepeatedWord(sentence);
        }

        public static char FindMostRepeatedLetterDictionary(string sentence){
            sentence = sentence.ToUpper().Replace(" ", String.Empty);

            Dictionary<char, int> sentenceDict = new Dictionary<char, int>();
            for(int i = 0; i < sentence.Length; i++){
                if(sentenceDict.ContainsKey(sentence[i]))
                    sentenceDict[sentence[i]]++;
                else
                    sentenceDict.Add(sentence[i], 1);
            } 
            char maxKey = sentenceDict.MaxBy(kvp => kvp.Value).Key; 
            Console.WriteLine($"Answer: {maxKey} {sentenceDict[maxKey]} times.");
            return maxKey;
        }

        public static char FindMostRepeatedLetter(string sentence){
            sentence = sentence.ToUpper().Replace(" ", String.Empty);

            int[] arraySentence = new int[27];
            int maxIndex = 0;

            for(int i = 0; i < sentence.Length; i++){
                int value = (System.Convert.ToInt32(sentence[i])) - 65;
                arraySentence[value]++;
                if(arraySentence[value]>arraySentence[maxIndex]) maxIndex=value;
            }
            
            char ans = (char)(maxIndex + 65);
            Console.WriteLine($"Answer: {ans} {arraySentence[maxIndex]} times.");
            return ans;
        }

        public static char FindMostRepeatedLetterToOrder(string sentence){
            sentence = sentence.ToUpper().Replace(" ", String.Empty);

            int[] arraySentence = new int[27];

            for(int i = 0; i < sentence.Length; i++){
                int value = (System.Convert.ToInt32(sentence[i])) - 65;
                arraySentence[value]++;
            }
            int maxIndex = 0;
            for(int i = 0; i < arraySentence.Length; i++){
                if(arraySentence[i]>arraySentence[maxIndex]) maxIndex=i;
            }
            char ans = (char)(maxIndex + 65);
            Console.WriteLine($"Answer: {ans} {arraySentence[maxIndex]} times.");
            return ans;
        }

        public static string FindMostRepeatedWordFor(string sentence){
            string[] splitSentence = sentence.Split(' '); 
            int maxIndex = 0;
            string maxValue = "";
            for(int i = 0; i < splitSentence.Length; i++){
                int sizeWord = 0;
                for(int j = 0; j < splitSentence.Length; j++){
                    if(splitSentence[j] == splitSentence[i]) sizeWord++;
                }
                if(sizeWord > maxIndex){ 
                    maxIndex = sizeWord;
                    maxValue = splitSentence[i];
                }
            }
            Console.WriteLine($"{maxIndex}: {maxValue}");
            return maxValue;
        }

        public static string FindMostRepeatedWord(string sentence){
            string[] splitSentence = sentence.Split(' '); 
            int maxIndex = 0;
            string maxValue = "";
            foreach (string w in splitSentence){
                int sizeWord = (from ItemRep in splitSentence where (ItemRep == w) select ItemRep).ToList().Count;
                if(sizeWord > maxIndex){ 
                    maxIndex = sizeWord;
                    maxValue = w;
                }
            }
            Console.WriteLine($"{maxIndex}: {maxValue}");
            return maxValue;
        }
    }
}
