using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerTresModEmpleados.Models.Entities;

namespace TallerTresModEmpleados.Models.Abstract
{
    public interface ICargoBusiness
    {

        Task<IEnumerable<Cargo>> ObtenerListaCargo();

        Task<Cargo> ObtenerCargoPorId(int id);


        Task CrearCargo(Cargo empleado);

        Task EditarCargo(Cargo empleado);

        Task CambiarEstadoInactivoCargo(int id);
        Task CambiarEstadoActivoCargo(int id);

    }
}
