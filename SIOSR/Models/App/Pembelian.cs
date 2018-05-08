using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIOSR.Models.App {

    public class Pembelian : TrackableEntity {

        [ForeignKey ("Umkm")]
        [Required]
        public int UmkmId { get; set; }

        [Required]
        public string Name { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public int Amount { get; set; }
        [Required]
        public string AccountNumber { get; set; }

        [DisplayFormat (NullDisplayText = "Waiting For Approval")]
        public Status? Status { get; set; }

        public Umkm Umkm { get; set; }
    }
}
