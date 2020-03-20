using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestTask
{
    class CheckExpression
    {
        public static bool IsCorrect(string expression)
        {
            var stack = new Stack<string>();
            var brackets = Configuration.GetWordsDictionary();
        
            try
            {
                foreach(var e in Regex.Split(expression, @"(<[^>]*>)"))
                {
                    if (brackets.Keys.Contains(e))
                        stack.Push(e);
                    else
                        if (brackets.Values.Contains(e))
                            if (e == brackets[stack.First()])
                                stack.Pop();
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

            return stack.Count() == 0;
        }
    }
}
    
