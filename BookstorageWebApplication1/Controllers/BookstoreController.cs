using AutoMapper;
using BookstorageWebApplication1.Dtos;
using BookstorageWebApplication1.Interfaces;
using BookstorageWebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstorageWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookstoreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookstoreRepository _repoStore;

        public BookstoreController(IMapper mapper, IBookstoreRepository repoStore)
        {
            _mapper = mapper;
            _repoStore = repoStore;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSotres()
        {
            var stores = await _repoStore.GetAllBookStores();
            var getStore = _mapper.Map<List<BookstoreGetDto>>(stores);
            return Ok(getStore);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoreById(int id)
        {
            var store = await _repoStore.BookstoreById(id);
            var storeGet = _mapper.Map<BookstoreGetDto>(store);
            return Ok(storeGet);
        }
        [HttpPost]
        public async Task<IActionResult> CreatebookStore(BookstoreCreateDto bookstore)
        {
            var storeDomain = _mapper.Map<Bookstore>(bookstore);
            await _repoStore.CreateBookstore(storeDomain);
            var storeGet = _mapper.Map<BookstoreGetDto>(storeDomain);
            return CreatedAtAction(nameof(GetStoreById), new { id = storeDomain.BookstoreId }, storeGet);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookstore([FromBody] BookstoreCreateDto bookstoreUpdate, int id)
        {
            var store = _mapper.Map<Bookstore>(bookstoreUpdate);
            store.BookstoreId = id;
            await _repoStore.BookstoreUpdate(store);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookStore(int id)
        {
            var store = await _repoStore.DeleteBookstore(id);
            if (store == null)
            {
                return NoContent();
            }
            return NoContent();
        }
    }
}
