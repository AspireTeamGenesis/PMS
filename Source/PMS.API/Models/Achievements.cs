using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace PMS_API
{
    public class Achievements
    {
        [Key]
        public int AchievementId{get;set;}
        public int ProfileId{get;set;}
        public int AchievementTypeId{get;set;}
        
        public string base64header {get;set;}
        public byte[]? AchievementImage{get;set;}
        

        [ForeignKey("ProfileId")]
        [InverseProperty("achievements")]
       public virtual Profile? profile {get;set;}

        [ForeignKey("AchievementTypeId")]
        [InverseProperty("achievements")]
        public virtual AchievementType? achievementtype{get;set;}
        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }
        [DefaultValue(true)]
        public bool IsActive{get;set;}
    }
}