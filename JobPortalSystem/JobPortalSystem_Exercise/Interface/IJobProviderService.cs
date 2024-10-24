using JobPortalSystem_Exercise.Models;

namespace JobPortalSystem_Exercise.Interface
{
    public interface IJobProviderService
    {
        User GetUserDetails(Guid id);
        Company CompanyRegistration(Company company);

        Company GetCompanyDetails(Guid id);


    }
}
