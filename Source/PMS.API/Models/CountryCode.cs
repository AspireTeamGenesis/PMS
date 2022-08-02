using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace PMS_API{
     public class CountryCode
    {
        [Key]
        public int CountryCodeId{get; set;}
        public string? CountryCodeName{get;set;}
        [InverseProperty("countrycode")]
        public virtual ICollection<User>?  users{get;set;}
        [DefaultValue(true)]
        public bool IsActive{get;set;}
        

        
    }
}