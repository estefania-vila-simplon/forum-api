using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back.Models;
using back.Services.Interfaces;

namespace back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly forumdbContext _context;
        private readonly ICommentService _commentService;


        public CommentController(ICommentService commentService)
        {
            _context = new forumdbContext();
            _commentService = commentService;
        }

        // GET: api/Comment
        [HttpGet]
        public IActionResult GetComments()
        {
          return Ok(this._commentService.GetAllComments());
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var comment = _commentService.GetById(id);         
        
            if (comment == null)
            {
                return NotFound();
            }

            return Ok (comment);
        }

        // PUT: api/Comment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutComment(int id, Comment comment)
        {
            if (CommentExists(id))
            {

                try
                {
                    _commentService.Update(comment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Problem("Update failed");
                }
            }
            else
            {
                return BadRequest();

            }

            return Ok("Comment modified");

            
        }

        // POST: api/Comment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostComment(Comment comment)
        {
            try
            {
                _commentService.Create(comment);
            }
            catch (DbUpdateException)
            {
                if (CommentExists(comment.CommentId))
                {
                    return Conflict("Comment already exists");
                }
                else
                {
                    return Problem();
                }
            }

            return Ok("Comment created");
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
           
            var comment = _commentService.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }

            _commentService.Delete(comment);
           return Ok("Comment deleted");
        }

        private bool CommentExists(int id)
        {
            return _commentService.GetById(id) != null;
        }
    }
}
