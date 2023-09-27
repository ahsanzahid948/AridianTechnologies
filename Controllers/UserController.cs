
using Foundation.Data;
using Foundation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Integrations.Controllers
{
   
    public class UserController : Controller
    {
        ApplicationDBContext _dbContext;

        public UserController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
           var users= _dbContext.Users.Where(x => x.IsActive != false).ToList();
            return View(users);
        }
        public IActionResult Add(User user)
        {
            try {
                user.EntryDate = DateTime.Now;
                user.IsActive = true;
                var users = _dbContext.Users.Add(user);
                var result=_dbContext.SaveChanges();
               
                if (result > 0)
                {

                    return Json(new { result = true, message = "success" });
                }
                else {
                    return Json(new { result = false, message = "error saving user" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { result = false, message = ex.Message });
            }

            
        }
        public IActionResult Update(User user)
        {
            try
            {
                user.EntryDate = DateTime.Now;
                user.IsActive = true;
                var users = _dbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var result = _dbContext.SaveChanges();
                if (result > 0)
                {

                    return Json(new { result = true, message = "success" });
                }
                else
                {
                    return Json(new { result = false, message = "error updating user" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { result = false, message = ex.Message });
            }


            
        }
        public IActionResult Delete(int ID)
        {
            try
            {

                var user = _dbContext.Users.FirstOrDefault(x => x.ID == ID);
                user.IsActive = false; 

                var result = _dbContext.SaveChanges();
                if (result > 0)
                {

                    return Json(new { result = true, message = "success" });
                }
                else
                {
                    return Json(new { result = false, message = "error updating user" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { result = false, message = ex.Message });
            }



        }
    }
}
