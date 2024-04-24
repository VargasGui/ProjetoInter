using ISoccer.Infra.Data;
using ISoccer.Infra.Models;
using ISoccer.Service.DTO;
using ISoccer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ISoccer.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dataContext;

        public UserService(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Create(UserDTO userDto)
        {
            User user = new User()
            {
                DisplayName = userDto.DisplayName,
                Email = userDto.Email,
                Phone = userDto.Phone,
                isAdmin = userDto.isAdmin,
                Name = userDto.Name,
                Password = userDto.Password,
            };
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserDTO>> GetAll()
        {
            var user = await _dataContext.Users.ToListAsync();
            var userDto = user.Select(x => new UserDTO()
            {
                DisplayName = x.DisplayName,
                Email = x.Email,
                Phone = x.Phone,
                Name = x.Name,
                Password = x.Password,

            });
            return userDto.ToList();
        }
    }
}
