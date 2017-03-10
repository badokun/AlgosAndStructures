using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class StringCalculator
    {
        // Write a method to find the index of the first non-repeated character in a String
        //      012345
        // E.g. status -> 2

        public static int FindIndexOfNonRepeated(string input)
        {
            List<char> characters = new List<char>();
            characters.Add(input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                if (characters.Contains(input[i]))
                {
                    characters.Remove(input[i]);
                }
                else
                {
                    characters.Add(input[i]);
                }
            }

            var firstCharacter = characters.First();
            return input.IndexOf(firstCharacter);
        }
    }
}
