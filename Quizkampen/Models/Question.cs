using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quizkampen
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}