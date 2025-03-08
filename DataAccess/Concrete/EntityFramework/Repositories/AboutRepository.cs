using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

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