using System;

namespace Quizkampen
{
    internal class StartScreenView
    {
        public string Message { get; internal set; }
        public Action Callback { get; internal set; }

        internal void Display()
        {
            Console.WriteLine(Message);
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
            Console.Clear();
            Callback();
        }
    }
}