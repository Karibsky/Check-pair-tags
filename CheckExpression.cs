using System.Collections.Generic;
using System.Linq;

namespace TestTask
{
    class CheckExpression
    {
        public static bool IsCorrect(string expression)
        {
            var result = new Stack<string>();
            var brackets = Configuration.GetWordsDictionary();
        
            try
            {
                foreach(var e in expression.Split())
                {
                    if (brackets.Keys.Contains(e))
                        result.Push(e);
                    else
                        if (brackets.Values.Contains(e))
                            if (e == brackets[result.First()])
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
    
