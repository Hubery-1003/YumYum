using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using yum_admin.Models;

namespace yum_admin.Controllers
{
    public class UserSecretInfoesController : Controller
    {
        private readonly YumyumdbContext _context;

        public UserSecretInfoesController(YumyumdbContext context)
        {
            _context = context;
        }

        // GET: UserSecretInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserSecretInfos.ToListAsync());
        }

        // GET: UserSecretInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSecretInfo = await _context.UserSecretInfos
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userSecretInfo == null)
            {
                return NotFound();
            }

            return View(userSecretInfo);
        }

        // GET: UserSecretInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserSecretInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserNickname,Email,Password,EmailChecked,EmailValidCode")] UserSecretInfo userSecretInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userSecretInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userSecretInfo);
        }

        // GET: UserSecretInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSecretInfo = await _context.UserSecretInfos.FindAsync(id);
            if (userSecretInfo == null)
            {
                return NotFound();
            }
            return View(userSecretInfo);
        }

        // POST: UserSecretInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserNickname,Email,Password,EmailChecked,EmailValidCode")] UserSecretInfo userSecretInfo)
        {
            if (id != userSecretInfo.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSecretInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSecretInfoExists(userSecretInfo.UserId))
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
            return View(userSecretInfo);
        }

        // GET: UserSecretInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSecretInfo = await _context.UserSecretInfos
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userSecretInfo == null)
            {
                return NotFound();
            }

            return View(userSecretInfo);
        }

        // POST: UserSecretInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userSecretInfo = await _context.UserSecretInfos.FindAsync(id);
            if (userSecretInfo != null)
            {
                _context.UserSecretInfos.Remove(userSecretInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserSecretInfoExists(int id)
        {
            return _context.UserSecretInfos.Any(e => e.UserId == id);
        }
    }
}
