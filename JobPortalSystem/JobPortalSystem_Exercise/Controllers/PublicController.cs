using AutoMapper;
using JobPortalSystem_Exercise.Dtos;
using JobPortalSystem_Exercise.Interface;
using JobPortalSystem_Exercise.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalSystem_Exercise.Controllers
{
    public class PublicController : Controller
    {
        private readonly IPublicService _publicService;
        private readonly IMapper _mapper;

        public string errorMessage = "";

        public PublicController(IPublicService publicService, IMapper mapper)
        {
            _publicService = publicService;
            _mapper = mapper;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _publicService.Login(loginDto);
                    if (result != null)
                    {
                        HttpContext.Session.SetString("UserId", result.Id.ToString());
                        HttpContext.Session.SetString("FullName", result.FirstName + " " + result.LastName);
                        //HttpContext.Session.SetString("Role", result.Role.ToString());
                        if (result.Role == 0)
                        {
                            HttpContext.Session.SetString("Role", "JobSeeker");
                            return RedirectToAction("Index", "JobSeeker");

                        }
                        else if (result.Role == 1)
                        {
                            HttpContext.Session.SetString("Role", "JobProvider");
                            return RedirectToAction("Index", "JobProvider");
                        }
                        else if (result.Role == 2)
                        {
                            HttpContext.Session.SetString("Role", "Admin");
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            ViewBag.errorMessage = "Invalid role" + result.Role.ToString() + "Role not found";
                            return View();
                        }

                    }

                    ViewBag.errorMessage = "Invalid email or password";
                }
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserDto userDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<User>(userDto);
                    var result = _publicService.Register(user);
                    if (result == null)
                    {
                        ViewBag.errorMessage = "User email already exists";
                        return View(userDto);
                    }

                    return RedirectToAction("Login", "Public");

                }
                ViewBag.errorMessage = "Invalid data";
                return View(userDto);
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
                return View(userDto);
            }

        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Public");
        }


    }
}
