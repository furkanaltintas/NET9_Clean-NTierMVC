using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class WebSiteTemplateConfiguration : IEntityTypeConfiguration<WebSiteTemplate>
{
    public void Configure(EntityTypeBuilder<WebSiteTemplate> builder)
    {
        throw new NotImplementedException();
    }
}