using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerTresModEmpleados.Models.Entities;

namespace TallerTresModEmpleados.Models.Abstract
{
    public interface ICargoBusiness
    {
        Task<IEnumerable<Cargo>> ObtenerListaCargos();
        Task<Cargo> ObtenerCargoPorId(int id);
        IEnumerable<Cargo> ObtenerListaCargosEmpleados();
        Task GuardarCargo(Cargo cargo);
        Task<Cargo> ObtenerCargoPorNombre(string nombre);

    }
}
