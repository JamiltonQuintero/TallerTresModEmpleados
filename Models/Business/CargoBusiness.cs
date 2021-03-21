using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerTresModEmpleados.Models.Abstract;
using TallerTresModEmpleados.Models.DAL;

namespace TallerTresModEmpleados.Models.Business
{
    public class CargoBusiness : ICargoBusiness
    {

        private readonly DbContextProyecto _context;

        public CargoBusiness(DbContextProyecto context)
        {
            _context = context;
        }
    }
}
