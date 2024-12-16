using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using yum_admin.Models;
using BCrypt.Net;

namespace yum_admin.Controllers
{
    public class AdminsController : Controller
    {
        private readonly YumyumdbContext _context;

        public AdminsController(YumyumdbContext context)
        {
            _context = context;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Admins.ToListAsync());
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId,AdminAccount,AdminPassword,AdminName,AdminEmail,AdminHeadShot,AdminPhone")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("AdminId,AdminAccount,AdminPassword,AdminName,AdminEmail,AdminHeadShot,AdminPhone")] Admin admin)
        //{
        //    if (id != admin.AdminId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(admin);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AdminExists(admin.AdminId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(admin);
        //}

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.AdminId == id);
        }

        // GET: Admins
        public async Task<IActionResult> Admin()
        {
            return View(await _context.Admins.ToListAsync());
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Admin admin)
        {
            // 從資料庫查找現有的記錄
            var existingAdmin = _context.Admins.Find(id);
            if (existingAdmin == null)
            {
                return NotFound();
            }

            // 如果密碼欄位不為空，則加密並更新密碼
            if (!string.IsNullOrEmpty(admin.AdminPassword))
            {
                existingAdmin.AdminPassword = BCrypt.Net.BCrypt.HashPassword(admin.AdminPassword);
            }

            // 更新其他欄位
            existingAdmin.AdminAccount = admin.AdminAccount;
            existingAdmin.AdminName = admin.AdminName;
            existingAdmin.AdminEmail = admin.AdminEmail;
            existingAdmin.AdminPhone = admin.AdminPhone;
            existingAdmin.AdminHeadShot = admin.AdminHeadShot;

            // 更新資料庫
            _context.SaveChanges();

            // 返回列表頁面
            return RedirectToAction(nameof(Index));
        }


    }
}
