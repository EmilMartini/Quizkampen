using System;

namespace Quizkampen
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new QuizkampenContext();
            var userManager = new UserManager();

            //If first time starting program
            //var seed = new Seed(model);
            //seed.AddQuestions();

            var controller = new Controller(model, userManager);
            controller.Config();
            controller.Run();
        }
    }
}
