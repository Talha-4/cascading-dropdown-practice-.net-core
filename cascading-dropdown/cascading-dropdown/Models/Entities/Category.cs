using System.ComponentModel.DataAnnotations;

namespace cascading_dropdown.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
