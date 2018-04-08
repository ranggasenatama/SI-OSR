﻿using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.PenggalanganDana {

    public class Donasi {

        public int Id { get; set; }

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
        public int Total;

        [Required]
        [StringLength (128)]
        public string Bank { get; set; }

        [Required]
        [StringLength (128)]
        public string Status { get; set; }
    }
}
