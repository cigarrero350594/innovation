using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using exaInnovation.Models.ViewModels;
using exaInnovation.Data;

using exaInnovation.Models;
namespace exaInnovation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MetasController : Controller
    {
        private readonly ApplicationDbContext context;

        [BindProperty]
        public MetasViewModel metasViewModel { get; set; }
        public MetasController(ApplicationDbContext _context)
        {
            this.context = _context;
             metasViewModel = new MetasViewModel
            {
                _Metas = context.Metas
            };
           
        }

        public async Task<IActionResult> Index()
        {
            metasViewModel._Metas = await context.Metas.ToListAsync();
            return View(metasViewModel);
        }
       
        public IActionResult Create()
        {

            return PartialView("_CreateMeta");

        }    
        
        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew(Metas metas)
        {
            
            if(ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(metas.Nombre))
                {
                    metas.FechaCreacion = DateTime.Now;
                    context.Add(metas);
                    await context.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {          
            if (id == null)
            {
                return NotFound();
            }
          
            Metas metas = await context.Metas.SingleOrDefaultAsync(m => m.Id == id);

            if (metas == null)
            {
                return NotFound();
            }

        
            return PartialView("_EditMeta",metas);
        }

        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int ?id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Metas metas = await context.Metas.SingleOrDefaultAsync(m => m.Id == id);

            if (metas == null)
            {
                return NotFound();
            }
            
            string nombre = Request.Form["Nombre"].ToString();

            if(!nombre.Equals(metas.Nombre))
                await context.SaveChangesAsync();
            else
            {
               
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Metas metas = await context.Metas.SingleOrDefaultAsync(m => m.Id == id);

            if (metas == null)
            {
                return NotFound();
            }


            return PartialView("_DeleteMeta", metas);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Metas metas = await context.Metas.Include(m=>m.Tareas).SingleOrDefaultAsync(m => m.Id == id);

            if (metas == null)
            {
                return NotFound();
            }         
            context.Metas.Remove(metas);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
