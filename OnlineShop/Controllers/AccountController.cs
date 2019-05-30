using OnlineShop.Interface;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {

        OnlineShopContext db = new OnlineShopContext();
        // GET: Account
        IAuthProvider authProvider;
        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration(Registration registration)
        {
            if (ModelState.IsValid)
            {
                UserAccount userAccount = null;
                using (OnlineShopContext db = new OnlineShopContext())
                {
                    userAccount = await db.UserAccounts.FirstOrDefaultAsync(u => u.UserName == registration.UserName);
                }
                if (userAccount == null)
                {
                    using (OnlineShopContext db = new OnlineShopContext())
                    {

                        db.UserAccounts.Add(new UserAccount { UserName = registration.UserName, Email = registration.Email, Password = registration.Password, PasswordConfirm = registration.PasswordConfirm, Name = registration.Name, Surname = registration.Surname, Year = registration.Year, RoleID = 1 });
                        await db.SaveChangesAsync();

                        userAccount = await db.UserAccounts.Where(u => u.UserName == registration.UserName && u.Password == registration.Password).FirstOrDefaultAsync();
                    }
                    if (userAccount != null)
                    {
                        FormsAuthentication.SetAuthCookie(registration.UserName, true);
                        return RedirectToAction("List", "CarModel");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }

            }
            return View(registration);

        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                UserAccount userAccount = null;
                using (OnlineShopContext db = new OnlineShopContext())
                {
                    userAccount = await db.UserAccounts.FirstOrDefaultAsync(u => u.UserName == login.UserName && u.Password == login.Password);
                }
                if (userAccount != null)
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, true);

                    return RedirectToAction("List", "CarModel");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(login);
        }
        public ActionResult Logout()
        {
            Session["LoginSuccess"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("List", "CarModel");
        }
        public async Task<ActionResult> Edit()
        {
            var username = HttpContext.User.Identity.Name;

            UserAccount userAccount = await db.UserAccounts.FirstOrDefaultAsync((a) => a.UserName == username);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", userAccount.RoleID);
            return View(userAccount);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AccountId,UserName,Email,Password,PasswordConfirm,Name,Surname,Year,RoleID")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {

                db.Entry(userAccount).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", "Account");
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", userAccount.RoleID);

            return View(userAccount);
        }


        public async Task<ActionResult> Delete()
        {
            var username = HttpContext.User.Identity.Name;
            UserAccount userAccount = await db.UserAccounts.FirstOrDefaultAsync((a) => a.UserName == username);

            return View(userAccount);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([Bind(Include = "AccountId,UserName,Email,Password,PasswordConfirm,Name,Surname,Year,RoleID")] UserAccount userAccount)
        {
            var username = HttpContext.User.Identity.Name;
            userAccount = await db.UserAccounts.FirstOrDefaultAsync((a) => a.UserName == username);
            db.UserAccounts.Remove(userAccount);
            await db.SaveChangesAsync();
            return RedirectToAction("List", "CarModel");
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        
    }
}