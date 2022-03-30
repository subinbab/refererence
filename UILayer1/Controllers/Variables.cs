using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiLayer.Controllers
{
    public class Variables : Controller
    {
        private readonly IConfiguration configuration;
        public Variables(IConfiguration config)
        {
            configuration = config;
        }
        public IActionResult BaseApi()
        {
            var url = configuration.GetSection("Development")["ApiBaseUrl"].ToString();
            return Json(new { parameter = url });
        }
    }
}
