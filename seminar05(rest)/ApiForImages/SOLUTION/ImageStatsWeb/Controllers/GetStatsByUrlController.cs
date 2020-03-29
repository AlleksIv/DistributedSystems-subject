using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageStats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageStatsWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetStatsByUrlController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "it gets stats of an image by image url";
        }
        [HttpPost]
        public string Post([FromBody]ColorStatsRequest request)
        {
          string  url = request.url;
        if (url != null)
        {
            ColorService _colorService = new ColorService();
            return _colorService.GetStatsFromUrl(url);
        }
        else
            return "Invalid parameters, try again.";
    }
    }
}