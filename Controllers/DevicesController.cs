using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : Controller
    {
        private readonly IHostEnvironment _env;

        public DevicesController(IHostEnvironment env)
        {
            _env = env;
        }


        /// <summary>
        /// Поиск и загрузка инструкции по использованию устройства
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpHead]
        [Route("{manufacturer}")]
        public IActionResult GetManual([FromRoute] string manufacturer)
        {
            var staticPath = Path.Combine(_env.ContentRootPath, "Static");

            var filePuth = Directory.GetFiles(staticPath)
                .FirstOrDefault(f => f.Split("\\")
                .Last()
                .Split('.')[0] == manufacturer);

            if (string.IsNullOrEmpty(filePuth))
                return StatusCode(404, $"Инструкция '{manufacturer}' не найдена.");

            string fileType = "application/pdf";
            string fileName = $"{manufacturer}.pdf";

            return PhysicalFile(filePuth, fileType, fileName);
        }
    }
}
