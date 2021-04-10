using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Setting
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
