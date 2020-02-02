using System;

namespace Quizkampen
{
    internal class AnswerQuestionView
    {
        public Question GeneratedQuestion { get; set; }
        public Action MainMenuCallback { get; set; }
        public Action<int> ScoreScreenCallback { get; set; }

        private int correctAnswerIndex;

        public void Display()
        {
            int index = 1;
            int userInput;
            Console.WriteLine($"Question: {GeneratedQuestion.Title}");
            foreach (var answer in GeneratedQuestion.Answers)
            {
                Console.WriteLine($"Answer: {index} \t{answer.Title}");
                index++;
                if (answer.isCorrect)
                {
                    correctAnswerIndex = index - 1;
                }
            }
            Console.WriteLine("Enter the right answer.");
            if (CheckIfValidInput(out userInput))
            {
                CheckIfCorrect(userInput);
            } else
            {
                Display();
            }
        }

        private void CheckIfCorrect(int userInput)
        {
            int score = 0;
            Console.WriteLine();
            if(userInput == correctAnswerIndex)
            {
                Console.WriteLine($"Congratulations! You answered correctly.");
                score = 1;
            } else
            {
                Console.WriteLine("Sorry, that's wrong! Better luck next time...");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            ScoreScreenCallback(score);
        }

        private bool CheckIfValidInput(out int parsedResult)
        {
            var result = Console.ReadKey().KeyChar.ToString();
            try
            {
                parsedResult = int.Parse(result);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                parsedResult = default;
                return false;
            }
        }
    }
}