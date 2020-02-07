using System;

namespace Quizkampen
{
    public class AddQuestionView : View
    {
        public Action<Question> AddQuestionCallback { get; set; }
        public Action ReturnCallback { get; set; }
        public Func<string, Result> StringInputValidation { get; set; }
        public Func<string, Result> ParseToInt { get; set; }

        public void Display()
        {
            Console.Clear();
            var questionInput = new QuestionInputForm();
            Console.WriteLine("Enter the question.");
            questionInput.Question = ValidateInput(StringInputValidation);
            Console.WriteLine("How many answers do you want to add?");
            var numberOfAnswers = int.Parse(ValidateInput(ParseToInt));
            Console.WriteLine($"Lets add {numberOfAnswers} answers.");
            questionInput.Answers = new Answer[numberOfAnswers];
            for (int i = 0; i < numberOfAnswers; i++)
            {
                Console.WriteLine($"Enter answer: {i + 1}");
                questionInput.Answers[i] = new Answer
                {
                    Title = ValidateInput(StringInputValidation)
                };
            };

            DisplayFullQuestion(questionInput);
            Console.WriteLine("Select which answer's correct.");
            var index = int.Parse(ValidateInput(ParseToInt));
            questionInput.Answers[index - 1].isCorrect = true;

            AddQuestionCallback(CreateQuestion(questionInput));
            ReturnCallback();
        }
        private void DisplayFullQuestion(QuestionInputForm questionInput)
        {
            int index = 1;
            Console.Clear();
            Console.WriteLine(questionInput.Question);
            foreach (var answer in questionInput.Answers)
            {
                Console.WriteLine($"{index}: {answer.Title}");
                index++;
            }
            Console.WriteLine();
        }
        private Question CreateQuestion(QuestionInputForm questionInput)
        {
            var question = new Question
            {
                Id = new Guid(),
                Title = questionInput.Question,
                Answers = questionInput.Answers,
            };
            Console.WriteLine("Added question...");
            WaitForKeyPress();
            return question;
        }
    }
}