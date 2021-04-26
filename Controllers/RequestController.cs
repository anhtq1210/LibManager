using MyLibraryManager.Models;
using MyLibraryManager.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyLibraryManager.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository _repo;

        public RequestController(IRequestRepository repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        //[Author("Admin")]
        public IEnumerable<Request> GetRequestDetail()
        {
            var borrowRequests = _repo.GetAllInclude(b => b.RequestDetail, b => b.User).AsEnumerable();
            
            return borrowRequests;            
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("{id}")]
        public IEnumerable<Request> Get(Guid id)
        {
            return _repo.GetOne(id, o=> o.RequestDetail, o=>o.User).AsEnumerable();
        }
        [HttpGet("user/{id}")]
        public IEnumerable<Request> GetAllByUser(Guid id)
        {
            return _repo.GetAllRequestByUserID(id, b => b.User, b => b.RequestDetail).Where(b => b.UserID == id).AsEnumerable();
        }

        // POST api/<OrderDetailController>
        [HttpPost("{userId}")]
        public IActionResult Insert(Request request, Guid userId)
        {
            var checkBorrowInMonth = _repo.GetAllInclude().Count(br => br.UserID == userId && br.Created.Month == DateTime.Now.Month);
            Console.WriteLine(checkBorrowInMonth);
            if (checkBorrowInMonth < 3)
            {
                if (request.RequestDetail.Count <= 5)
                {
                    request.ID = Guid.NewGuid();
                    request.Created = DateTime.Now;
                    request.UserID = userId;
                    _repo.Insert(request);
                    return Ok(request);
                }
                return Ok(
                new
                {
                    error = "Over limit books per request"
                });
            }
            return Ok(
                new
                {
                    error = "Over limit requests per month"
                });
        }

}
}
