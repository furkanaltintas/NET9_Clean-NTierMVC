using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class AboutRepository : EfEntityRepositoryBase<About>, IAboutRepository
    {
        public AboutRepository(DbContext context) : base(context) { }

        public string Test()
        {
            return "Test Mesajı";
        }
    }
}