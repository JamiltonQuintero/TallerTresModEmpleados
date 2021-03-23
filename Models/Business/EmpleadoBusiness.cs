using Microsoft.AspNetCore.Mvc.Rendering;
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
            return await _context.EmpleadosPrivTours
                .FirstOrDefaultAsync(m => m.EmpleadoId == id);
        }

        public SelectList ObtenerListaCargos()
        {
            return new SelectList(_context.CargosPrivTours.ToList(), "CargoId", "Nombre"); 
        }

        public async Task<Empleado> ObtenerEmpleadoPorDocumento(string Documento)
        {

            return await _context.EmpleadosPrivTours.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Documento == Documento);

        }

        public async Task CrearEmpleado(Empleado empleado)
        {
            empleado.CambioEstado = true;
            _context.Add(empleado);
            await ActualizarBd();

        }

        public async Task EditarEmpleado(Empleado empleado)
        {
            
            _context.Update(empleado);
            await ActualizarBd();

        }


        public async Task CambiarEstadoInactivoEmpleado(int id)
        {
            var empleado = await ObtenerEmpleadoPorId(id);
            empleado.CambioEstado = false;
            _context.Update(empleado);
            await ActualizarBd();

        }

        public async Task CambiarEstadoActivoEmpleado(int id)
        {
            var empleado = await ObtenerEmpleadoPorId(id);
            empleado.CambioEstado = true;
            _context.Update(empleado);
            await ActualizarBd();

        }


        public async Task ActualizarBd()
        {

            await _context.SaveChangesAsync();

        }

    }
}
