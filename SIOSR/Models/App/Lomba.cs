using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.App {

    public class Lomba {

        public int Id { get; set; }

        [Required]
        [StringLength (64)]
        public string Title { get; set; }

        [Required]
        [StringLength (256)]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
