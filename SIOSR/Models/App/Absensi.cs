using System;
using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.App {

    public class Absensi {

        public int Id { get; set; }

        [Required]
        public string Kehadiran { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
