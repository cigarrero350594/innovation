using exaInnovation.Data;
using Microsoft.AspNetCore.Mvc;
using exaInnovation.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using exaInnovation.Models.ViewModels;
using System.Linq;
using System.Collections.Generic;
using System;

namespace exaInnovation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TareasController : Controller
    {
        private readonly ApplicationDbContext context;
        private static int Id = 0;

        [BindProperty]
        public TareasViewModel metasViewModel { get; set; }
        public TareasController(ApplicationDbContext _context)
        {
            context = _context;
            metasViewModel = new TareasViewModel
            {

            };
        }
        [ActionName("Index")]
        public async Task<IActionResult> Index(int ? id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return NotFound();
                }
                else
                {
                    //metasViewModel._metas = await context.Metas
                    //                        .Include(m => m.Tareas)
                    //                        .SingleOrDefaultAsync(m => m.Id == id);
                    //

                    metasViewModel._TareasList = await context.Tareas
                                                        .Where(m => m.MetasId == id)
                                                        .ToListAsync();
                    //Id = id;

                    if (id == null)
                        Id = default(int);
                    else
                       Id = id.Value;
                }
            }
            JsonResult json = Json(metasViewModel._TareasList);
            return json;
           // return PartialView("_TareasTableIndex", metasViewModel);
        }

        public async  Task<IActionResult> Create()
        {
            //tasViewModel._metas = await context.Metas;
            //metasViewModel._tareas = await context.Tareas.SingleOrDefaultAsync();
            return PartialView("_CreateTarea");

        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew(Tareas tarea)
        {

            //if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(tarea.Nombre))
                {
                    tarea.FechaCreacion = DateTime.Now;
                    tarea.Estado = "Incompleta";
                    tarea.MetasId = Id;
                    context.Tareas.Add(tarea);
                    await context.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index","Metas");
        }

        public  IActionResult Edit(int ? id)
        {

            return PartialView("_EditTarea",id);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Tareas tareas = await context.Tareas.FirstOrDefaultAsync(m => m.Id == id);

            if (tareas == null)
            {
                return NotFound();
            }
            tareas.Estado = "Terminado";
            //tareas.Prioridad = "Terminado";
            //context.Tareas.Remove(tareas);
            await context.SaveChangesAsync();


            string nombre = Request.Form["Nombre"].ToString();

            //if (!nombre.Equals(metas.Nombre))
            //    await context.SaveChangesAsync();
            //else
            //{

            //}

            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Metas metas = await context.Metas.SingleOrDefaultAsync(m => m.Id == id);

        //    if (metas == null)
        //    {
        //        return NotFound();
        //    }


        //    return PartialView("_DeleteTarea", metas);
        //}

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tareas tareas = await context.Tareas.FirstOrDefaultAsync(m => m.Id == id);

            if (tareas == null)
            {
                return NotFound();
            }
            context.Tareas.Remove(tareas);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
