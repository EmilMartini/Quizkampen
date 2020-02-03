using System;

namespace Quizkampen
{
    public class View
    {
        protected void WaitForKeyPress()
        {
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        protected string ValidateInput(Func<string, Result> validation)
        {
            string input;
            bool retry;
            do
            {
                input = Console.ReadLine();
                var validationResult = validation(input);
                retry = validationResult.Success;
                if (!validationResult.Success)
                {
                    foreach (var message in validationResult.ResultMessages)
                    {
                        Console.WriteLine(message);
                    }
                }

            } while (!retry);
            return input;
        }
        public Result ValidateInputString(string input)
        {
            var result = new Result();

            if (string.IsNullOrWhiteSpace(input))
            {
                result.ResultMessages.Add("Input cannot be empty.");
                result.Success = false;
                return result;
            }

            return result;
        }
        public Result ValidateParse(string input)
        {
            var result = new Result();
            var parsedResult = 0;

            try
            {
                parsedResult = int.Parse(input);
            }
            catch (Exception ex)
            {
                result.ResultMessages.Add(ex.Message);
                result.Success = false;
                return result;
            }

            if(parsedResult < 0)
            {
                result.ResultMessages.Add("Input cannot be negative");
                result.Success = false;
                return result;
            }
            return result;
        }
    }
}
