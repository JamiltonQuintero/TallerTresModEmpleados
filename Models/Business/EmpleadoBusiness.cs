using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerTresModEmpleados.Models.Abstract;
using TallerTresModEmpleados.Models.DAL;
using TallerTresModEmpleados.Models.Entities;

namespace TallerTresModEmpleados.Models.Business
{
    public class EmpleadoBusiness: IEmpleadoBusiness
    {
        private readonly DbContextProyecto _context;

        public EmpleadoBusiness(DbContextProyecto context)
        {
            _context = context;
        }
        
        /*public IEnumerable<Cargo> ObtenerListaCargo()
        {
            return (_context.CargosPrivTours.ToList());
        }*/



    }
}
