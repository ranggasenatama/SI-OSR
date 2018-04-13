using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.App {

    public class PenggalanganDana {

        public int Id { get; set; }

        [Required]
        [StringLength (64)]
        public string Title { get; set; }

        [Required]
        [StringLength (256)]
        public string Description { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public int Image { get; set; }

        public Status? Status { get; set; }
    }
}
