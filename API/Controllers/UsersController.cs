using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UsersController : BaseApiController  
    {
        private readonly DataContext _context;

        public UsersController(DataContext context )
        {
            _context = context;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        //api/users/3
        [Authorize]
        [HttpGet("{id}")]
       // [EnableCors("AllowOrigin")]
        public async Task<ActionResult<AppUser>> GetUsers(int id)   
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
