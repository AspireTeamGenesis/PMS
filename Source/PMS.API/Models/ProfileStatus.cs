using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace PMS_API{
     public class ProfileStatus
    {
        [Key]
        public int ProfileStatusId{get; set;}
        public string? ProfileStatusName{get;set;}
        [DefaultValue(true)]
        public bool IsActive{get;set;}
        

        
    }
}