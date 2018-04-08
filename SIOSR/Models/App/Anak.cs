using System;
using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.App {

    public class Anak {

        public int Id { get; set; }

        [Required]
        [StringLength (128)]
        public string Name { get; set; }

        [Required]
        public int Class { get; set; }

        [Required]
        [StringLength (128)]
        public string Parent { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
    }
}
