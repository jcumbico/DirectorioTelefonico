using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Directorio.ENT
{
    [Table("Persona")]
    public partial class Persona
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Primer Nombre")]
        [Required]
        [MaxLength(10)]
        public string Nombre1 { get; set; }

        [Display(Name ="Segundo Nombre")]
        [MaxLength(10)]
        public string Nombre2 { get; set; }

        [Display(Name ="Apellido Paterno")]
        [Required]
        [MaxLength(10)]
        public string ApellidoPaterno { get; set; }

        [Display(Name ="Apellido Materno")]
        [MaxLength(10)]
        public string ApellidoMaterno { get; set; }

        [Display(Name ="Fecha de Nacimiento")]
        [Required]
        [DataType(DataType.DateTime)]
        [ValidarFechaNacimiento]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name ="Fecha de Fallecimiento")]
        [DataType(DataType.DateTime)]
        public Nullable<DateTime> FechaFallecimiento { get; set; }

        [Display(Name ="Fecha de Ingreso")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaIngreso { get; set; }

        [Display(Name ="Fecha de Salida")]
        [DataType(DataType.DateTime)]
        public Nullable<DateTime> FechaSalida { get; set; }

        [Display(Name ="Esta Activo")]
        [DefaultValue(false )]
        public bool EstaActivo { get; set; }

        [Display(Name = "Cargo Asignado")]
        [Required]
        public int CargoAsignadoId { get; set; }

        public virtual Cargo CargoAsignado { get; set; }
    }

    public class ValidarFechaNacimiento : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Persona ObjetoPersona = (Persona)validationContext.ObjectInstance;

            if (value == null)
            {
                return ValidationResult.Success;
            }
            if (ObjetoPersona.FechaFallecimiento == null)
            {
                return ValidationResult.Success;
            }

            DateTime FechaNacimiento = (DateTime)value;

            if (FechaNacimiento < ObjetoPersona.FechaFallecimiento)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Fecha de Nacimiento no puede ser igual o mayor a la fecha de fallecimiento", new string[] { "FechaNacimiento" });
            }
        }
    }
}
