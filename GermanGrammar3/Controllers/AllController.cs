using GermanGrammar3.Data;
using GermanGrammar3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GermanGrammar3.Controllers
{

    public class AllController : Controller
    {

        private readonly ApplicationDbContext context;

        public AllController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string SearchString)
        {
            //var listAll = await context.AllTogether.ToListAsync();    // I take all the table.
            //return View(listAll);                                     // Take the list the send her to the view().

            //var katsavarosOnly = context.AllTogether.Where(b => b.german.Equals("katsavaros2")).ToList();
            //return View(katsavarosOnly);


            ViewData["CurrentFilter"] = SearchString;
            var books = from b in context.AllTogether select b;

            if (!String.IsNullOrEmpty(SearchString))
            {
                books = books.Where(b => b.german.Contains(SearchString));
            }

            return View(books.ToList());

        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAll addAllRequest) //AddAll.cs
        {
            var abc = new GermanModel()
            {
                german = addAllRequest.german
            };

            await context.AllTogether.AddAsync(abc);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GoToEdit(int id)
        {   // αυτός το έχει View

            var word = await context.AllTogether.FirstOrDefaultAsync(x => x.id == id);

            if (word != null)
            {
                var viewModel = new UpdateAll()
                {
                    id = word.id,
                    german = word.german
                };

                return await Task.Run(() => View("GoToEdit", viewModel));

            }

            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> GoToEdit(UpdateAll model)
        {
            // We will take the record from the Database.
            var abcd = await context.AllTogether.FindAsync(model.id);

            if (abcd != null)
            {
                abcd.german = model.german; // Τώρα αλλάζω την τιμή από το model.


                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            // Αν κάτι δεν πάει και πολύ καλά.
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(UpdateAll model)
        {
            var abcde = await context.AllTogether.FindAsync(model.id);

            if (abcde != null)
            {
                context.AllTogether.Remove(abcde);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}
