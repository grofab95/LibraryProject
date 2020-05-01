using System.Collections.Generic;
using AutoMapper;
using Library.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Library.Api.BookCategoriesDto;
using Library.Domain.Entities;
using Library.Domain.Adapters;
using System;

namespace Library.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookCategoriesController : ControllerBase
    {
        private IBookCategoryDao _bookCategoryDao;
        private IMapper _mapper;

        public BookCategoriesController(
            IBookCategoryDao bookCategoryDao,
            IMapper mapper)
        {
            _bookCategoryDao = bookCategoryDao;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody]BookCategoryRegisterDto bookCategoryRegisterDto)
        {
            try
            {
                var category = _bookCategoryDao.Create(_mapper.Map<BookCategory>(bookCategoryRegisterDto));
                return Ok(category);
            }
            catch (LibraryException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<IList<BookCategoryDto>>(_bookCategoryDao.GetAll()));
        }

        [HttpPut]
        public IActionResult Update(BookCategoryUpdateDto bookCategoryUpdateDto)
        {              
            try
            {
                var category = _mapper.Map<BookCategory>(bookCategoryUpdateDto);
                _bookCategoryDao.Update(category);
                return Ok();
            }
            catch (LibraryException exception)
            {
                return BadRequest(exception.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _bookCategoryDao.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
