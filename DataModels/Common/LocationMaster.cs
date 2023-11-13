using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Common
{
    public class LocationMaster
    {
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string? Radius { get; set; }
        public string? Area { get; set; }
        public long Population { get; set; }
    }
}
