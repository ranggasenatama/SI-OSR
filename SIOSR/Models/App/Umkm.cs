using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.App {

    public class Umkm : TrackableEntity {

        [Required]
        public string Title { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        [DisplayFormat (NullDisplayText = "Waiting For Approval")]
        public Status? Status { get; set; }

        public ICollection<Pembelian> Pembelians { get; set; }
    }
}
