using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS_API
{
    [NotMapped]
    public class UserLogin
    {
        public string ?UserName { get; set; }
        public string ? Password { get; set; }
    }
}