using ISoccer.Infra.Models;
using ISoccer.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISoccer.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> Create(UserDTO userDto);
        Task<List<UserDTO>> GetAll();
    }
}
