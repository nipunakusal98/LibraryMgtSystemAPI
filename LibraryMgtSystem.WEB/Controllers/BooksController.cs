using LibraryMgtSystem.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMgtSystem.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        static public List<Book> Books = new List<Book>
        {
            new Book {Id=1, BookName="Batman", Category="Comics", InsertedAt = DateTime.Today },
            new Book {Id=2, BookName="Green Arrow", Category="Comics", InsertedAt = DateTime.Today },
            new Book {Id=3, BookName="American pshyco", Category="Novel", InsertedAt = DateTime.Today },
        };

        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks() 
        {
            return Ok(Books);
        }


        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = Books.Find(x => x.Id == id);
            if (book == null)
                return NotFound("Book not Found.");
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<List<Book>> AddBook(Book book)
        {
            Books.Add(book);
            return Ok(Books);
        }

        [HttpPut]
        public ActionResult<List<Book>> UpdateBook(Book EditBook) 
        {
            var book = Books.Find(x => x.Id == EditBook.Id);
            if (book == null)
                return NotFound("Book not Found.");

            book.BookName = EditBook.BookName;
            book.Category = EditBook.Category;
            book.InsertedAt = EditBook.InsertedAt; 

            return Ok(book);
        }

        [HttpDelete]
        public ActionResult DeleteBook(int id) 
        {
            var book = Books.Find(x => x.Id == id);
            if (book == null)
                return NotFound("Book not Found.");

            Books.Remove(book);

            return Ok(Books);

        }



    }
}
