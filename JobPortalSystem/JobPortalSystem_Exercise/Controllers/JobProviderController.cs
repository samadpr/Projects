using AutoMapper;
using JobPortalSystem_Exercise.Dtos;
using JobPortalSystem_Exercise.Interface;
using JobPortalSystem_Exercise.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalSystem_Exercise.Controllers
{
    public class JobProviderController : Controller
    {
        private readonly IJobProviderService _jobProviderService;
        private IMapper _mapper;
        private readonly JobPortalExDbContext _context;

        public JobProviderController(IJobProviderService jobProviderService, IMapper mapper, JobPortalExDbContext context)
        {
            _jobProviderService = jobProviderService;
            _mapper = mapper;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            string id = HttpContext.Session.GetString("UserId");
            Guid Id = Guid.Parse(id);

            var result = _jobProviderService.GetUserDetails(Id);

            if (result != null)
            {
                ViewBag.role = HttpContext.Session.GetString("Role");
                return View(result);
            }

            return View();
        }

        public IActionResult AddJobs()
        {
            return View();
        }

        public IActionResult ListJobs()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult AppliedJobs()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CompanyRegistration()
        {
            var company = new CompanyDto();
            return View(company);
        }

        [HttpPost]
        public IActionResult CompanyRegistration(CompanyDto companyDto)
        {
            try
            {
                
                if (ModelState.IsValid && companyDto.ImageFile != null)
                {
                    Guid id = Guid.Parse(HttpContext.Session.GetString("UserId"));

                    var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();

                    if(user.Email != companyDto.Email)
                    {
                        ViewBag.errorMessage = "email already exists(your email and company email should be unique)";
                        return View(companyDto);
                    }
                    if(companyDto.ImageFile != null && companyDto.ImageFile.Length > 0)
                    {
                        using(var memoryStream = new MemoryStream())
                        {
                            companyDto.ImageFile.CopyTo(memoryStream);
                            companyDto.Image = Convert.ToBase64String(memoryStream.ToArray());
                        }
                    }
                    var company = _mapper.Map<Company>(companyDto);

                    if(companyDto.ImageFile != null)
                    {
                        using(var memoryStream = new MemoryStream())
                        {
                            companyDto.ImageFile.CopyTo(memoryStream);
                            company.Logo = memoryStream.ToArray();
                        }
                    }

                    var result = _jobProviderService.CompanyRegistration(company);
                    if (result != null)
                    {
                        HttpContext.Session.SetString("CompanyId", result.Id.ToString());
                        ViewBag.successMessage = "Company registration successful";
                        return RedirectToAction("CompanyProfile", "JobProvider");

                    }
                    ViewBag.errorMessage = "Company registration failed ( your company has already been registered)";
                    return View(companyDto);

                }

                ViewBag.errorMessage = "Invalid data all fields are required";
                return View(companyDto);

                
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult CompanyProfile()
        {
            string id = HttpContext.Session.GetString("UserId");
            Guid Id = Guid.Parse(id);

            var user = _jobProviderService.GetUserDetails(Id);

            if (user != null && user.CompanyId.HasValue)
            {
                Guid companyId = user.CompanyId.Value;
                var company = _jobProviderService.GetCompanyDetails(companyId);
                if (company != null)
                {
                    return View(company);
                }
                return View();
            }
            return RedirectToAction("CompanyRegistration", "JobProvider");
        }
    }
}
