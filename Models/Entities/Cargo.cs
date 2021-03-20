using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerTresModEmpleados.Models.Entities
{
    public class Cargo
    {

        public int CargoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public string InternoExterno { get; set; }

        public bool CambioEstado { get; set; }

    }
}
