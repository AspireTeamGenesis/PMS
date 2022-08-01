using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace PMS_API{
     public class Domain
    {
        [Key]
        public int DomainId{get; set;}
        [Required]
        [StringLength(80)]
        public string ? DomainName{get;set;}
        [InverseProperty("domain")]
        
        public virtual ICollection<Skills>? skills {get;set;}
       
       
        
        [DefaultValue(true)]
        public bool IsActive{get;set;}
        

        
    }
}