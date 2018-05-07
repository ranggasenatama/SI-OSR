using System;
using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.App {

    public class Anak {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public int Class { get; set; }

        [Required]
        public string Parent { get; set; }
        [Required]
        public string Contact { get; set; }

        [DisplayFormat (NullDisplayText = "Waiting For Approval")]
        public Status? Status { get; set; }
    }
}
