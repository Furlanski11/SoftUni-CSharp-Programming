using P03.Detail_Printer;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {

            List<string> documents = new List<string>() {"work", "more work", "even more work" };
            List<IEmployee> employees = new();
           
           Employee employee = new Employee("George");
           Manager manager = new Manager("Boss", documents);
           employees.Add(employee);
           employees.Add(manager);
            DetailsPrinter printer = new(employees);
            printer.PrintDetails();
        }
    }
}
