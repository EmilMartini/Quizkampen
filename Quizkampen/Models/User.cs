using System;

namespace Quizkampen
{
    public class User
    {
        public Guid Id { get; set; }
        public int LogInId { get; set; }
        public string UserName { get; set; }
        public int HighScore { get; set; }
    }
}
