using System;
using System.Collections.Generic;

namespace Quizkampen
{
    class Seed
    {
        QuizkampenContext context;
        public Seed(QuizkampenContext context)
        {
            this.context = context;
        }

        public void AddQuestions()
        {
            context.Questions.Add(new Question
            {
                Id = new Guid(),
                Title = "What's 2 x 2?",
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        id = new Guid(),
                        Title = "8",
                        isCorrect = false
                    },
                    new Answer
                    {
                        id = new Guid(),
                        Title = "6",
                        isCorrect = false
                    },                    
                    new Answer
                    {
                        id = new Guid(),
                        Title = "4",
                        isCorrect = true
                    },
                }
            });
            context.Questions.Add(new Question
            {
                Id = new Guid(),
                Title = "When did World War 2 start?",
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        id = new Guid(),
                        Title = "1940",
                        isCorrect = false
                    },
                    new Answer
                    {
                        id = new Guid(),
                        Title = "1939",
                        isCorrect = true
                    },
                    new Answer
                    {
                        id = new Guid(),
                        Title = "1938",
                        isCorrect = false
                    },
                }
            });
            context.Questions.Add(new Question
            {
                Id = new Guid(),
                Title = "How many times has Sweden won in the Eurovision song contest?",
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        id = new Guid(),
                        Title = "9",
                        isCorrect = false
                    },
                    new Answer
                    {
                        id = new Guid(),
                        Title = "6",
                        isCorrect = true
                    },
                    new Answer
                    {
                        id = new Guid(),
                        Title = "8",
                        isCorrect = false
                    },
                }
            });
            context.Questions.Add(new Question
            {
                Id = new Guid(),
                Title = "What's the meaning of life?",
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        id = new Guid(),
                        Title = "Dogs",
                        isCorrect = false
                    },
                    new Answer
                    {
                        id = new Guid(),
                        Title = "Cats",
                        isCorrect = false
                    },
                    new Answer
                    {
                        id = new Guid(),
                        Title = "42",
                        isCorrect = true
                    },
                }
            });
            context.Questions.Add(new Question
            {
                Id = new Guid(),
                Title = "How many frets does a regular acoustic guitar have?",
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        id = new Guid(),
                        Title = "24",
                        isCorrect = true
                    },
                    new Answer
                    {
                        id = new Guid(),
                        Title = "22",
                        isCorrect = false
                    },
                    new Answer
                    {
                        id = new Guid(),
                        Title = "20",
                        isCorrect = false
                    },
                }
            });
            context.SaveChanges();
        }
    }
}
