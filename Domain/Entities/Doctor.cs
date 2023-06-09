﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string Name { get; set; }
        public string CRM { get; set; }
        public string Specialty { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }

    }
}
