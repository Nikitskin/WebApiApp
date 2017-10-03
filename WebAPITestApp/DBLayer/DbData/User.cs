using System.ComponentModel.DataAnnotations;

namespace DBLayer.DbData
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Order { get; set; }
    }
}