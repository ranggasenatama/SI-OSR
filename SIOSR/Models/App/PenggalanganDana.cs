using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.App {

    public class PenggalanganDana : TrackableEntity {

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        [DisplayFormat (NullDisplayText = "Waiting For Approval")]
        public Status? Status { get; set; }

        public ICollection<Donasi> Donasis { get; set; }
    }
}
