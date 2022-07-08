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
    public class TopicController : ControllerBase
    {
        private readonly forumdbContext _context;
        private ITopicService _topicService;

        public TopicController(forumdbContext context, ITopicService topicService)
        {
            _context = context;
            _topicService = topicService;
        }

        // GET: api/Topic
        [HttpGet]
        public IActionResult GetComments()
        {
            return Ok(this._topicService.GetAllTopics());
        }

        // GET: api/Topic/5
        [HttpGet("{id}")]
        public IActionResult GetTopic(int id)
        {
            var topic = _topicService.GetById(id);

            if (topic == null)
            {
                return NotFound();
            }

            return Ok(topic);
        }

        // PUT: api/Topic/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutTopic(int id, Topic topic)
        {
            if (TopicExists(id))
            {

                try
                {
                    _topicService.Update(topic);
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

            return Ok("Topic modified");


        }

        // POST: api/Topic
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostTopic(Topic topic)
        {
            try
            {
                _topicService.Create(topic);
            }
            catch (DbUpdateException e)
            {
                if (TopicExists(topic.TopicId))
                {
                    return Conflict("Topic already exists");
                }
                else
                {
                    return Problem();
                }
            }

            return Ok("Topic created");
        }

        // DELETE: api/Topic/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTopic(int id)
        {

            var topic = _topicService.GetById(id);
            if (topic == null)
            {
                return NotFound();
            }

            _topicService.Delete(topic);
            return Ok("Comment deleted");
        }

        private bool TopicExists(int id)
        {
            return _topicService.GetById(id) != null;
        }
    }
}
