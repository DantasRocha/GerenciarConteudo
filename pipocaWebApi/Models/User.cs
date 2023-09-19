using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace eCommerceWebApi.Models
{
    public class User
    {

        public User()
        {
            name = string.Empty;
            email = string.Empty;
            status=1;
            dtAt=DateTime.Now;
            dtUp=DateTime.Now;
            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
     
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public int status { get; set; }
        [Required]
        public DateTime dtAt { get; set; }
        [Required]
        public DateTime dtUp { get; set; }
    }
}