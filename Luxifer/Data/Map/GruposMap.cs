using Luxifer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luxifer.Data.Map
{
    public class LuminariaMap : IEntityTypeConfiguration<Luminaria>
    {
        public void Configure(EntityTypeBuilder<Luminaria> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User);
        }
    }
}
