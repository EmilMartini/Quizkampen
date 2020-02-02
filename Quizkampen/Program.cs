using System;

namespace Quizkampen
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new QuestionContext();
            var controller = new Controller(model);
            controller.Config();
            controller.Run();
        }
    }
}
