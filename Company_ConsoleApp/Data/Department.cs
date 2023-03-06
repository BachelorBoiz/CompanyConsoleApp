using System.Data.SqlTypes;

namespace Company_ConsoleApp.Data;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Decimal ManagerSSN { get; set; }
    public DateTime ManagerStartDate { get; set; }
    public int EmpCount { get; set; }
}