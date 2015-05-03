using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Kata2Euler
    {
        private string input;

        public string output;

        public Kata2Euler(string input)
        {
            this.input = input;
        }

        public string GenerateWordsFromNumber(int number)
        {

            for (var i = 1; i < number; i++)
            {
                ConvertNumberToWord(i);
            }

            return "";
        }

        private string ConvertNumberToWord(int i)
        {
            throw new NotImplementedException();
        }

        public int Calculate()
        {
            this.input = this.input.Replace("-", "");
            var wordNumbers = this.input.Split(',').ToDictionary(n => n, n => n.Length);
            var result = 0;

            foreach (var wordNumber in wordNumbers)
            {
                var whiteSpaceCount = wordNumber.Key.Count(char.IsWhiteSpace);
                result += (wordNumber.Value - whiteSpaceCount);
                this.output += wordNumber.Key;
            }

            return result;
        }
    }
}
