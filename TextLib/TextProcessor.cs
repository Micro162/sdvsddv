using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TextLib
{

    public static class TextProcessor
    {

        public static bool IsPalindrome(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            string cleaned = new string(
                text.ToLowerInvariant()
                    .Where(char.IsLetterOrDigit)
                    .ToArray());

            if (cleaned.Length == 0)
                return false;

            string reversed = new string(cleaned.Reverse().ToArray());
            return cleaned == reversed;
        }

  
        public static int CountSentences(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            var sentences = Regex.Split(text, @"[.!?]+")
                                  .Select(s => s.Trim())
                                  .Where(s => s.Length > 0);

            return sentences.Count();
        }

        public static string ReverseString(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text ?? string.Empty;

            char[] chars = text.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
