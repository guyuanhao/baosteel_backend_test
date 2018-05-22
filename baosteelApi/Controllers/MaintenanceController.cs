using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using baosteelApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace baosteelApi.Controllers
{
    [Route("api/[controller]")]
    public class MaintenanceController : ControllerBase
    {
        private readonly CheckContext _context;

        [HttpGet]
        public List<MaintenanceItem> GetAll()
        {
            return _context.MAINTENANCE_ITEMS.ToList();
        }
    }
}
