using JobPortalSystem_Exercise.Dtos;
using JobPortalSystem_Exercise.Interface;
using JobPortalSystem_Exercise.Models;

namespace JobPortalSystem_Exercise.Services
{
    public class PublicService : IPublicService
    {
        public IPublicRepository _publicRepository;

        public PublicService(IPublicRepository publicRepository)
        {
            _publicRepository = publicRepository;
        }
        public User Register(User user)
        {
            return _publicRepository.Register(user);
        }
        public User Login(LoginDto loginDto)
        {
            return _publicRepository.Login(loginDto);
        }
    }
}
