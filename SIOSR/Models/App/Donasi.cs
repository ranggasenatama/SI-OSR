using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.App {

    public class Donasi {

        public int Id { get; set; }

        [Required]
        public int PenggalanganDanaId { get; set; }

        [Required]
        [StringLength (64)]
        public string Title { get; set; }

        [Required]
        [StringLength (128)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength (128)]
        public string Address { get; set; }

        [Required]
        [StringLength (128)]
        public string AccountNumber { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        [StringLength (128)]
        public string Bank { get; set; }

        [DisplayFormat (NullDisplayText = "Waiting For Approval")]
        public Status? Status { get; set; }

        public PenggalanganDana PenggalanganDana { get; set; }
    }
}
