using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerTresModEmpleados.Models.Entities;

namespace TallerTresModEmpleados.Models.Abstract
{
    public interface IEmpleadoBusiness
    {

        Task<IEnumerable<Empleado>> ObtenerListaEmpleados();

        Task<Empleado> ObtenerEmpleadoPorId(int id);

        SelectList ObtenerListaCargos();

        Task<Empleado> ObtenerEmpleadoPorDocumento(string Documento);

        Task CrearEmpleado(Empleado empleado);

        Task EditarEmpleado(Empleado empleado);

        Task CambiarEstadoInactivoEmpleado(int id);
        Task CambiarEstadoActivoEmpleado(int id);

    }
}
