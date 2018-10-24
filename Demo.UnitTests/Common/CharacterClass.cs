using System;

namespace Demo.UnitTests.Common
{
    interface ICharacterClass
    {
        int CharCount { get; }
        char this[int index] { get; }
    }

    class SingleCharacter : ICharacterClass
    {
        private readonly char _value;

        public SingleCharacter(char value)
        {
            _value = value;
        }

        public char this[int index] => _value;

        public int CharCount => 1;
    }

    class CharactersRange : ICharacterClass
    {
        private readonly char _first;
        private readonly char _last;

        public CharactersRange(char first, char last)
        {
            _first = first;
            _last = last;
        }

        public int CharCount => 1 + _last - _first;

        public char this[int index] => (char)(_first + index);
    }

    class CombinedCharacterClass : ICharacterClass
    {
        private readonly ICharacterClass _left;
        private readonly ICharacterClass _right;

        public CombinedCharacterClass(ICharacterClass left, ICharacterClass right)
        {
            _left = left;
            _right = right;

            CharCount = left.CharCount + right.CharCount;
        }

        public int CharCount { get; }

        public char this[int index]
        {
            get
            {
                if (index < _left.CharCount)
                {
                    return _left[index];
                }

                return _right[index - _left.CharCount];
            }
        }
    }

    static class CharacterClassHelper
    {
        public static ICharacterClass Join(this ICharacterClass left, ICharacterClass right)
        {
            return new CombinedCharacterClass(left, right);
        }

        public static ICharacterClass Join(this ICharacterClass left, char right)
        {
            return new CombinedCharacterClass(left, new SingleCharacter(right));
        }

        public static ICharacterClass Join(this ICharacterClass charClass, char firstChar, char lastChar)
        {
            return new CombinedCharacterClass(charClass, new CharactersRange(firstChar, lastChar));
        }

        public static char GetRandomChar(this ICharacterClass characterClass, Random random)
        {
            var index = random.Next(0, characterClass.CharCount);
            return characterClass[index];
        }
    }
}
