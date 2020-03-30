using System.ComponentModel.DataAnnotations;

namespace AChat_Finaly_.Models
{
    public class UserModel
    {
        
        public bool UserVIP { get; set; }
        [Key]
        public string Name { get; set; }
        public string Pass { get; set; }
    }
}