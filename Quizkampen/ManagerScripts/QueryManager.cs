using System;
using System.Collections.Generic;
using System.Linq;

namespace Quizkampen
{
    public class QueryManager
    {
        QuizkampenContext context;
        UserManager userManager;
        Random rnd = new Random();

        public QueryManager(QuizkampenContext context, UserManager userManager)
        {
            this.context = context;
            this.userManager = userManager;
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
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }    
        }
        public int GetNumberOfQuestions()
        {
            return context.Questions.Count();
        }
        internal void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        public bool TryLogIn(int id)
        {
            try
            {
                userManager.CurrentUser = context.Users.Where(o => o.LogInId == id).First();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public List<User> GetAllUsers()
        {
            try
            {
                return context.Users.ToList();
            }
            catch (InvalidOperationException)
            {
                return null;             
            }
        }
        public void CheckIfNewHighScore(User currentUser, int currentUserScore)
        {
            if(context.Users.Where(o => o.Id == currentUser.Id).First().HighScore <= currentUserScore)
            {
                context.Users.Where(o => o == currentUser).First().HighScore = currentUserScore;
                context.SaveChanges();
            }
        }
    }
}