using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace baosteelApi.Models
{
    public class MaintenanceItem
    {
        [Key]
        public int ID { get; set; }

        public string DEVICE_ID { get; set; }

        public string PROJECT_NAME { get; set; }

        public string DETAIL { get; set; }

        public int PERIOD { get; set; }

        public string KEY_POINT { get; set; }

        public string INDICATION { get; set; }

        public DateTime CREATE_DATE { get; set; }

        public string RESPONSIBLE { get; set; }

        public string NOTE { get; set; }
    }
}
