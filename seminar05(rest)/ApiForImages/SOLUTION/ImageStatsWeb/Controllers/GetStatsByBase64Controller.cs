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
    public class GetStatsByBase64Controller : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "it gets stats of an image by base64 string";
        }
        [HttpPost]
        public string Post([FromBody]ColorStatsRequest request)
        {
            string base64string = request.base64string;
            if (base64string != null)
            {
                ColorService _colorService = new ColorService();
                return _colorService.GetStats(ImageHelper.Base64ToImage(base64string));
            }
            else
                return "Invalid parameters, try again.";
        }
    }

}