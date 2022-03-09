using BookstorageWebApplication1.Data;
using BookstorageWebApplication1.Interfaces;
using BookstorageWebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstorageWebApplication1.Repository
{
    public class BookstoreRepository : IBookstoreRepository
    {
        private readonly DataContext _ctx;

        public BookstoreRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<List<Bookstore>> GetAllBookStores()
        {
            return await _ctx.Bookstores.ToListAsync();
        }


        public async Task<Bookstore> BookstoreById(int id)
        {
            var store = await _ctx.Bookstores.FirstOrDefaultAsync(x => x.BookstoreId == id);

            if (store == null)
            {
                return null;
            }

            return store;
        }

        public async Task<Bookstore> BookstoreUpdate(Bookstore bookstoreUpdate)
        {
            _ctx.Update(bookstoreUpdate);
            await _ctx.SaveChangesAsync();
            return bookstoreUpdate;
        }

        public async Task<Bookstore> CreateBookstore(Bookstore bookstore)
        {
            _ctx.Add(bookstore);
            await _ctx.SaveChangesAsync();
            return bookstore;
        }

       
        public async Task<Bookstore> DeleteBookstore(int id)
        {
            var store = await _ctx.Bookstores.FirstOrDefaultAsync(x => x.BookstoreId == id);

            if (store == null)
            {
                return null;
            }

            _ctx.Bookstores.Remove(store);
            await _ctx.SaveChangesAsync();
            return store;
        }
    }
}
