using exaInnovation.Data;
using Microsoft.AspNetCore.Mvc;
using exaInnovation.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using exaInnovation.Models.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace exaInnovation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TareasController : Controller
    {
        private readonly ApplicationDbContext context;

        [BindProperty]
        public TareasViewModel metasViewModel { get; set; }
        public TareasController(ApplicationDbContext _context)
        {
            context = _context;
            metasViewModel = new TareasViewModel
            {
               
            };
        }
        public async Task<IActionResult> Index(int ? id)
        {
            if (ModelState.IsValid)
            {
                metasViewModel._metas = await context.Metas.Include(m => m.Tareas)
                                      .SingleOrDefaultAsync(m => m.Id == id);
               
            }
            return PartialView("_TareasTableIndex", metasViewModel);
        }

        
    }
}
