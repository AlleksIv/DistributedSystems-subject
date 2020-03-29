using System;
using ImageStats;
using ImageStats.Utility;
using Microsoft.AspNetCore.Mvc;


namespace ImageStatsWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SwapColorsByUrlController : ControllerBase
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
            string url = request.url;
            string from = request.from;
            string to =  request.to;
            if (url != null && Enum.TryParse(from, out AvailableColorNames From) && Enum.TryParse(to, out AvailableColorNames To))
            {
                ColorService _colorService = new ColorService();
                return ImageHelper.ImageToBase64(_colorService.SwapColorsFromUrl(url, From, To));
            }
            else
                return "Invalid parameters, try again.";
        }


    }
}
