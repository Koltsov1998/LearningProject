﻿using System.ComponentModel.DataAnnotations;

namespace LearningProject.Models
{
    public class VkPublic
    {
        [Key] public int Id { get; set; }

        public string Uri { get; set; }
    }
}
