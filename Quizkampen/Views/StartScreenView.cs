using System;

namespace Quizkampen
{
    internal class StartScreenView : View
    {
        public string Message { get; internal set; }
        public Action LogInCallback { get; internal set; }

        internal void Display()
        {
            Console.WriteLine(Message);
            WaitForKeyPress();
            Console.Clear();
            LogInCallback();
        }
    }
}