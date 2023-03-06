namespace Company_ConsoleApp.Data;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DNumber { get; set; }
    public int ManagerSSN { get; set; }
    public DateTime ManagerStartDate { get; set; }
    public int EmpCount { get; set; }
}