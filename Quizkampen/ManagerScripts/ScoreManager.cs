using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quizkampen
{
    class ScoreManager
    {
        QuizkampenContext context;
        private QuizkampenContext model;

        public ScoreManager(QuizkampenContext model)
        {
            this.model = model;
        }
    }
}
