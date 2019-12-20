using AutoMapper;
using Library.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Library.Api.Adapters;
using Library.Api.Entities;
using Library.Api.BooksDto;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private IBookDao _bookDao;
        private IMapper _mapper;

        public BooksController(
            IBookDao bookDao,
            IMapper mapper)
        {
            _bookDao = bookDao;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Register([FromBody]BookRegisterDto bookRegisterDto)
        {     
            try
            {
                _bookDao.Create(_mapper.Map<Book>(bookRegisterDto));
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
            return Ok(_mapper.Map<IList<BookDto>>(_bookDao.GetAll()));
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_mapper.Map<BookDto>(_bookDao.GetById(id)));
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]BookUpdateDto bookUpdateDto)
        {
            var book = _mapper.Map<Book>(bookUpdateDto);
            book.Id = id;        
            try
            {
                _bookDao.Update(book);
                return Ok();
            }
            catch (LibraryException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookDao.Delete(id);
            return Ok();
        }
    }
}
