using System;
using System.ComponentModel.DataAnnotations;

namespace SIOSR.Models.App {

    public class TrackableEntity {

        public int Id { get; set; }

        [DisplayFormat (ApplyFormatInEditMode = false, DataFormatString = "{0:dd MMMM yyyy}")]
        [ScaffoldColumn (false)]
        public DateTime? CreatedAt { get; set; }
        [DisplayFormat (ApplyFormatInEditMode = false, DataFormatString = "{0:dd MMMM yyyy}")]
        [ScaffoldColumn (false)]
        public DateTime? UpdatedAt { get; set; }
    }
}
