using BookStore.Domain;
using BookStore.Repositories;
using BookStore.Repositories.Contracts;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository repository;

        public BookController()
        {
            repository = new BookRepository();
        }
        
        public ActionResult Index()
        {
            var livros = repository.Get();
            return View(livros);
        }
        
        public ActionResult Details(int id)
        {
            var livro = repository.Get(id);
            return View(livro);
        }
        

        public ActionResult Create()
        {
            return View();
        }

        [Route("criar")]
        [HttpPost]
        public ActionResult Create(Livro livro)
        {
            if (repository.Create(livro))
            {
                return RedirectToAction("Index");
            }

            return View(livro);
        }

        [Route("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            var livro = repository.Get(id);
            return View(livro);
        }
        
        [HttpPost]
        [Route("editar/{id:int}")]
        public ActionResult Edit(Livro livro)
        {
            if (repository.Update(livro))
            {
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        [Route("excluir/{id:int}")]
        public ActionResult Delete(int id)
        {
            var livro = repository.Get(id);
            return View(livro);
        }
        
        [HttpPost]
        [ActionName("Delete")]
        [Route("excluir/{id:int}")]
        public ActionResult DeleteConfirm(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index"); 
        }
    }
}
