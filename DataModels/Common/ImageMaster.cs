using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Common
{
    public class ImageMaster
    {
        public string? ImageURL {  get; set; }
        public string? Description { get; set; }
        public string? ItineraryImage { get; set; }
        public string? AltText { get; set; }
    }
}
