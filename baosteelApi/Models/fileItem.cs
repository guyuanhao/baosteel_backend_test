using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace baosteelApi.Models
{
    public class fileItem
    {
        public IFormFile file { get; set; }

        public int id { get; set; }
    }
}
