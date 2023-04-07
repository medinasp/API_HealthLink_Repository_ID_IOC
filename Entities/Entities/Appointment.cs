using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Appointment date is required")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Patient is required")]    
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required(ErrorMessage = "Doctor is required")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
