using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nGateway.Models
{
    public class NewsArgs
    {
        public string billGuid { get; set; }
    }
    public class News
    {
        public string billItemContent { get; set; }
        public short? billItemIndex { get; set; }
        public string billItemGuid { get; set; }
        public string billItemActualID { get; set; }
        public string billItemTitle { get; set; }
    }
}
