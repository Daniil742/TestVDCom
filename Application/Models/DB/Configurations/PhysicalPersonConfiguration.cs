using Application.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Models.DB.Configurations
{
    public class PhysicalPersonConfiguration : IEntityTypeConfiguration<PhysicalPerson>
    {
        public void Configure(EntityTypeBuilder<PhysicalPerson> builder)
        {
            builder.HasData(
                new PhysicalPerson
                {
                    Id = 1,
                    Name = "Имя1",
                    Surname = "Фимилия1",
                    Patronymic = "Отчество1",
                    Gender = "Муж.",
                    Age = 61,
                    Workplace = "Работаю дома",
                    Country = "Россия",
                    City = "Ижевск",
                    Address = "Майская 23",
                    Email = "sfdwesd@sdf.com",
                    Phone = "1123434213",
                    BirthDay = DateTime.Now
                },

                new PhysicalPerson
                {
                    Id = 2,
                    Name = "Имя2",
                    Surname = "Фимилия2",
                    Patronymic = "Отчество2",
                    Gender = "Муж.",
                    Age = 18,
                    Workplace = "Работаю в офисе",
                    Country = "Россия",
                    City = "Ижевск",
                    Address = "Майская 32",
                    Email = "dfsfdgwfesd@sdf.com",
                    Phone = "11243234213",
                    BirthDay = DateTime.Now
                }
            );
        }
    }
}
