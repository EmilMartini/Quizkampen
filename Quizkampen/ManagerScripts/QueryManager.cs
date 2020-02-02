using System;
using System.Linq;

namespace Quizkampen
{
    public class QueryManager
    {
        QuestionContext context;
        Random rnd = new Random();
        public QueryManager()
        {
           context = new QuestionContext();
           context.Database.EnsureCreated();
        }

        public Question GetRandomQuestion()
        {
            try
            {
                var toSkip = rnd.Next(0, context.Questions.Count());
                return context.Questions.Skip(toSkip).First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void AddQuestion(Question question)
        {
            try
            {
                context.Questions.Add(question);
                context.SaveChanges();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }    
        }
        public int GetNumberOfQuestions()
        {
            return context.Questions.Count();
        }
    }
}