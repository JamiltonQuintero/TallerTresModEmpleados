using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TallerTresModEmpleados.Models.Abstract;
using TallerTresModEmpleados.Models.Entities;

namespace TallerTresModEmpleados.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoBusiness _iEmpleadoBusiness;
        private readonly ICargoBusiness _iCargoBusiness;
        public EmpleadoController(IEmpleadoBusiness empleadoBusiness, ICargoBusiness cargoBusiness)
        {
            _iEmpleadoBusiness = empleadoBusiness;
            _iCargoBusiness = cargoBusiness;
        }
        
        // GET: Empleado
        public async Task<IActionResult> Index()
        {
           return View(await _iEmpleadoBusiness.ObtenerListaEmpleados());
        }
        
        // GET: Empleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _iEmpleadoBusiness.ObtenerEmpleadoPorId(id.Value);

            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }
        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["listaCargos"] = new SelectList(_iCargoBusiness.ObtenerListaCargosEmpleados(), "CargoId", "Nombre");
            return View();
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleado empleado)
        {

            if (ModelState.IsValid)
            {
                var empleadoTemp = await _iEmpleadoBusiness.ObtenerEmpleadoPorDocumento(empleado.Documento);
                if (empleadoTemp == null)
                {
                    await _iEmpleadoBusiness.GuardarEmpleado(empleado);
                    return RedirectToAction(nameof(Index));
                }
            }
            if (empleado.CargoId == 0)
            {
                ViewData["errorCargo"] = "Seleccione un cargo";
            }
            ViewData["error"] = "Documento ya registrado";

            ViewData["listaCargos"] = new SelectList(_iCargoBusiness.ObtenerListaCargosEmpleados(), "CargoId", "Nombre");

            return View(empleado);
        }
        /*
        // GET: Empleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.EmpleadosPrivTours.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
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

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.EmpleadoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.EmpleadosPrivTours
                .FirstOrDefaultAsync(m => m.EmpleadoId == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

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
