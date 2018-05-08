using System;
using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.App {

    public class Absensi : TrackableEntity {

        [Required]
        public int Kehadiran { get; set; }
    }
}
