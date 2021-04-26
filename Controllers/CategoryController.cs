using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibraryManager.Models;
using MyLibraryManager.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace MyLibraryManager.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Books
        [HttpGet]
         public async Task<IActionResult> GetAll()
        {
            var items = await _repo.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
           var item = await _repo.GetOneByID(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
        //[Author("Admin")]
        // PUT: api/Books/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Category category)
        {
            category.ID = id;
            _repo.Update(category);

        }
        //[Author("Admin")]
        // POST: api/Books
        [HttpPost]
        public void Post(Category category)
        {
            category.Created = DateTime.Now;
            _repo.Insert(category);
        }
        //[Author("Admin")]
        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task DeleteCategoryByID(Guid id)
        {
        await _repo.Remove(id);
        }

    }
}
