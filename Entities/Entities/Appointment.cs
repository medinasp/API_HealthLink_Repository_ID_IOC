using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Appointment date is required")]
        [AppointmentDate(ErrorMessage = "Appointment date cannot be less than today")]

        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Patient is required")]    
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        [Required(ErrorMessage = "Doctor is required")]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }

    public class AppointmentDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var appointment = (Appointment)validationContext.ObjectInstance;

            if (appointment.DateTime < DateTime.Today)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
