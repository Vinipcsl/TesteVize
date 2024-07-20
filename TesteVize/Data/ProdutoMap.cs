using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteVize.Models;

namespace TesteVize.Data
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
           builder.HasKey(x => x.Id);
           builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
           builder.Property(x => x.Type).IsRequired().HasMaxLength(10);
        }
    }
}
