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
        public QueryManager(QuizkampenContext model, UserManager userManager)
        {
            context = model;
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
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }    
        }
        public int GetNumberOfQuestions()
        {
            return context.Questions.Count();
        }
        public int GetScoreFromUser(User user)
        {
            return context.Users.Where(o => o == user).First().HighScore;
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
                var user = context.Users.Where(o => o.IdentityId == id).First();
                userManager.CurrentUser = context.Users.Where(o => o.IdentityId == id).First();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void AddScoreToUser(User user, int score)
        {
            context.Users.Where(o => o == user).First().HighScore += score;
            context.SaveChanges();
        }
        public User GetUser()
        {
            return null;
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
    }
}