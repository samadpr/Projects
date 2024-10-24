using JobPortalSystem_Exercise.Dtos;
using JobPortalSystem_Exercise.Interface;
using JobPortalSystem_Exercise.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortalSystem_Exercise.Data.Repository
{
    public class PublicRepository : IPublicRepository
    {
        public readonly JobPortalExDbContext _context;

        public PublicRepository(JobPortalExDbContext context)
        {
            _context = context;
        }

        public User LoggedUser = new User();
        public User Register(User user)
        {
            if (_context.Users.Where(u => u.Email == user.Email).Count() > 0)
            {
                return null;
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Login(LoginDto loginDto)
        {
            LoggedUser = _context.Users.Where(u => u.Email == loginDto.Email && u.Password == loginDto.Password).FirstOrDefault();
            return LoggedUser;
        }

    }
}
