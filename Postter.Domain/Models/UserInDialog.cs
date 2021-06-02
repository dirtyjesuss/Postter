using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Postter.Domain.Models
{
    public class UserInDialog
    {
        [Key]
        public int Id { get; set; }

        public int user_id { get; set; }

        public int dialog_id { get; set; }
        [ForeignKey("user_id")]
        public virtual User user { get; set; }
        [ForeignKey("dialog_id")]
        public virtual Dialog diaglog { get; set; }
    }
}