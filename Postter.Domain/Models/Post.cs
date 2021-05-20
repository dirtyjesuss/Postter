using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace Postter.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PostedTime { get; set; }
        public string? AttachmentPath { get; set; }
        public string UserId { get; set; }
        public int? ReplyToId { get; set; }
        public int? RepostFromId { get; set; }

        public virtual User Author { get; set; }
        
        [ForeignKey("ReplyToId")]
        public virtual Post? ReplyTo { get; set; }
        
        [ForeignKey("RepostFromId")]
        public virtual Post? RepostFrom { get; set; }
    }
}