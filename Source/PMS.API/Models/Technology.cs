using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace PMS_API{
     public class Technology
    {
        [Key]
        public int TechnologyId{get; set;}
        [Required]
        public string TechnologyName{get;set;}
      
        [InverseProperty("technology")]
        public virtual ICollection<Skills>? skills {get;set;}
        
        [DefaultValue(true)]
        public bool IsActive{get;set;}
        

        
    }
}