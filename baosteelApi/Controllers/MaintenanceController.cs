using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using baosteelApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace baosteelApi.Controllers
{
    [Route("api/[controller]")]
    public class MaintenanceController : Controller
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

        [HttpGet]
        [Route("getByDeviceId/{id}")]
        public IActionResult GetByDeviceId(string id)
        {
            var items = from m in _context.MAINTENANCE_ITEMS
                        where m.DEVICE_ID.StartsWith(id)
                        select m;

            return Ok(items.ToList());
        }

        //[HttpPost]
        //public IActionResult Create([FromBody] MaintenanceItem item)
        //{
        //    if (item == null)
        //    {
        //        return BadRequest();
        //    }

        //        _context.MAINTENANCE_ITEMS.Add(item);
        //        _context.SaveChanges();
        //    return CreatedAtRoute("GetMaintenance_Item", new { id = item.ID }, item);
        //}

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

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MaintenanceItem item)
        {
            if (item == null )
            {
                return BadRequest();
            }

            MaintenanceItem maintenanceItem = _context.MAINTENANCE_ITEMS.Find(id);
            if (maintenanceItem == null)
            {
                return NotFound();
            }

            maintenanceItem.INDICATION = item.INDICATION;
            maintenanceItem.KEY_POINT = item.KEY_POINT;
            maintenanceItem.NOTE = item.NOTE;
            maintenanceItem.PERIOD = item.PERIOD;
            maintenanceItem.PROJECT_NAME = item.PROJECT_NAME;
            maintenanceItem.RESPONSIBLE = item.RESPONSIBLE;
            maintenanceItem.DETAIL = item.DETAIL;

            _context.MAINTENANCE_ITEMS.Update(maintenanceItem);
            _context.SaveChanges();
            return Ok(maintenanceItem);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            MaintenanceItem maintenanceItem = _context.MAINTENANCE_ITEMS.Find(id);
            if (maintenanceItem == null)
            {
                return NotFound();
            }

            _context.MAINTENANCE_ITEMS.Remove(maintenanceItem);
            var infoItems = from i in _context.INFO_ITEMS
                        where i.MAINTENANCE_ITEM.Equals(id)
                        select i;
            foreach (InfoItem i in infoItems)
            {
                _context.INFO_ITEMS.Remove(i);
            }
            _context.SaveChanges();
            return Ok();
        }

    }
}
