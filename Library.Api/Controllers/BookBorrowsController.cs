﻿using AutoMapper;
using Library.Api.BookBorrowsDto;
using Library.Api.Adapters;
using Library.Api.Entities;
using Library.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookBorrowsController : ControllerBase
    {
        private IBookBorrow _bookBorrow;
        private IMapper _mapper;

        public BookBorrowsController(
            IBookBorrow bookBorrow,
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