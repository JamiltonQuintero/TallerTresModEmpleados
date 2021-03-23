using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerTresModEmpleados.Models.Entities
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Contrasena { get; set; }
        
        [DisplayName("Cargo del empleado")]
        public int CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }

        public bool CambioEstado { get; set; }


    }
}
