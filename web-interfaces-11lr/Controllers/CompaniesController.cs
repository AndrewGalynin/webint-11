using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace _6lr.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase{

        private readonly ICompaniesService _companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var companies = await _companiesService.GetCompanies();
            return Ok(companies);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Companies company)
        {
            await _companiesService.AddCompany(company);
            return CreatedAtAction(nameof(Get), new { id = company.Id }, company);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Companies company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            await _companiesService.UpdateCompany(company);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companiesService.DeleteCompany(id);
            return NoContent();
        }
    }
}