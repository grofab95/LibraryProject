using AutoMapper;
using Library.Api.BookBorrowsDto;
using Library.Api.BookCategoriesDto;
using Library.Api.BooksDto;
using Library.Api.Entities;
using Library.Api.UsersDto;

namespace Library.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();

            CreateMap<BookCategory, BookCategoryDto>();
            CreateMap<BookCategoryRegisterDto, BookCategory>();
            CreateMap<BookCategoryUpdateDto, BookCategory>();

            CreateMap<Book, BookDto>();
            CreateMap<BookRegisterDto, Book>();
            CreateMap<BookUpdateDto, Book>();

            CreateMap<BookBorrow, BookBorrowDto>();
            CreateMap<BookBorrowCreateDto, BookBorrow>();
            CreateMap<BookBorrowUpdateDto, BookBorrow>();
        }
    }
}
