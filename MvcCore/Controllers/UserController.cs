using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCore.Models;

namespace MvcCore.Controllers
{
    public class UserController : Controller
    {
        private static List<UserViewModel> users = new List<UserViewModel>() {
            new UserViewModel()
            {
                ID =Guid.Parse("f43874cb-032a-4403-a56b-4afd859c74db"),
                Name = "Oan",
                Birthday = DateTime.Now.AddYears(-10)
            }
        };

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(users);
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userViewModel = users.FirstOrDefault(m => m.ID == id);
            if (userViewModel == null)
            {
                return NotFound();
            }

            return View(userViewModel);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Birthday")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                userViewModel.ID = Guid.NewGuid();
                users.Add(userViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userViewModel = users.FirstOrDefault(m => m.ID == id);
            if (userViewModel == null)
            {
                return NotFound();
            }
            return View(userViewModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,Birthday")] UserViewModel userViewModel)
        {
            if (id != userViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var old = users.First(m => m.ID == id);
                    users.Remove(old);
                    users.Add(userViewModel);
                }
                catch (Exception)
                {
                    if (!UserViewModelExists(userViewModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userViewModel = users.FirstOrDefault(m => m.ID == id);
            if (userViewModel == null)
            {
                return NotFound();
            }

            return View(userViewModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userViewModel = users.FirstOrDefault(m => m.ID == id);
            users.Remove(userViewModel);
            return RedirectToAction(nameof(Index));
        }

        private bool UserViewModelExists(Guid id) => users.Any(e => e.ID == id);
    }
}
