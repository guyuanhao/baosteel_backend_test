using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace baosteelApi.Models
{
    public class InfoItem
    {
        [Key]
        public int ID { get; set; }

        public int DEVICE_ID { get; set; }

        public string PROJECT_NAME { get; set; }

        public string DETAIL { get; set; }

        public string KEY_POINT { get; set; }

        public string INDICATION { get; set; }

        public Nullable<DateTime> CHECK_DATE { get; set; }

        public string RESPONSIBLE { get; set; }

        public Boolean IF_CHECK { get; set; }

        public string NOTE { get; set; }
    }
}
