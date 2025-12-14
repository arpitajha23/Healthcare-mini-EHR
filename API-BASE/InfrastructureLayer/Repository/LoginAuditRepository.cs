using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;
using InfrastructureLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repository
{
    public class LoginAuditRepository : ILoginAuditRepository
    {
        private readonly HealthcareDbContext _DbContext;
        public LoginAuditRepository(HealthcareDbContext dbContext)
        {
            _DbContext = dbContext;
        }


    }
}
