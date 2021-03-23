using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerTresModEmpleados.Models.Abstract;
using TallerTresModEmpleados.Models.DAL;
using TallerTresModEmpleados.Models.Entities;

namespace TallerTresModEmpleados.Models.Business
{
    public class CargoBusiness: ICargoBusiness
    {
        private readonly DbContextProyecto _context;

        public CargoBusiness(DbContextProyecto context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cargo>> ObtenerListaCargos()
        {
            return await _context.CargosPrivTours.ToListAsync();
        }
        public async Task<Cargo> ObtenerCargoPorId(int id)
        {
            return (await _context.CargosPrivTours.FirstOrDefaultAsync(cargo => cargo.CargoId == id));
        }
        public IEnumerable<Cargo> ObtenerListaCargosEmpleados()
        {
            return (_context.CargosPrivTours.ToList());
        }

        public async Task GuardarCargo(Cargo cargo)
        {
            _context.Add(cargo);
            await _context.SaveChangesAsync();
        }

        public async Task<Cargo> ObtenerCargoPorNombre(string nombre)
        {
            return (await _context.CargosPrivTours.FirstOrDefaultAsync(cargo => cargo.Nombre.Equals(nombre)));
        }
    }
        
    
}
