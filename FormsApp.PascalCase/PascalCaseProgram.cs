using System;
using System.Collections.Generic;

namespace FormsApp.PascalCase
{
    public class PascalCaseProgram
    {
        static void Main(string[] args)
        {
            const string sentence = "This iS a PascalCase3 eXample.";
            var chars = new PascalCaseProgram().GetUpperChars(sentence);
            chars.Sort();
            Console.WriteLine(string.Join(string.Empty, chars));
        }


        public List<char> GetUpperChars(string sentence)
        {
            var chars = new List<char>();
            for (var cursor = 0; cursor < sentence.Length; cursor++)
            {
                //Skip whitespaces between any words;
                if (char.IsWhiteSpace(sentence[cursor])) continue;

                var buffer = ProcessWord(sentence, ref cursor);
                chars.AddRange(buffer);

                //Advance to Next word if there is invalid word in the sentence.
                while (cursor < sentence.Length && !char.IsWhiteSpace(sentence[cursor]))
                    cursor++;
            }

            return chars;
        }

        private static IEnumerable<char> ProcessWord(string sentence, ref int index)
        {
            if (char.IsWhiteSpace(sentence[index]))
                return ArraySegment<char>.Empty;

            var state = CharacterState.NewWord;
            var buffer = new List<char>();
            for (; index < sentence.Length && !char.IsWhiteSpace(sentence[index]); index++)
            {
                var ch = sentence[index];
                switch (state)
                {
                    case CharacterState.NewWord when ch.IsUpperOrDigit():
                    case CharacterState.Lower when ch.IsUpperOrDigit():
                        buffer.Add(ch);
                        state = CharacterState.Upper;
                        break;
                    case CharacterState.Upper when char.IsLower(ch):
                    case CharacterState.Lower when char.IsLower(ch):
                        state = CharacterState.Lower;
                        break;
                    default:
                        return ArraySegment<char>.Empty;
                }
            }

            return buffer;
        }
    }
}