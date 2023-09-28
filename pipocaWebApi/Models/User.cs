using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pipocaWebApi;

    public class User
    {

        public User()
        {
            name = string.Empty;
            email = string.Empty;
           
            
        }

        public int id { get; set; }
     
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
    
    
    }
