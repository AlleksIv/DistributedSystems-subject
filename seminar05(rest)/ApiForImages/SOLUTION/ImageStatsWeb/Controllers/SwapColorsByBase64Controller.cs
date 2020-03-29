using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageStats;
using ImageStats.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageStatsWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SwapColorsByBase64Controller : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "It swaps colors of an image";
        }
        //POST: 
        [HttpPost]
        public string Post([FromBody]ColorSwapRequest request)
        {
            string base64string = request.base64string;
            string from = request.from;
            string to = request.to;
            if (base64string != null && Enum.TryParse(from, out AvailableColorNames From) && Enum.TryParse(to, out AvailableColorNames To))
            {
                ColorService _colorService = new ColorService();
                return ImageHelper.ImageToBase64(_colorService.SwapColorsFromBase64(base64string, From, To));
            }
            else
                return "Invalid parameters, try again.";
        }

    }
}