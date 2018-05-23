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

        public MaintenanceController(CheckContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<MaintenanceItem> GetAll()
        {
            return _context.MAINTENANCE_ITEMS.ToList();
        }

        [HttpGet("{id}", Name = "GetMaintenance_Item")]
        public IActionResult GetById(int id)
        {
            var item = _context.MAINTENANCE_ITEMS.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] List<MaintenanceItem> items)
        {
            List<MaintenanceItem> resluts = new List<MaintenanceItem>();
            List<IActionResult> actionResults = new List<IActionResult>();
            if (items == null)
            {
                return BadRequest();
            }

            foreach(MaintenanceItem item in items)
            {
                _context.MAINTENANCE_ITEMS.Add(item);
                _context.SaveChanges();
                resluts.Add((MaintenanceItem)CreatedAtRoute("GetMaintenance_Item", new { id = item.ID }, item).Value);
            }
            return Ok(resluts);
        }
    }
}
