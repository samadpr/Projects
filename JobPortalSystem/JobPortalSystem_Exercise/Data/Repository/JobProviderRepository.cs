using JobPortalSystem_Exercise.Interface;
using JobPortalSystem_Exercise.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobPortalSystem_Exercise.Data.Repository
{
    public class JobProviderRepository : IJobProviderRepository
    {
        private JobPortalExDbContext _context;
        private IHttpContextAccessor _httpContextAccessor;

        public JobProviderRepository(JobPortalExDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public User GetUserDetails(Guid id)
        {
            var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public Company CompanyRegistration(Company company)
        {
            string id = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            Guid Id = Guid.Parse(id);

            var user = _context.Users.Where(u => u.Id == Id).FirstOrDefault();

            if (user != null && user.CompanyId == null)
            {
                _context.Companies.Add(company);
                _context.SaveChanges();

                if (user.CompanyId == null)
                {
                    user.Company = company;
                    user.CompanyId = company.Id;
                    _context.Users.Update(user);
                    _context.SaveChanges();

                    return company;
                }
            }

            return null;
            
        }
        public Company GetCompanyDetails(Guid id)
        {
            var company = _context.Companies.Where(c => c.Id == id).FirstOrDefault();
            if (company == null)
            {
                return null;
            }
            return company;
        }

    }
}
