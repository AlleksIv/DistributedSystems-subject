using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageStatsWeb
{
    public class ColorSwapRequest
    {
       public string url { get; set; }
        public string base64string { get; set; }
        public string from { get; set; }
        public string to { get; set; }
    }
}
