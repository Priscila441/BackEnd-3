using AutoMapper;
using Datass.Repository.Interfaces;
using Models.Entity;
using Models.Entity.Dtos.User;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserGetDto>> BringAllAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            if (users == null) return null!;

            return _mapper.Map<IEnumerable<UserGetDto>>(users);
        }

        public async Task<UserGetDto> BringOneAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null) return null!;

            return _mapper.Map<UserGetDto>(user);
        }

        public async Task<UserGetDto> CreateAsync(UserPostDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.NameUser) || dto.NameUser.Length < 2 || dto.NameUser.Length > 50)
                throw new ArgumentException("El nombre debe tener entre 2 y 50 caracteres.");

            if (string.IsNullOrWhiteSpace(dto.Email) || !Regex.IsMatch(dto.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("El correo electrónico no es válido.");

            if (string.IsNullOrWhiteSpace(dto.Password) || dto.Password.Length < 8)
                throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.");

            var user = new User
            {
                NameUser = dto.NameUser.Trim(),
                Email = dto.Email.ToLower().Trim(),
                Password = dto.Password,
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<UserGetDto>(user);
        }


        public async Task<bool> ChangeAsync(int id, UserPutDto dto)
        {
            var existingUser = await _unitOfWork.Users.GetByIdAsync(id);
            if (existingUser == null)
                return false;

            if (string.IsNullOrWhiteSpace(dto.NameUser) || dto.NameUser.Length < 2 || dto.NameUser.Length > 50)
                throw new ArgumentException("El nombre debe tener entre 2 y 50 caracteres.");
            if (string.IsNullOrWhiteSpace(dto.Password) || dto.Password.Length < 8)
                throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.");

            _mapper.Map(dto, existingUser);
            await _unitOfWork.Users.Update(existingUser);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingUser = await _unitOfWork.Users.GetByIdAsync(id);
            if (existingUser == null)
                return false;

            await _unitOfWork.Users.Delete(existingUser);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<UserGetDto?> ValidateUserAsync(string email, string password)
        {
            var user = await _unitOfWork.Users.ValidateCredentialsAsync(email, password);
            if (user == null) return null;

            return _mapper.Map<UserGetDto>(user);
        }
    }
}
