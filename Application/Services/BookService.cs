using AutoMapper;
using LibrarySystem.Application.DTOs;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Domain.Interfaces;

namespace LibrarySystem.Application.Services;

public class BookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BookDTO>>(books);
    }

    public async Task<BookDTO?> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        return book is null ? null : _mapper.Map<BookDTO>(book);
    }

    public async Task AddBookAsync(BookDTO bookDto)
    {
        if (bookDto is null)
        {
            throw new ArgumentNullException(nameof(bookDto));
        }

        var book = _mapper.Map<Book>(bookDto);
        await _bookRepository.AddAsync(book);
    }

    public async Task UpdateBookAsync(BookDTO bookDto)
    {
        if (bookDto is null)
        {
            throw new ArgumentNullException(nameof(bookDto));
        }

        var book = _mapper.Map<Book>(bookDto);
        await _bookRepository.UpdateAsync(book);
    }

    public async Task DeleteBookAsync(int id)
    {
        await _bookRepository.DeleteAsync(id);
    }
}

