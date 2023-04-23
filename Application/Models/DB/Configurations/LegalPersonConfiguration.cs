using Application.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Models.DB.Configurations
{
    public class LegalPersonConfiguration : IEntityTypeConfiguration<LegalPerson>
    {
        public void Configure(EntityTypeBuilder<LegalPerson> builder)
        {
            builder.HasData(
                new LegalPerson
                {
                    Id = 1,
                    CompanyName = "Название1",
                    INN = "1111111111",
                    OGRN = "222222222222",
                    Country = "Россия",
                    City = "Москва",
                    Address = "Майская 32",
                    Email = "dfsfdgwfesd@sdf.com",
                    Phone = "11243234213",
                },

                new LegalPerson
                {
                    Id = 2,
                    CompanyName = "Название2",
                    INN = "1111111111",
                    OGRN = "222222222222",
                    Country = "Россия",
                    City = "Ижевск",
                    Address = "Майская 32",
                    Email = "dfsfdgwfesd@sdf.com",
                    Phone = "11243234213",
                }
            );
        }
    }
}
