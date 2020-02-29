using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningProject.Models
{
    public class VkPublic
    {
        [Key] public int Id { get; set; }

        public string Url { get; set; }

        /// <summary>
        /// groupid в базе данных вк
        /// </summary>
        public int VkId { get; set; }

        public string Name { get; set; }

        public string ScreenName { get; set; }

        public bool IsClosed { get; set; }

        public string Type { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsMember { get; set; }

        public string IsAdvertiser { get; set; }

        public string Descritption { get; set; }

        public string Photo50 { get; set; }

        public string Photo100 { get; set; }

        public string Photo200 { get; set; }

        public ICollection<ParsedMeme> Posts { get; set; }
    }
}
