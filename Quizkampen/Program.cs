
namespace Quizkampen
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new QuizkampenContext();
            var userManager = new UserManager();
            var seed = new Seed(model);


            var controller = new Controller(model, userManager);
            controller.Config(seed);
            controller.Run();
        }
    }
}
