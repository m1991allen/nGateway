using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nGateway.Models
{
    public class RunDownArgs
    {
        public string columnDate { get; set; }
        public string deviceName { get; set; }
    }
    public class Rundown
    {
        public string columnDate { get; set; }
        public string billTitle { get; set; }
        public string columnName { get; set; }
        public string billGuid { get; set; }
        public string deviceName { get; set; }
    }
}
