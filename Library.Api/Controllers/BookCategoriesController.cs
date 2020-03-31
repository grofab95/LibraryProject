using System.Collections.Generic;
using AutoMapper;
using Library.Api.Adapters;
using Library.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Library.Api.BookCategoriesDto;
using Library.Domain.Entities;

namespace Library.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
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
                _bookCategoryDao.Create(_mapper.Map<BookCategory>(bookCategoryRegisterDto));
                return Ok();
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_mapper.Map<BookCategoryDto>(_bookCategoryDao.GetById(id)));
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]BookCategoryUpdateDto bookCategoryUpdateDto)
        {
            var category = _mapper.Map<BookCategory>(bookCategoryUpdateDto);
            category.Id = id;        
            try
            { 
                _bookCategoryDao.Update(category);
                return Ok();
            }
            catch (LibraryException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookCategoryDao.Delete(id);
            return Ok();
        }
    }
}
