using BookStore.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using BookStore.Domain;
using BookStore.Context;
using System.Data.Entity;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookStoreDataContext _db = new BookStoreDataContext();

        public EntityState State { get; private set; }

        public bool Create(Livro livro)
        {
            try
            {
                _db.Livros.Add(livro);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Delete(int id)
        {
            var livro = _db.Livros.Find(id);
            _db.Livros.Remove(livro);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Livro Get(int id)
        {
            var livro = _db.Livros
                .Find(id);
            return livro;
        }

        public List<Livro> Get()
        {
            return _db.Livros
                .ToList();
        }

        public List<Livro> GetByName(string nome)
        {
            var livros = _db.Livros
                .Where(x => x.Nome.Contains(nome))
                .ToList();
            return livros;
        }

        public bool Update(Livro livro)
        {
            try
            {
                _db.Entry<Livro>(livro).State = EntityState.Modified;
                _db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}