using System;

namespace Brackets
{
    public class Program
    {
        static void Main(string[] args)
        {
            IocContainer.InitializeContainer();
            var instance = IocContainer.Resolve<ISource>();

            var inputText = instance.ReadData();

            var isCorrect = CheckExpression.IsCorrect(inputText);

            instance.WriteResult(isCorrect);

            Console.WriteLine("Input text: {0} Result: {1}", inputText, isCorrect);
        }
    }
}

