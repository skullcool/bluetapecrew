﻿using Api.Models;
using Api.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BtcEntities _context;

        public UsersController(BtcEntities context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetAspNetUsers()
        {
            var users = await _context.AspNetUsers.Include(x => x.AspNetUserRoles).ToListAsync();
            var model = JsonConvert.SerializeObject(
                users, 
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
            return Ok(model);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUsers>> GetAspNetUsers(string id)
        {
            var aspNetUsers = await _context.AspNetUsers.FindAsync(id);

            if (aspNetUsers == null)
            {
                return NotFound();
            }

            return aspNetUsers;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUsers(string id, AspNetUsers aspNetUsers)
        {
            if (id != aspNetUsers.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<AspNetUsers>> PostAspNetUsers(AspNetUsers aspNetUsers)
        {
            _context.AspNetUsers.Add(aspNetUsers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetUsersExists(aspNetUsers.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetUsers", new { id = aspNetUsers.Id }, aspNetUsers);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AspNetUsers>> DeleteAspNetUsers(string id)
        {
            var aspNetUsers = await _context.AspNetUsers.FindAsync(id);
            if (aspNetUsers == null)
            {
                return NotFound();
            }

            _context.AspNetUsers.Remove(aspNetUsers);
            await _context.SaveChangesAsync();

            return aspNetUsers;
        }

        private bool AspNetUsersExists(string id)
        {
            return _context.AspNetUsers.Any(e => e.Id == id);
        }
    }
}
