using System;
using System.Collections.Generic;
using System.Text;

namespace Quizkampen
{
    public class User
    {
        public Guid Id { get; set; }
        public int IdentityId { get; set; }
        public string UserName { get; set; }
        public int HighScore { get; set; }
    }
}
