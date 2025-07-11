namespace unlocker_Api.src.Ecommerce.Infrastructure.Persistence.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Phone)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(c => c.Active)
                   .IsRequired();
        }
    }
}