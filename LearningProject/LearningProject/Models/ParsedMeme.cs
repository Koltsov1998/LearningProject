using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProject.Models
{
    public class ParsedMeme
    {
        [Key] public int Id { set; get; }

        public string Url { set; get; }

        [ForeignKey(nameof(VkPublic))] public int VkPublicId { get; set; }

        public VkPublic VkPublic { get; set; }

        public string Text { get; set; }
    }
}
