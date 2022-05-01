#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P2_2019AM604_2018PR603.Models;
using P2_2019AM604_2018PR603.Models.ViewModel;

namespace P2_2019AM604_2018PR603.Controllers
{
    public class CovidController : Controller
    {
        private readonly dbCovidContext _context;

        public CovidController(dbCovidContext context)
        {
            _context = context;
        }

        // GET: Covid
        public async Task<IActionResult> Index()
        {

            //Mostrar datos
            var Covid = (from cr in _context.creportado
                                      join ge in _context.genero on cr.IdGen equals ge.IdGen
                                      join dp in _context.departamento on cr.IdGen equals dp.IdDpt
                                      select new Covid
                                      {
                                          Departamento = dp.NombreDpt,
                                          Genero = ge.NombreGen,
                                          Confirmados = cr.Confirmado,
                                          Recuperados = cr.Recuperado,
                                          Fallecidos = cr.Fallecido
                                      }).ToListAsync();

            return View(await Covid);
        }

        // GET: Covid/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creportado = await _context.creportado
                .FirstOrDefaultAsync(m => m.IdCreportado == id);
            if (creportado == null)
            {
                return NotFound();
            }

            return View(creportado);
        }

        // GET: Covid/Create
        public IActionResult Create()
        {
            //Departamentos
            IEnumerable<Departamento> datosDepartamentos = from d in _context.departamento select d;
            List<SelectListItem> comboDepartamentos = new List<SelectListItem>();
            foreach (Departamento dpt in datosDepartamentos)
            {
                SelectListItem miOpcion = new SelectListItem
                {
                    Text = dpt.NombreDpt,
                    Value = dpt.IdDpt.ToString()
                };

                comboDepartamentos.Add(miOpcion);
            }
            ViewBag.comboDepartamentos = comboDepartamentos;

            //Generos
            IEnumerable<Genero> generos = from g in _context.genero select g;
            List<SelectListItem> comboGeneros = new List<SelectListItem>();
            foreach (Genero gen in generos)
            {
                SelectListItem miOpcion = new SelectListItem
                {
                    Text = gen.NombreGen,
                    Value = gen.IdGen.ToString()
                };
                comboGeneros.Add(miOpcion);
            }
            ViewBag.comboGeneros = comboGeneros;
            return View();
        }

        // POST: Covid/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCreportado,IdDpt,IdGen,Confirmado,Recuperado,Fallecido")] Creportado creportado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creportado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(creportado);
        }

        // GET: Covid/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creportado = await _context.creportado.FindAsync(id);
            if (creportado == null)
            {
                return NotFound();
            }
            return View(creportado);
        }

        // POST: Covid/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCreportado,IdDpt,IdGen,Confirmado,Recuperado,Fallecido")] Creportado creportado)
        {
            if (id != creportado.IdCreportado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creportado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreportadoExists(creportado.IdCreportado))
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
            return View(creportado);
        }

        // GET: Covid/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creportado = await _context.creportado
                .FirstOrDefaultAsync(m => m.IdCreportado == id);
            if (creportado == null)
            {
                return NotFound();
            }

            return View(creportado);
        }

        // POST: Covid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creportado = await _context.creportado.FindAsync(id);
            _context.creportado.Remove(creportado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreportadoExists(int id)
        {
            return _context.creportado.Any(e => e.IdCreportado == id);
        }
    }
}
