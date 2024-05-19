using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginAPI.Models;
using EcoVitalAPI.Models;

namespace EcoVitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserInfoesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/UserInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetUserInfos()
        {
          if (_context.UserInfos == null)
          {
              return NotFound();
          }
            return await _context.UserInfos.ToListAsync();
        }

        // GET: api/UserInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetUserInfo(int id)
        {
          if (_context.UserInfos == null)
          {
              return NotFound();
          }
            var userInfo = await _context.UserInfos.FindAsync(id);

            if (userInfo == null)
            {
                return NotFound();
            }

            return userInfo;
        }

        // GET: api/LoginUser/admin/123
        [HttpGet]
        [Route("LoginUser/{userName}/{password}")]
        public async Task<ActionResult<UserInfo>> LoginUser(string userName,string password)
        {
            if (_context.UserInfos == null)
            {
                return NotFound();
            }
            var userInfo =  _context.UserInfos.Where(u=> u.UserName==userName && u.Password==password);

            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo);
        }

        // PUT: api/UserInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // We have to provide the id of the user to be updated in the URL
        // So the changes to be made to the user are provided in the request body which are, the username, password and email
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfo(int id, UserInfo userInfo)
        {
            if (id != userInfo.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
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

        // POST: api/UserInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserInfo>> PostUserInfo(UserInfo userInfo)
        {
          if (_context.UserInfos == null)
          {
              return Problem("Entity set 'ApplicationDBContext.UserInfos'  is null.");
          }
            _context.UserInfos.Add(userInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfo", new { id = userInfo.UserId }, userInfo);
        }

        // DELETE: api/UserInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfo(int id)
        {
            if (_context.UserInfos == null)
            {
                return NotFound();
            }
            var userInfo = await _context.UserInfos.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            _context.UserInfos.Remove(userInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInfoExists(int id)
        {
            return (_context.UserInfos?.Any(e => e.UserId == id)).GetValueOrDefault();
        }

        // GET users per email
        [HttpGet]
        [Route("GetUserByEmail/{email}")]
        public async Task<ActionResult<UserInfo>> GetUserByEmail(string email)
        {
            if (_context.UserInfos == null)
            {
                return NotFound();
            }
            var userInfo = await _context.UserInfos.Where(u => u.Email == email).ToListAsync();

            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo);
        }

        // Get users per email OR username
        [HttpGet]
        [Route("GetUserByEmailOrUsername/{emailOrUsername}")]
        public async Task<ActionResult<UserInfo>> GetUserByEmailOrUsername(string emailOrUsername)
        {
            if (_context.UserInfos == null)
            {
                return NotFound();
            }
            var userInfo = await _context.UserInfos.Where(u => u.Email == emailOrUsername || u.UserName == emailOrUsername).ToListAsync();

            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo);
        }

        // POST: "https://vivaserviceapi.azurewebsites.net/api/UserInfoes/{UserId}/ChangePassword, donde {UserId} es el id del usuario
        // Solo se puede modificar la contraseña y en el request body del post solo debe contener la nueva contraseña NO EL USERID
        // { "NewPassowrd": "string" }
        [HttpPost]
        [Route("{UserId}/ChangePassword")]
        public async Task<ActionResult<UserInfo>> ChangePassword(int UserId, ChangePasswordRequest changePasswordRequest)
        {
            if (_context.UserInfos == null)
            {
                return NotFound();
            }
            var userInfo = await _context.UserInfos.FindAsync(UserId);
            if (userInfo == null)
            {
                return NotFound();
            }
            userInfo.Password = changePasswordRequest.NewPassword;
            _context.Entry(userInfo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(userInfo);
        }



    }
}
