﻿using Cucu_Cosmin_Lab2.Models;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cucu_Cosmin_Lab2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Cucu_Cosmin_Lab2.Data.Cucu_Cosmin_Lab2Context _context;

        public CreateModel(Data.Cucu_Cosmin_Lab2Context context, Context.Book.AddBook await)
        {
            _context = context;
            this.await = await;
        }

        public IActionResult OnGet()
        {
            var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });
            ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID",
           "PublisherName");

            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new System.Collections.Generic.List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Book>(
            newBook,
            "Book",
            i => i.Title, i => i.Author,
            i => i.Price, i => i.PublishingDate, i => i.PublisherID))
            {
                _context.Book.Add(newBook);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");

        private readonly Context.Book.AddBook
            await DbContext.SaveChangesAsync

            returnRedirectToPageResult { get; }
    }
    }
