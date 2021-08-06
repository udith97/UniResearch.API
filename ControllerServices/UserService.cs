using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniResearch.API.DTOs;
using UniResearch.API.Entity;
using UniResearch.API.Repository;

namespace UniResearch.API.ControllerServices
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ActionResult<User>> GetByIdAsync(int userId)
        {
            var user = await _userRepository.GetById(userId);
            if (user != null)
            {
                return new ActionResult<User>(user);
            }
            return new NoContentResult();

        }

        public async Task<ActionResult<List<UserDTO>>> GetUsers(string search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                var filteredUsers = await _userRepository.Search(search);
                var filteredUsersDTOs = filteredUsers.Select(o => new UserDTO { UserId = o.UserId, FirstName = o.FirstName, LastName = o.LastName, Email = o.Email , DateofBirth = o.DateofBirth , UserType  = o.UserType }).ToList();
                return new ActionResult<List<UserDTO>>(filteredUsersDTOs);


            }
            var users = await _userRepository.GetAll();
            var userDTOs = users.Select(o => new UserDTO { UserId = o.UserId, FirstName = o.FirstName, LastName = o.LastName, Email = o.Email, DateofBirth = o.DateofBirth, UserType = o.UserType }).ToList();
            return new ActionResult<List<UserDTO>>(userDTOs);

        }
    }
}
