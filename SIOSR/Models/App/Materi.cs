using System;
using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.App {

    public class Materi : TrackableEntity {

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
