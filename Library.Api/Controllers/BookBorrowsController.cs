using AutoMapper;
using Library.Api.BookBorrowsDto;
using Library.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Library.Domain.Adapters;

namespace Library.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookBorrowsController : ControllerBase
    {
        private IBookBorrowDao _bookBorrow;
        private IMapper _mapper;

        public BookBorrowsController(
            IBookBorrowDao bookBorrow,
            IMapper mapper)
        {
            _bookBorrow = bookBorrow;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Register([FromBody]BookBorrowCreateDto bookBorrowCreateDto)
        {
            try
            {
                _bookBorrow.Create(_mapper.Map<BookBorrow>(bookBorrowCreateDto));
                return Ok();
            }
            catch (LibraryException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.InnerException.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<IList<BookBorrowDto>>(_bookBorrow.GetAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_mapper.Map<BookBorrowDto>(_bookBorrow.GetById(id)));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]BookBorrowUpdateDto bookBorrowUpdateDto)
        {
            var bookBorrow = _mapper.Map<BookBorrow>(bookBorrowUpdateDto);
            bookBorrow.Id = id;
            try
            {
                _bookBorrow.Update(bookBorrow);
                return Ok();
            }
            catch (LibraryException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookBorrow.Delete(id);
            return Ok();
        }
    }
}
