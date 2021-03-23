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
    public class EmpleadoBusiness : IEmpleadoBusiness
    {
        private readonly DbContextProyecto _context;

        public EmpleadoBusiness(DbContextProyecto context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> ObtenerListaEmpleados()
        {
            return await _context.EmpleadosPrivTours.Include("Cargo").ToListAsync();
        }

        public async Task<Empleado> ObtenerEmpleadoPorId(int id)
        {
            return (await _context.EmpleadosPrivTours.FirstOrDefaultAsync(m => m.EmpleadoId == id));
        }
        public async Task<Empleado> ObtenerEmpleadoPorDocumento(string doc)
        {
            return (await _context.EmpleadosPrivTours.FirstOrDefaultAsync(m => m.Documento.Equals(doc)));
        }

        public async Task GuardarEmpleado (Empleado empleado)
        {
            try
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /*public IEnumerable<Cargo> ObtenerListaCargosEmpleados()
        {
            return (_context.CargosPrivTours.ToList());
        }*/
    }
}
