﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Quizkampen
{
    public class Answer
    {
        [Key]
        public Guid id { get; set; }
        public Question Question { get; set; }
        public string Title { get; set; }
        public bool isCorrect { get; set; }
    }
}