
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _6lr.Controllers
{
    [Authorize]
    [ApiVersion("1.0"/*, Deprecated = true*/)]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    [Route("api/")]
    public class VersionController : ControllerBase
    {
        private readonly IVersionService _versionService;

        public VersionController(IVersionService versionService)
        {
            _versionService = versionService;
        }

        [HttpGet, MapToApiVersion("1.0")]
        [Route("1.0")]
        [Obsolete("This version of the API is deprecated.")]
        public async Task<ActionResult> Get1()
        {
            int data = _versionService.GetIntegerData();
            return Ok(data);
        }

        [HttpGet, MapToApiVersion("2.0")]
        [Route("2.0")]
        public async Task<ActionResult> Get2()
        {
            string data = _versionService.GetTextData();
            return Ok(data);
        }

        [HttpGet, MapToApiVersion("3.0")]
        [Route("3.0")]
        public async Task<ActionResult> Get3()
        {
            Stream excelStream = _versionService.GenerateExcel();
            return File(excelStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "data.xlsx");
        }
    }
}
