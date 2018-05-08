using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SIOSR.Models.App {

    public class Staff : TrackableEntity {

        [ForeignKey ("ApplicationUser")]
        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        public string Name { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }

        [DisplayFormat (NullDisplayText = "Waiting For Approval")]
        public Status? Status { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
