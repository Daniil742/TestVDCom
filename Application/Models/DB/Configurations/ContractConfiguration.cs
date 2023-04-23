using Application.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Models.DB.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasData(
                new Contract
                {
                    Id = 1,
                    LegalPersonId = 1,
                    PhysicalPersonId = 1,
                    ContracAtmount = 100,
                    Status = "Действующий",
                    SingingDate = DateTime.Now
                },

                new Contract
                {
                    Id = 2,
                    LegalPersonId = 2,
                    PhysicalPersonId = 2,
                    ContracAtmount = 150,
                    Status = "Заключен",
                    SingingDate = DateTime.Now
                },

                new Contract
                {
                    Id = 3,
                    LegalPersonId = 2,
                    PhysicalPersonId = 2,
                    ContracAtmount = 40000,
                    Status = "Заключен",
                    SingingDate = DateTime.Now
                }
            );
        }
    }
}
