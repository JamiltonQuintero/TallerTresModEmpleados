using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerTresModEmpleados.Models.Abstract;
using TallerTresModEmpleados.Models.DAL;
using TallerTresModEmpleados.Models.Entities;

namespace TallerTresModEmpleados.Controllers
{
    public class EmpleadoController : Controller
    {
        //private readonly DbContextProyecto _context;

        private readonly IEmpleadoBusiness _empleadoBusiness;

        public EmpleadoController(IEmpleadoBusiness empleadoBusiness)
        {
            _empleadoBusiness = empleadoBusiness;
        }


        
        // GET: Empleado
        public async Task<IActionResult> Index()
        {
            return View(await _empleadoBusiness.ObtenerListaEmpleados());
        }
        
        // GET: Empleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _empleadoBusiness.ObtenerEmpleadoPorId(id.Value);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }
        
        // GET: Empleado/Create
        public IActionResult Create()
        {
            ViewData["listaCargos"] = _empleadoBusiness.ObtenerListaCargos();
            return View();
        }

        
        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleadoId,Nombre,Apellido,Documento,Email,Celular,Contrasena,CargoId")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {

                var empleadoTemporal = await _empleadoBusiness.ObtenerEmpleadoPorDocumento(empleado.Documento);

                if (empleadoTemporal == null)
                {
                    await _empleadoBusiness.CrearEmpleado(empleado);

                    return RedirectToAction(nameof(Index));
                }
                    
            }
            ViewData["listaCargos"] = _empleadoBusiness.ObtenerListaCargos();
            ViewData["error"] = "Documento ya registrado";
            return View(empleado);
        }

        
        // GET: Empleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _empleadoBusiness.ObtenerEmpleadoPorId(id.Value);
            if (empleado == null)
            {
                return NotFound();
            }

            ViewData["listaCargos"] = _empleadoBusiness.ObtenerListaCargos();
            return View(empleado);
        }
        
        // POST: Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpleadoId,Nombre,Apellido,Documento,Email,Celular,Contrasena,CargoId")] Empleado empleado)
        {
            if (id != empleado.EmpleadoId)
            {
                return NotFound();
            }


            var empleadoTemporal = await _empleadoBusiness.ObtenerEmpleadoPorDocumento(empleado.Documento);

            if (empleadoTemporal == null || (empleadoTemporal.EmpleadoId == empleado.EmpleadoId) ) {

                if (ModelState.IsValid)
                {
                   
                    await _empleadoBusiness.EditarEmpleado(empleado);
                    return RedirectToAction(nameof(Index));
                }
                    
                }

            ViewData["listaCargos"] = _empleadoBusiness.ObtenerListaCargos();

            ViewData["error"] = "Documento Ya registrado";

            return View(empleado);
        }

            
        
        
        // GET: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _empleadoBusiness.ObtenerEmpleadoPorId(id.Value);

            if(empleado.CambioEstado == true)
            {
                await _empleadoBusiness.CambiarEstadoInactivoEmpleado(id.Value);
            }
            else
            {
                await _empleadoBusiness.CambiarEstadoActivoEmpleado(id.Value);
            }

            

            return RedirectToAction(nameof(Index));
        }

        /*
        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.EmpleadosPrivTours.FindAsync(id);
            _context.EmpleadosPrivTours.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.EmpleadosPrivTours.Any(e => e.EmpleadoId == id);
        }*/
    }
}
