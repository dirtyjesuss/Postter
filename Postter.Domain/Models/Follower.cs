using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Postter.Domain.Models
{
    public class Follower
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FollowsId { get; set; }

        public virtual User User { get; set; }
        public virtual User Follows { get; set; }
    }
}