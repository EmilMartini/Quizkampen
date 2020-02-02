using System;

namespace Quizkampen
{
    internal class AddQuestionView
    {
        public Action<Question> AddQuestionCallback { get; set; }
        public Action ReturnCallback { get; set; }

        Question newQuestion = default;
        string titleInput = default;
        int numberOfAnswers = default;
        int rightAnswer = 0;


        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Lets add a question!");
            Console.WriteLine("Enter the question.");

            if (!CheckInput(out titleInput, "You entered a question that's too short.\nTry Again..."))
            {
                ResetView();
            }

            Console.WriteLine();
            Console.WriteLine("Great, Lets add the answers!");
            Console.WriteLine("How many answers do you want to add?");
            
            if(!CheckInput(out numberOfAnswers))
            {
                ResetView();
            }

            Console.WriteLine();
            Console.WriteLine($"Okay.. Lets add {numberOfAnswers} answers.");
            Answer[] answers = new Answer[numberOfAnswers];
            Console.WriteLine();

            for (int i = 0; i < answers.Length; i++)
            {
                Console.WriteLine($"Answer no. {i + 1}");
                AddAnswer(answers, i, Console.ReadLine());
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("\nGreat! Now lets select the right answer for the question!");
            Console.WriteLine("Enter the number for the right answer.");
            Console.WriteLine();

            for (int i = 0; i < answers.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {answers[i].Title}");
            }

            if(!CheckInput(out rightAnswer))
            {
                ResetView();
            }

            answers[rightAnswer - 1].isCorrect = true;

            if(CreateQuestion(titleInput, answers, out newQuestion))
            {
                AddQuestionCallback(newQuestion);
                ReturnCallback();
            } else
            {
                ResetView();
            }
        }
        private bool CreateQuestion(string titleInput, Answer[] answers, out Question question)
        {
            try
            {
                var newQuestion = new Question
                {
                    Id = new Guid(),
                    Title = titleInput,
                    Answers = answers
                };

                Console.Clear();
                Console.WriteLine("Adding this question to database.\n");
                Console.WriteLine($"Question: {newQuestion.Title}\n");

                foreach (var answer in newQuestion.Answers)
                {
                    Console.WriteLine($"Answer: {answer.Title} | Correct answer? {answer.isCorrect}");
                };

                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
                question = newQuestion;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message: {ex.Message}");
                question = null;
                return false;
            }
        }
        private void ResetView()
        {
            Console.WriteLine();
            Console.ReadKey();
            Display();
        }
        private void AddAnswer(Answer[] answers, int i, string v)
        {
            answers[i] = new Answer
            {
                Title = v
            };
        }
        private bool CheckInput(out string output, string errorMessage)
        {
            try
            {
                var input = Console.ReadLine().Trim();
                if (input.Length < 5)
                {
                    throw new Exception("Input string too short.");
                }
                output = input;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(errorMessage);
                Console.WriteLine($"Error Message: {ex.Message}");
                output = "";
                return false;
            }
 
        }
        private bool CheckInput(out int output)
        {
            try
            {
                output = int.Parse(Console.ReadKey().KeyChar.ToString());
                if(output < 1)
                {
                    throw new Exception("Given number can't be negative or zero.");
                }
                return true;
            }
            catch (Exception ex)
            {
                output = default;
                Console.WriteLine($"Couldn't parse input. \nError message: {ex.Message}\nTry Again...");
                return false;
            }
        }
    }
}