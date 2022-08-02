using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace PMS_API{
    public class ChangePassword
    {
        [Key]
        public int ChangePasswordId{get; set;}
        public string? NewPassword{get;set;}
        public string? ConfirmPassword{get;set;}
        [DefaultValue(true)]
        public bool IsActive{get;set;}
        

        
    }
}