using System.Collections.Generic;

namespace Quizkampen
{
    public class Result
    {
        public bool Success { get; set; } = true;
        public List<string> ResultMessages { get; set; } = new List<string>();
    }
}
