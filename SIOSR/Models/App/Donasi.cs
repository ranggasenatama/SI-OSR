using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SIOSR.Models.App {

    public class Donasi : TrackableEntity {

        [ForeignKey ("PenggalanganDana")]
        [Required]
        public int PenggalanganDanaId { get; set; }

        [Required]
        public string Name { get; set; }

        [Phone]
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string Bank { get; set; }

        public PenggalanganDana PenggalanganDana { get; set; }
    }
}
