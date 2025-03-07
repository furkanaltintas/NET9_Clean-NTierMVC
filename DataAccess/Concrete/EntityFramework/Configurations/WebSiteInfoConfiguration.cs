using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class WebSiteInfoConfiguration : IEntityTypeConfiguration<WebSiteInfo>
{
    public void Configure(EntityTypeBuilder<WebSiteInfo> builder)
    {
        throw new NotImplementedException();
    }
}