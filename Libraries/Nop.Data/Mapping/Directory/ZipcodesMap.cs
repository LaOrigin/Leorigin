using Nop.Core.Domain.Directory;

namespace Nop.Data.Mapping.Directory
{
    public partial class ZipcodesMap : NopEntityTypeConfiguration<Zipcodes>
    {
        public ZipcodesMap()
        {
            this.ToTable("Zipcodes");
            this.HasKey(sp => sp.ZipcodeID);
            this.Property(sp => sp.ZipcodeNumber).IsRequired().HasMaxLength(100);
            this.Ignore(sp => sp.Id);
            this.Ignore(sp => sp.StateProvince);

            this.HasRequired(sp => sp.City)
                .WithMany(c => c.Zipcodes)
                .HasForeignKey(sp => sp.CityID);
            
        }
    }
}