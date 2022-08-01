using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace PMS_API
{
    public class AchievementType
    {
        [Key]
        public int AchievementTypeId{get;set;}
        public string AchievementTypeName{get;set;}

        [InverseProperty("achievementtype")]
        public virtual ICollection<Achievements>? achievements{get;set;}
        [DefaultValue(true)]
        public bool IsActive{get;set;}


    }
}
     