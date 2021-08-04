﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FullStack.API.Services;
using FullStack.ViewModels;
using FullStack.Data.Entities;
using FullStack.API.Helpers;

namespace FullStack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
       
        [HttpGet("unsecure")]
        public IActionResult GetAllUnsecure()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult CreateUser(RegisterUserModel user)
        {
            try
            {
                //Create user
                _userService.CreateUser(RegisterMap(user));
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
            
        }

        private User RegisterMap(RegisterUserModel user)
        {
            return new User
            {
                Id = user.Id,
                Forenames = user.Forenames,
                Surname = user.Surname,
                Email = user.Email,
                Password = user.Password
                
            };
        }

    }
}
