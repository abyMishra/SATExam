using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Common
{
    public class CultureInfoMaster
    {
        public string? Country { get; set; }
        public string? CultureName { get; set; }
        public string? WritingSystem { get; set; }
        public string? TimeZone { get; set; }
        public string? format { get; set; }
    }
}
