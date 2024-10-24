using JobPortalSystem_Exercise.Dtos;
using JobPortalSystem_Exercise.Models;

namespace JobPortalSystem_Exercise.Interface
{
    public interface IPublicService
    {
        public User Register(User user);
        public User Login(LoginDto loginDto);
    }
}
