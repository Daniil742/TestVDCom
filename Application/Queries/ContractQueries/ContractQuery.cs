using Application.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Application.Queries.ContractQueries
{
    public class ContractQuery
    {
        private readonly ApplicationDbContext _context;

        public ContractQuery()
        {
            _context= new ApplicationDbContext();
        }

        /// <summary>
        /// Получает сумму всех заключенных договоров за текущий год.
        /// </summary>
        /// <returns> Сумма всх заключенных договоров за текущий год. </returns>
        public void GetContracAtmountForYear()
        {
            var sum = _context.Contracts.Where(c => c.SingingDate.Year == DateTime.Now.Year &&
                                                  c.Status == "Заключен")
                                      .Sum(c => c.ContracAtmount);

            Console.WriteLine(sum);
        }

        /// <summary>
        /// Получает сумму всех заключенных договоров по каждому контрагенту из России.
        /// </summary>
        public void GetContracAtmountForRussia()
        {
            var sums = from c in _context.Contracts
                       where c.LegalPerson!.Country == "Россия" &&
                             c.Status == "Заключен"
                       group c by c.LegalPerson!.CompanyName into g
                       select new
                       {
                           g.Key,
                           Total = g.Sum(s => s.ContracAtmount)
                       };

            foreach (var s in sums)
            {
                Console.WriteLine($"{s.Key} - {s.Total}");
            }
        }

        /// <summary>
        /// Получает списов Email уполномоченных лиц, заключивших договора за посление 30 дней,
        /// на сумму больше 40000.
        /// </summary>
        public void GetEmailListAuthorizedPersons()
        {
            var emails = from c in _context.Contracts
                         where c.SingingDate >= DateTime.Now.AddDays(-30)
                         group c by c.LegalPerson!.Email into g
                         where g.Sum(s => s.ContracAtmount) >= 40000
                         select new
                         {
                             g.Key
                         };

            foreach (var e in emails)
            {
                Console.WriteLine($"{e.Key}");
            }
        }

        /// <summary>
        /// Изменяет статус договора на "Расторгнут" для физических лиц,
        /// у которых есть действующий договор, и возраст которых старше 60 лет включительно.
        /// </summary>
        public void ChangeContractStatus()
        {
            _context.Contracts.Where(c => c.Status == "Действующий" &&
                                        c.PhysicalPerson!.Age >= 60)
                            .ExecuteUpdate(p => p.SetProperty(u => u.Status, u => "Расторгнут"));
        }

        /// <summary>
        /// Создает отчет и сохраяет файл report.json на рабочий стол.
        /// </summary>
        public void CreateReport()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.json");

            var persons = from c in _context.Contracts
                          where c.Status == "Действующий" &&
                                c.LegalPerson!.City == "Москва"
                          select new
                          {
                              FullName = $"{c.PhysicalPerson!.Surname} {c.PhysicalPerson!.Name} {c.PhysicalPerson!.Patronymic}",
                              Email = c.PhysicalPerson!.Email,
                              Phone = c.PhysicalPerson!.Phone,
                              BirthDay = c.PhysicalPerson!.BirthDay
                          };

            var json = JsonSerializer.Serialize(persons);
            File.WriteAllText(path, json);
        }
    }
}
