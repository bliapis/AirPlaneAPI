using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BL.TesteGol.Infra.Data.Airplane.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}