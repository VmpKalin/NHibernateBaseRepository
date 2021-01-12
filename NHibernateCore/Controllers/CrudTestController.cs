using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using NHibernateCore.Context;
using NHibernateCore.Entities;
using NHibernateCore.Requests;

namespace NHibernateCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudTestController : ControllerBase
    {
        private readonly IBookMapperSession _bookMapperSession;
        private readonly IStudentMapperSession _studentMapperSession;

        public CrudTestController(IBookMapperSession bookMapperSession, IStudentMapperSession studentMapperSession)
        {
            _bookMapperSession = bookMapperSession;
            _studentMapperSession = studentMapperSession;
        }

        [HttpGet("Book")]
        public async Task<IActionResult> GetBooksAsync()
        {
            var books = _bookMapperSession.Entities.ToList();

            return Ok(books);
        }


        [HttpPost("Book")]
        public async Task CreateNewTitle([FromBody] CreateBookRequest request)
        {
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Title = request.Title
            };

            await _bookMapperSession.AddAsync(book);
        }


        [HttpGet("BookGetWithTx")]
        public async Task GetBooksWithTransactionAsync()
        {
            try
            {
                _bookMapperSession.BeginTransaction();

                var book = await _bookMapperSession.Entities.FirstOrDefaultAsync();
                book.Title += " (sold out)";

                await _bookMapperSession.SaveAsync(book);
                await _bookMapperSession.CommitAsync();
            }
            catch
            {
                // log exception here
                await _bookMapperSession.RollbackAsync();
            }
            finally
            {
                _bookMapperSession.CloseTransaction();
            }
        }

        [HttpGet("Student")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentMapperSession.Entities.ToListAsync();

            return Ok(students);
        }

        [HttpPost("Student")]
        public async Task<IActionResult> CreateNewStudent([FromBody] CreateStudentRequest request)
        {
            var studentEntity = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            await _studentMapperSession.AddAsync(studentEntity);

            return Ok();
        }

    }
}
