using BookData.Services.Interface;
using BookData.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookData.Controllers.API
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BookAPIController : Controller
    {
        private readonly IBook repBook;

        public BookAPIController(IBook _book)
        {
            this.repBook = _book;
        }

        [HttpGet("getbooklist")]
        public async Task<List<Book>> GetBookListAsync()
        {
            try
            {
                return await repBook.GetBookListAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("getbookbypagewiselist")]
        public async Task<List<Book>> GetBookByPagewiseListAsync(int page, int pageSize)
        {
            try
            {
                return await repBook.GetBookByPagewiseListAsync(page, pageSize);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("getbookbyid")]
        public async Task<Book> GetBookByIdAsync(int Id)
        {
            try
            {
                Book response = await repBook.GetBookByIdAsync(Id);

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync(Book data)
        {
            if (data == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await repBook.AddBookAsync(data);

                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error Inserting data");
            }
        }

        [HttpPatch()]
        public async Task<IActionResult> UpdateBookAsync(Book data)
        {
            try
            {
                if (data == null)
                    return BadRequest();
                var result = await repBook.UpdateBookAsync(data);
                return Ok(result);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }


    }
}
