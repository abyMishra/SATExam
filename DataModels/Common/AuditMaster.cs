using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Common
{
    public class AuditMaster
    {
        public string? created_by { get; set; }
        public string? created_date { get; set; }
        public string? updated_by { get; set; }
        public string? updated_date { get; set; }
    }
}
