using System;
using System.Text;

namespace Demo.UnitTests.Common
{
    public static partial class RandomValue
    {
        private static readonly Random _random = new Random();

        private static readonly ICharacterClass _allowedCharacters =
            new CharactersRange('a', 'z')
            .Join(new CharactersRange('A', 'Z'))
            .Join(new CharactersRange('0', '9'))
            .Join('-')
            .Join('_')
            .Join(' ');

        public static string String(int length)
        {
            var stringBuilder = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                stringBuilder.Append(_allowedCharacters.GetRandomChar(_random));
            }

            return stringBuilder.ToString();
        }

        public static int Integer(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
