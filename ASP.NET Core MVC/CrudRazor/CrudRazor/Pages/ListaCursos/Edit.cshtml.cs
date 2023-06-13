using CrudRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudRazor.Pages.ListaCursos
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Curso Curso { get; set; }

        public async Task OnGet(int id)
        {
            Curso = await _db.Curso.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Curso cursoDB = await _db.Curso.FindAsync(Curso.Id);
                    cursoDB.NombreCurso = Curso.NombreCurso;
                    cursoDB.Precio = Curso.Precio;
                    cursoDB.Cantidad = Curso.Cantidad;

                    await _db.SaveChangesAsync();

                    return RedirectToPage("Index");
                }

                return RedirectToPage();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
