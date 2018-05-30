using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using baosteelApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace baosteelApi.Controllers
{
    [Route("api/[controller]")]
    public class InfoController : Controller
    {
        private readonly CheckContext _context;

        public InfoController(CheckContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAll/{option}")]
        public List<InfoItem> GetAll(string option)
        {
            if (option.Equals("Checked"))
            {
                var items = from i in _context.INFO_ITEMS
                            where i.IF_CHECK
                            select i;
                return items.ToList();
            }
            else if (option.Equals("Unchecked"))
            {
                var items = from i in _context.INFO_ITEMS
                            where !i.IF_CHECK
                            select i;
                return items.ToList();
            }
            else
            {
               return _context.INFO_ITEMS.ToList();
            }
        }

        [HttpGet("{id}", Name = "GetInfo_Item")]
        public IActionResult GetById(int id)
        {
            var item = _context.INFO_ITEMS.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet]
        [Route("getByDeviceId/{id}/{option}")]
        public IActionResult GetByDeviceId(string id, string option)
        {
            if (option.Equals("Checked"))
            {
                var items = from m in _context.INFO_ITEMS
                            where (m.DEVICE_ID.StartsWith(id) && m.IF_CHECK)
                            select m;
                return Ok(items.ToList());
            }
            else if (option.Equals("Unchecked"))
            {
                var items = from m in _context.INFO_ITEMS
                            where (m.DEVICE_ID.StartsWith(id) && !m.IF_CHECK)
                            select m;
                return Ok(items.ToList());
            }
            else
            {
                var items = from m in _context.INFO_ITEMS
                            where m.DEVICE_ID.StartsWith(id)
                            select m;
                return Ok(items.ToList());
            }
        }

        [HttpGet]
        [Route("checkInfo/{maintenanceId}")]
        public IActionResult checkInfo(int maintenanceId)
        {
            var items = from i in _context.INFO_ITEMS
                        where i.MAINTENANCE_ITEM.Equals(maintenanceId)
                        select i;

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
        public IActionResult Create([FromBody] List<InfoItem> items)
        {
            List<InfoItem> resluts = new List<InfoItem>();
            List<IActionResult> actionResults = new List<IActionResult>();
            if (items == null)
            {
                return BadRequest();
            }

            foreach (InfoItem item in items)
            {
                _context.INFO_ITEMS.Add(item);
                _context.SaveChanges();
                resluts.Add((InfoItem)CreatedAtRoute("GetInfo_Item", new { id = item.ID }, item).Value);
            }
            return Ok(resluts);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] InfoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            InfoItem infoItem = _context.INFO_ITEMS.Find(id);
            if (infoItem == null)
            {
                return NotFound();
            }

            infoItem.NOTE = item.NOTE;
            infoItem.CHECK_DATE = item.CHECK_DATE;
            infoItem.IF_CHECK = item.IF_CHECK;
            infoItem.MAINTENANCE_ITEM = item.MAINTENANCE_ITEM;
            infoItem.TARGET_TIME = item.TARGET_TIME;

            _context.INFO_ITEMS.Update(infoItem);
            _context.SaveChanges();
            return Ok(infoItem);
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    InfoItem infoItem = _context.INFO_ITEMS.Find(id);
        //    if (infoItem == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.INFO_ITEMS.Remove(infoItem);
        //    _context.SaveChanges();
        //    return Ok();
        //}

    }
}
