using JobPortalSystem_Exercise.Interface;
using JobPortalSystem_Exercise.Models;

namespace JobPortalSystem_Exercise.Services
{
    public class JobProviderService : IJobProviderService
    {
        private readonly IJobProviderRepository _repository;

        public JobProviderService(IJobProviderRepository repository)
        {
            _repository = repository;
        }

        public User GetUserDetails(Guid id)
        {
            return _repository.GetUserDetails(id);
        }

        public Company CompanyRegistration(Company company)
        {
            return _repository.CompanyRegistration(company);
        }

        public Company GetCompanyDetails(Guid id)
        {
            return _repository.GetCompanyDetails(id);
        }

    }
}
