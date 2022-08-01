using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PMS_API
{
    [NotMapped]
    public class CascadeFilter
    {
        public string? UserName { get; set; }=String.Empty;
        public int DesignationId { get; set; }=0;
        public int DomainID { get; set; }=0;
        public int TechnologyId { get; set; }=0;
        public int CollegeId { get; set; }=0;
        public int ProfileStatusId { get; set; }=0;
    }
}