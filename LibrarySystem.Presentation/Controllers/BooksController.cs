using LibrarySystem.Application.DTOs;
using LibrarySystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Presentation.Controllers;
public class BooksController : Controller
{
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
        _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
    }

    public async Task<IActionResult> IndexAsync()
    {
        var books = await _bookService.GetAllBooksAsync();
        return View(books);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAsync(BookDTO bookDto)
    {
        if (bookDto is null)
        {
            throw new ArgumentNullException(nameof(bookDto));
        }

        if (ModelState.IsValid)
        {
            await _bookService.AddBookAsync(bookDto);
            return RedirectToAction(nameof(Index));
        }
        return View(bookDto);
    }

    public async Task<IActionResult> EditAsync(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book is null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditAsync(int id, BookDTO bookDto)
    {
        if (id != bookDto.Id)
        {
            return NotFound();
        }

        if (bookDto is null)
        {
            throw new ArgumentNullException(nameof(bookDto));
        }

        if (ModelState.IsValid)
        {
            await _bookService.UpdateBookAsync(bookDto);
            return RedirectToAction(nameof(Index));
        }
        return View(bookDto);
    }

    public async Task<IActionResult> DeleteAsync(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book is null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmedAsync(int id)
    {
        await _bookService.DeleteBookAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

