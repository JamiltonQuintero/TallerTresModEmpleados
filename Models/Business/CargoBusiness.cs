using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerTresModEmpleados.Models.Abstract;
using TallerTresModEmpleados.Models.DAL;
using TallerTresModEmpleados.Models.Entities;


/////asdab sldkbaskjbnasñf
namespace TallerTresModEmpleados.Models.Business
{
    public class CargoBusiness : ICargoBusiness
    {

        private readonly DbContextProyecto _context;

        public CargoBusiness(DbContextProyecto context)
        {
            _context = context;
        }

        public Task CambiarEstadoActivoCargo(int id)
        {
            throw new NotImplementedException();
        }

        public Task CambiarEstadoInactivoCargo(int id)
        {
            throw new NotImplementedException();
        }

        public Task CrearCargo(Cargo empleado)
        {
            throw new NotImplementedException();
        }

        public Task EditarCargo(Cargo empleado)
        {
            throw new NotImplementedException();
        }

        public async Task<Cargo> ObtenerCargoPorId(int id)
        {
            return await _context.CargosPrivTours
                .FirstOrDefaultAsync(m => m.CargoId == id);
        }

        public async Task<IEnumerable<Cargo>> ObtenerListaCargo()
        {
            return await _context.CargosPrivTours.ToListAsync();
        }
    }
}
