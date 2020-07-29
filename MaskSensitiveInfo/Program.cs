using System;
using System.Linq;
using System.Text;

namespace MaskSensitiveInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var secret = "abracadabra";
            Console.WriteLine("Give me a word!");
            var userInput = Console.ReadLine();
            //char[] charArray = userInput.ToCharArray();
            var maskedUserInput = userInput.ToCharArray();
            //var maskedUserInput = userInput;
            //StringBuilder maskedUserInput = new StringBuilder();
            //change the word into an array of single characters;
            //StringBuilder charArray = userInput.ToCharArray();
            //Console.WriteLine($"charArray: { charArray }");

            //Console.WriteLine($"maskedUserInput after initial copy: {maskedUserInput}");
            //int lastIndexPosition = userInput.Length - 1;
            int indexOfCharBeforeLastFourChars = userInput.Length - 5;
            //Console.WriteLine($"lastIndex: {lastIndexPosition}");
            //Console.WriteLine($"indexbeforelast4chars: {indexOfCharBeforeLastFourChars}");

            if (indexOfCharBeforeLastFourChars >= 0)
            {
                for (int i = 0; i < maskedUserInput.Length - 4; i++)
                {
                    maskedUserInput[i] = '*';
                }
            } else //I added a rule that if the word is fewer than 4 characters, then the whole word is masked; otherwise, as noted above, all except the last 4 characters are masked. 
            {
                for (int i = 0; i < maskedUserInput.Length; i++)
                {
                    maskedUserInput[i] = '*';
                    

                }
            }
            var finalResult = string.Join("", maskedUserInput.Select(c => c.ToString()).ToArray());

            Console.WriteLine($"Here's your word: { finalResult }.");

            Console.WriteLine("What's the secret code word?");
            var userSecret = Console.ReadLine();

            //here's the function that replaces characters with * at the specified index position - not usign it anymore but saving it here for future reference:
            //static string ReplaceAtIndex(int i, char value, string word)
            //{
                //change the string you get from the user into a char array so you can manipulate the letters more easily:
                //char[] letters = word.ToCharArray();
                //change the letter to the value you want:
                //letters[i] = value;
                //join the new characters and remaining letters into a new string:
                //return string.Join("", letters);
            //}

            //condition to determine whether to display masked value or not based on whether the user knows the secret:
            if (secret == userSecret)
            {
                Console.WriteLine($"You got it! Here's your word: {userInput}!");
            } 
            else
            {
              Console.WriteLine($"Oops, sorry, you gotta check on that again! Here's your word: {finalResult}");
            }
        }
    }
}
