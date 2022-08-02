using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace PMS_API{
     public class College
    {
        [Key]
        public int CollegeId{get; set;}
        [Required]
        [StringLength(80)] 
        public string? CollegeName{get;set;}
        [InverseProperty("college")]
        public virtual ICollection<Education>? education  {get;set;}
        [DefaultValue(true)]
        public bool IsActive{get;set;}
        

        
    }
}