using System;
using System.Collections.Generic;
using System.Text;

namespace Quizkampen
{
    public class Result
    {
        public bool Success { get; set; } = true;
        public List<string> ResultMessages { get; set; } = new List<string>();
    }
}
