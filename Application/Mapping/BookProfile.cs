using AutoMapper;
using LibrarySystem.Application.DTOs;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Application.Mapping;

public sealed class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDTO>().ReverseMap();
    }
}

