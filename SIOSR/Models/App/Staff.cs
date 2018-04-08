using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.App {

    public class Staff {

        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength (128)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
