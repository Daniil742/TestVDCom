using Application.Queries.ContractQueries;

var c = new ContractQuery();

c.CreateReport();

c.GetContracAtmountForYear();
Console.WriteLine();
c.GetContracAtmountForRussia();
Console.WriteLine();
c.GetEmailListAuthorizedPersons();
Console.WriteLine();
c.ChangeContractStatus();