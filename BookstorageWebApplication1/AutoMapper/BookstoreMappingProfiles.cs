using AutoMapper;
using BookstorageWebApplication1.Dtos;
using BookstorageWebApplication1.Models;

namespace BookstorageWebApplication1.AutoMapper
{
    public class BookstoreMappingProfiles : Profile
    {
        public BookstoreMappingProfiles()
        {
            CreateMap<BookstoreCreateDto, Bookstore>();
            CreateMap<Bookstore, BookstoreGetDto>();
        }
    }
}
