using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace Postter.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string? AttachmentPath { get; set; }
        public string UserId { get; set; }
        public int? ReplyToId { get; set; }
        public int? RepostFromId { get; set; }

        public User Author { get; set; }
        
        [ForeignKey("ReplyToId")]
        public Post? ReplyTo { get; set; }
        
        [ForeignKey("RepostFromId")]
        public Post? RepostFrom { get; set; }
    }
}