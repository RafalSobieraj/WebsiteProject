using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebsiteProject.Data;
using WebsiteProject.Models;

namespace WebsiteProject.Controllers
{
    public class CamerasController : Controller
    {
        private readonly MyDbContext _context;

        public CamerasController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cameras = _context.Cameras.ToList();
            return View("~/Views/Cameras/CameraView.cshtml", cameras);
        }

        public IActionResult Create(int id=0)
        {
            return View(new Cameras());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id, camera_model, camera_type, resolution")] Cameras cameras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cameras);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cameras);
        }

        public IActionResult Edit(int id)
        {
            Cameras cameras = new Cameras();
            cameras = _context.Cameras.Where(x => x.id == id).FirstOrDefault();
            return View(cameras);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("id, camera_model, camera_type, resolution")]Cameras cameras)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cameras);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cameras);
        }

        public async Task<IActionResult> Delete(int? id, Cameras cameras)
        {
            var camera = await _context.Cameras.FindAsync(id);
            _context.Cameras.Remove(camera);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }

}