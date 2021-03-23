using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TallerTresModEmpleados.Models.Entities;

namespace TallerTresModEmpleados.Models.Abstract
{
    public interface IEmpleadoBusiness
    {
        Task<IEnumerable<Empleado>> ObtenerListaEmpleados();
        Task<Empleado> ObtenerEmpleadoPorId(int id);

        Task<Empleado> ObtenerEmpleadoPorDocumento(string doc);
        Task GuardarEmpleado(Empleado empleado);
        //IEnumerable<Cargo> ObtenerListaCargosEmpleados();
    }
}
