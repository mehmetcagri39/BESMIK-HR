using BESMIK.BLL.Managers.Concrete;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Company;
<<<<<<< HEAD
=======
using BESMIK.ViewModel.CompanyManager;
>>>>>>> 439bb745b7c296314ea70bc1a879c2325d5c3004
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using BLLCompanyManager = BESMIK.BLL.Managers.Concrete.CompanyManager;

namespace BESMIK.API.Controllers
{
    [ApiController]
<<<<<<< HEAD
    [Route("api/[controller]")]
=======
    [Route("[controller]")]
>>>>>>> 439bb745b7c296314ea70bc1a879c2325d5c3004


    public class CompanyController : Controller
    {
        private readonly BLLCompanyManager _companyManager;
<<<<<<< HEAD
        //private CompanyManagerManager _companyManagerMan;

        public CompanyController(BLLCompanyManager companyManager)
        {
            _companyManager = companyManager;
           // _companyManagerMan = managerManagerMan;
=======
        private CompanyManagerManager _companyManagerMan;

        public CompanyController(BLLCompanyManager companyManager, CompanyManagerManager managerManagerMan)
        {
            _companyManager = companyManager;
            _companyManagerMan = managerManagerMan;
>>>>>>> 439bb745b7c296314ea70bc1a879c2325d5c3004
        }

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Şirket ekleme

        [HttpPost("AddCompany")]
<<<<<<< HEAD
        public IActionResult Post([FromBody] CompanyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _companyManager.Add(model);
            return Ok(model);
        }

        //[HttpPost("AddCompany")]
        //public IActionResult Post([FromBody] CompanyViewModel companyViewModel)
        //{
        //    _companyManager.Add(companyViewModel);
        //    return CreatedAtAction(nameof(GetCompany), new { id = companyViewModel.Id }, companyViewModel);
        //}

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Şirket Listeleme
        [HttpGet("CompanyList")]
        public ActionResult<IEnumerable<CompanyViewModel>> CompanyGet()
        {
            return Ok(_companyManager.GetAll());
=======
        public IActionResult Post([FromBody] CompanyViewModel companyViewModel)
        {
            _companyManager.Add(companyViewModel);
            return Created("", companyViewModel);

        }

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Şirket Listeleme
        [HttpGet("CompanyList")]
        public IEnumerable<CompanyViewModel> CompanyGet()
        {
            return _companyManager.GetAll();
>>>>>>> 439bb745b7c296314ea70bc1a879c2325d5c3004
        }

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Şirketi ID'sine göre getirme
<<<<<<< HEAD
        [HttpGet("{id}")]
        public ActionResult<CompanyViewModel> GetCompany(int id)
=======
        [HttpGet("Companies/{id}")]
        public IActionResult GetCompany(int id)
        {
            return Ok(_companyManager.Get(id));
        }

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //ID'si seçilen şirketin yöneticilerini getirme

        [HttpGet("Companies/{id}/Managers")]
        public IActionResult GetCompanyManagers(int id)
>>>>>>> 439bb745b7c296314ea70bc1a879c2325d5c3004
        {
            var company = _companyManager.Get(id);
            if (company == null)
            {
<<<<<<< HEAD
                return NotFound();
            }
            return Ok(company);
=======
                return NotFound("Company not found.");
            }

            var companyManagers = _companyManagerMan.GetManagersByCompanyID(id);
            if (!companyManagers.Any())
            {
                return NotFound("No managers found for the specified company ID.");
            }

            return Ok(companyManagers);
>>>>>>> 439bb745b7c296314ea70bc1a879c2325d5c3004
        }



<<<<<<< HEAD
        //company manager tablosu silinidigi için kaldırdım sc
        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //ID'si seçilen şirketin yöneticilerini getirme
        //[HttpGet("{id}/Managers")]
        //public ActionResult<IEnumerable<CompanyManagerViewModel>> GetCompanyManagers(int id)
        //{
        //    var company = _companyManager.Get(id);
        //    if (company == null)
        //    {
        //        return NotFound("Company not found.");
        //    }

        //    var companyManagers = _companyManagerMan.GetManagersByCompanyID(id);
        //    if (companyManagers == null || !companyManagers.Any())
        //    {
        //        return NotFound("No managers found for the specified company ID.");
        //    }

        //    return Ok(companyManagers);
        //}

=======
>>>>>>> 439bb745b7c296314ea70bc1a879c2325d5c3004
        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Şirket silme, (isterlerde yok)

        [HttpDelete("DeleteCompany/{id}")] //Buna anlaşılır bir isim düşünemedim, değiştirilebilir.
        public IActionResult DeleteCompany(int id)
        {
            CompanyViewModel? company = _companyManager.Get(id);

            if (company == null)
                return NotFound();

            _companyManager.Delete(company);

            return StatusCode(220, "Company deletion is completed.");
        }

    }
}
