using Foundation.DTOs;
using Foundation.Data;
using Microsoft.AspNetCore.Mvc;

namespace Foundation.Controllers
{
    
    
    public class AccountController : Controller
    {
        ApplicationDBContext _dbContext;
        public AccountController(ApplicationDBContext dBContext )
        {
            _dbContext=dBContext;
        }
      
        public IActionResult Index()
        {
            return View ();
        }
        public IActionResult Login(LoginDT  login)
        {
            try { 
            
           var user= _dbContext.Users.FirstOrDefault(x=>x.Email==login.Email&&x.Password==login.Password);

            if (user!=null) 
            {
                return Json(new { result = true, message = "success" });
            }
            else
            {
                return Json(new { result = true, message = "Invalid username or password" });
            }
            }
            catch (Exception ex) 
            {
                return Json(new { result = true, message = ex.Message });
            }
           
        }
    }
}
