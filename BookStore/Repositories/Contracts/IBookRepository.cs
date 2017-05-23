using BookStore.Domain;
using System;
using System.Collections.Generic;

namespace BookStore.Repositories.Contracts
{
    interface IBookRepository : IDisposable
    {
        Livro Get(int id);
        List<Livro> Get();
        List<Livro> GetByName(string nome);
        bool Create(Livro livro);
        bool Update(Livro livro);
        void Delete(int id);
    }
}
