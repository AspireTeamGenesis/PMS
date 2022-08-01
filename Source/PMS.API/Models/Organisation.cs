using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace PMS_API{
     public class Organisation
    {
        [Key]
        public int OrganisationId{get; set;}
        public string OrganisationName{get;set;}
        [InverseProperty("organisation")]
        public virtual ICollection<User>? users{get;set;}
        [DefaultValue(true)]
        public bool IsActive{get;set;}
        

        
    }
}