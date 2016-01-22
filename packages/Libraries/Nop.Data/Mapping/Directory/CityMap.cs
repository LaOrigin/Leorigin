using Nop.Core.Domain.Directory;

namespace Nop.Data.Mapping.Directory
{
    public partial class CityMap : NopEntityTypeConfiguration<City>
    {
        public CityMap()
        {
            this.ToTable("City");
            this.HasKey(sp => sp.CityID);
            this.Property(sp => sp.CityName).IsRequired().HasMaxLength(100);
            this.Ignore(sp => sp.Id);
            //this.Ignore(sp => sp.StateProvince);


            this.HasRequired(sp => sp.StateProvince)
                .WithMany(c => c.City)
                .HasForeignKey(sp => sp.StateID);
        }
    }
}