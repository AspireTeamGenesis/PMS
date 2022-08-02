using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace PMS_API{
     public class Gender
    {
        [Key]
        public int GenderId{get; set;}
        public string? GenderName{get;set;}
        
        [InverseProperty("gender")] 
        public ICollection<User>? users{get;set;}=default!;
        [DefaultValue(true)]
        public bool IsActive{get;set;}
        

        
    }
}