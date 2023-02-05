
using Microsoft.AspNetCore.Mvc;
using TarladanEve.Api.Data;
using TarladanEve.Api.Models.User;
using TarladanEve.Api.Models.Request.User;

namespace TarladanEve.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private DataContext _context;    ///DataContext injection

        public UserController(DataContext context)
        {
            _context = context;
        }


        [HttpGet(Name = "GetAllUsers")]
        public ActionResult GetAllUsers()        ///baþarýlý ise 200 vs. hatalarýný ActionResult ile döner
        {
            try
            {
                var _users = _context.Users.ToList();

                if (_users != null)
                {
                    return Ok(_users);
                }
                else 
                {
                    return BadRequest("Kullanýcý kaydý bulunamadý !");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost(Name = "GetUsersByName")]
        public ActionResult GetUsersByName(GetDeleteUserRequest _request)
        {
            try
            {
                var _users = _context.Users
                    .Where(f => f.UserName == _request.UserName
                              || (f.Name == _request.Name && f.Surname == _request.Surname)).ToList();

                if(_users != null)
                {
                    return Ok(_users);
                }
                else
                {
                    return BadRequest("Bu bilgi ile kayýtlý kullanýcý bulunamadý !");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "CreateUser")]
        public ActionResult CreateUser(CreateUserRequest _request)
        {
            try
            {
                User _recordCheck = _context.Users
                    .Where(f => f.Email == _request.Email
                                  || f.UserName == _request.UserName
                    )
                    .FirstOrDefault();

                if (_recordCheck == null)
                {
                    User newUser = new User();

                    newUser.Id = Guid.NewGuid();
                    newUser.Name = _request.Name;
                    newUser.Surname = _request.Surname;
                    newUser.Email = _request.Email;
                    newUser.Password = _request.Password;
                    newUser.Phone = _request.Phone;
                    newUser.UserType = _request.UserType;
                    newUser.Address = _request.Address;
                    newUser.UserName = _request.UserName;

                    _context.Users.Add(newUser);
                    _context.SaveChanges();

                    return Ok(newUser.Id);
                }
                else
                {
                    return BadRequest("Bu email veya kullanýcý adý ile kayýtlý olan kullanýcý mevcut !");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost(Name = "UpdateUser")]
        public ActionResult UpdateUser(UpdateUserRequest _request)
        {
            try
            {
                User _user = _context.Users
                  .Where(f => f.UserName == _request.UserName)
                  .FirstOrDefault();

                if (_user != null)
                {
                    _user.Name = _request.Name;
                    _user.Surname = _request.Surname;
                    _user.UserName = _request.UserName;
                    _user.Email = _request.Email;
                    _user.Password = _request.Password;
                    _user.Phone = _request.Phone;
                    _user.UserType = _request.UserType;
                    _user.Address = _request.Address;

                    _context.Users.Update(_user);
                    _context.SaveChanges();

                    return Ok(true);
                }

                else
                {
                    return BadRequest("Kullanýcý bulunamadý !");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "DeleteUser")]
        public ActionResult DeleteUser(GetDeleteUserRequest _request)
        {
            try
            {
                var _user = _context.Users
                    .Where(f => f.UserName == _request.UserName
                              || (f.Name == _request.Name && f.Surname == _request.Surname)).FirstOrDefault();

                if (_user != null)
                {
                    _context.Users.Remove(_user);
                    _context.SaveChanges();

                    return Ok(true);
                }
                else
                {
                    return BadRequest("Bu bilgi ile kayýtlý kullanýcý bulunamadý !");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}