using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.App {

    public class Umkm {

        public int Id { get; set; }

        [Required]
        [StringLength (128)]
        public string Title { get; set; }

        [Required]
        [StringLength (128)]
        public string Type { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [StringLength (256)]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public Status? Status { get; set; }
    }
}
