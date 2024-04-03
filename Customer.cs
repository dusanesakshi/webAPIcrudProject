using System.ComponentModel.DataAnnotations;
namespace webAPIcrudProject
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [StringLength(65)]
        public string FName { get; set; } = "";

        [StringLength(65)]
        public string LName { get; set; } = "";

        [StringLength(65)]
        public string PhNo { get; set; } = "";

        [StringLength(65)]
        public string Email { get; set; } = "";
    }
}
