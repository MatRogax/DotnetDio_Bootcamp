using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_manager.Models
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = default!;

        [Required]
        [StringLength(255)]
        public string Description { get; set; } = default!;
        public DateTime Date { get; set; }
        public EnumTaskStatus Status { get; set; }
    }
}
