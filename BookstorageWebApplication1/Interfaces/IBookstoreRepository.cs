using BookstorageWebApplication1.Models;

namespace BookstorageWebApplication1.Interfaces
{
    public interface IBookstoreRepository
    {
        Task<List<Bookstore>> GetAllBookStores();
        Task<Bookstore> CreateBookstore(Bookstore bookstore);
        Task<Bookstore> BookstoreById(int boid);
        Task<Bookstore> BookstoreUpdate(Bookstore bookstoreUpdate);
        Task<Bookstore> DeleteBookstore(int id);

    }
}
