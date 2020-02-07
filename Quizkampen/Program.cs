
namespace Quizkampen
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new QuizkampenContext();
            var userManager = new UserManager();
            var seed = new Seed(context);
            var controller = new Controller(context, userManager);
            controller.Config(seed);
            controller.Run();
        }
    }
}
