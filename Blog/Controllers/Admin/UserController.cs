using Blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        //
        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //
        // GET: User/List
        public ActionResult List()
        {
            using (var database = new BlogDbContext())
            {
                var users = database.Users
                    .ToList();

                var admins = GetAdminUserNames(users, database);
                ViewBag.Admins = admins;

                return View(users);
            }
        }

        //
        // GET: User/Edit
        public ActionResult Edit(string id)
        {
            // Validate Id
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                // Get user from database
                var user = database.Users
                    .Where(u => u.Id == id)
                    .First();

                // Check if user exists
                if (user == null)
                {
                    return HttpNotFound();
                }

                // Create a view model
                var viewModel = new EditUserViewModel();
                viewModel.User = user;
                viewModel.Roles = GetUserRoles(user, database);

                // Pass the model to the view
                return View(viewModel);
            }
        }

        //
        // POST: User/Edit
        [HttpPost]
        public ActionResult Edit(string id, EditUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id.Equals(id));

                    if (user == null)
                    {
                        //
                    }

                    user.Email = viewModel.User.Email;
                    user.FullName = viewModel.User.FullName;
                    user.UserName = viewModel.User.Email;

                    if (!string.IsNullOrEmpty(viewModel.Password))
                    {
                        var passwordHasher = new PasswordHasher();
                        var newPasswordHash = passwordHasher.HashPassword(viewModel.Password);
                        user.PasswordHash = newPasswordHash;
                    }

                    SetUserRoles(user, db, viewModel);

                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("List");
            }

            return View(viewModel);
        }

        //
        // GET: User/Delete
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                // Get user from database
                var user = database.Users
                    .Where(u => u.Id.Equals(id))
                    .First();

                // Check if user exists
                if (user == null)
                {
                    return HttpNotFound();
                }

                return View(user);
            }
        }

        //
        // POST: User/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                // Get user from database
                var user = database.Users
                    .Where(u => u.Id.Equals(id))
                    .First();

                // Get user articles from database
                var userArticles = database.Articles
                    .Where(a => a.Author.Id == user.Id);

                // Delete user articles
                foreach (var article in userArticles)
                {
                    database.Articles.Remove(article);
                }

                // Delete user and save changes
                database.Users.Remove(user);
                database.SaveChanges();

                return RedirectToAction("List");
            }
        }

        private HashSet<string> GetAdminUserNames(List<ApplicationUser> users, BlogDbContext context)
        {
            var admins = new HashSet<string>();

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            foreach (var user in users)
            {
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    admins.Add(user.UserName);
                }
            }

            return admins;
        }

        private void SetUserRoles(ApplicationUser user, BlogDbContext db, EditUserViewModel model)
        {
            var userManager = Request
                .GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

            foreach (var role in model.Roles)
            {
                if (role.IsSelected)
                {
                    userManager.AddToRole(user.Id, role.Name);
                }
                else if (!role.IsSelected)
                {
                    userManager.RemoveFromRole(user.Id, role.Name);
                }
            }
        }

        private void ChangeUserPassword(string userId, EditUserViewModel viewModel)
        {
            // Create user manager
            var userManager = Request.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

            // Create password reset token
            var token = userManager.GeneratePasswordResetToken(userId);
            var result = userManager.ResetPassword(userId, token, viewModel.Password);

            // Check if operation succeeded
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private List<Role> GetUserRoles(ApplicationUser user, BlogDbContext context)
        {
            // Create user and role managers
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            // Get all application roles
            var roles = roleManager.Roles
                .Select(r => r.Name)
                .OrderBy(r => r)
                .ToList();

            // For each application role, check if the user has it
            var userRoles = new List<Role>();

            foreach (var roleName in roles)
            {
                var role = new Role { Name = roleName };

                if (userManager.IsInRole(user.Id, roleName))
                {
                    role.IsSelected = true;
                }

                userRoles.Add(role);
            }

            // Return a list with all roles
            return userRoles;
        }
    }
}