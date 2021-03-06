﻿using AutoMapper;
using Library.Api.BookAuthorsDto;
using Library.Domain.Adapters;
using Library.Domain.Entities;
using Library.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Library.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorsController : ControllerBase
    {
        private IBookAuthorDao _authorDao;
        private IMapper _mapper;

        public BookAuthorsController(IBookAuthorDao authors, IMapper mapper)
        {
            _authorDao = authors;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody]BookAuthorRegisterDto authorRegisterDto)
        {
            try
            {
                var author = _authorDao.Create(_mapper.Map<BookAuthor>(authorRegisterDto));
                return Ok(author);
            }
            catch (LibraryException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<IList<BookAuthorDto>>(_authorDao.GetAll()));
        }

        [HttpPut]
        public IActionResult Update(BookAuthorUpdateDto bookAuthorUpdateDto)
        {
            try
            {
                _authorDao.Update(_mapper.Map<BookAuthor>(bookAuthorUpdateDto));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{authorId}")]
        public IActionResult Delete(int authorId)
        {
            try
            {
                _authorDao.Delete(authorId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}