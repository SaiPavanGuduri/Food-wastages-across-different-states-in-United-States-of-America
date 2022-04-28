using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Assignment_4.Models.Api
{
    public class ReportRootobject
    {
        public Meta meta { get; set; }
        public List<ReportApiResult> results { get; set; }
    }

    public class ReportApiResult
    {
        public string time { get; set; }
        public string year => time.Substring(0, 4);
        public int count { get; set; }
    }

}
