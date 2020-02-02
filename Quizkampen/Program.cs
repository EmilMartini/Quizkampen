using System;

namespace Quizkampen
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new QuizkampenContext();
            var userManager = new UserManager();
            var controller = new Controller(model, userManager);
            controller.Config();
            controller.Run();
        }
    }
}
