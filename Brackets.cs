using System.Collections.Generic;

namespace TestTask
{
    class Brackets
    {
        public Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' },
            { '<', '>' }
        };
    }
}
