using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.App {

    public class Pembelian {

        public int Id { get; set; }

        [Required]
        [StringLength (128)]
        public string Title { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [StringLength (128)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength (128)]
        public string Address { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string Shipping { get; set; }
    }
}
