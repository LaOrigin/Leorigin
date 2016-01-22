using Nop.Core.Domain.Configuration;

namespace Nop.Data.Mapping.Configuration
{
    public partial class SettingMap : NopEntityTypeConfiguration<Setting>
    {
        public SettingMap()
        {
            this.ToTable("Setting");
            this.HasKey(s => s.Id);
            this.Property(s => s.Name).IsRequired().HasMaxLength(200);
            //Imp: Check if limit of 2000 is important
            this.Property(s => s.Value).IsRequired();
        }
    }
}