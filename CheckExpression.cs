using System.Collections.Generic;
using System.Linq;

namespace TestTask
{
    class CheckExpression
    {
        public static bool IsCorrect(string expression, Brackets brackets)
        {
            var result = new Stack<char>();
            var pairBrackets = brackets.bracketPairs;

            try
            {
                foreach(var e in expression)
                {
                    if (pairBrackets.Keys.Contains(e))
                        result.Push(e);
                    else
                        if (pairBrackets.Values.Contains(e))
                            if (e == pairBrackets[result.First()])
                                result.Pop();
                            else
                                return false;
                    else
                        continue;
                }
            }
            catch
            {
                return false;
            }

            return result.Count() == 0;
        }
    }
}
    
