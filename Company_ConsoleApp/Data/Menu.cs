using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Company_ConsoleApp.Data;

public class Menu
{
    // Connection string for Database
    private string connectionString = "Data source=localhost;" +
                                  "Initial catalog=Company;" +
                                  "Integrated security=True";
    public void Start()
    {
        ShowMainMenu();
        StartLoop();
    }

    private void ShowMainMenu()
    {
        Console.WriteLine("Compulsory Assignment - DBD");
        Console.WriteLine("");
        Console.WriteLine("Please select a DB Procedure:");
        Console.WriteLine("1 - Create new Department");
        Console.WriteLine("2 - Update Department Name");
        Console.WriteLine("3 - Update Department Manager");
        Console.WriteLine("4 - Delete Department");
        Console.WriteLine("5 - Get Department from ID");
        Console.WriteLine("6 - Get All Departments");
    }


    private void StartLoop()
    {
        int choice;
        while ((choice = GetMainMenuSelection()) != 0)
        {
            if (choice == 1)
            {
                CreateDepartment();
            }
            if (choice == 2)
            {
                UpdateDepartmentName();
            }
            if (choice == 3)
            {
                UpdateDepartmentManager();
            }
            if (choice == 4)
            {
                DeleteDepartment();
            }
            if (choice == 5)
            {
                GetDepartmentById();
            }
            if (choice == 6)
            {
                GetAllDepartments();
            }
        }
    }

    private void GetAllDepartments()
    {
        Console.Clear();
        List<Department> departments = GetAllProcedure();
        foreach (Department department in departments)
        {
            Console.WriteLine($"ID: {department.Id}, Name: {department.Name}, ManagerSSN {department.ManagerSSN}");
        }
        ShowMainMenu();
    }

    private List<Department> GetAllProcedure()
    {
        List<Department> departments = new List<Department>();
        // Stored Procedure Name
        string procedureName = "usp_GetAllDepartments";

        // Create SQL connection object
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Open Connection
            connection.Open();
            
            // Create a new object using the stored procedure name and connection object
            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                // Set stored procedure type
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Department department = new Department
                        {
                            Id = (int) reader["DNumber"],
                            Name = (string) reader["DName"],
                            ManagerSSN = (int) reader["MgrSSN"]
                        };
                        departments.Add(department);
                    }
                }
            }
            // Close connection
            connection.Close();
        }
        return departments;
    }

    private void GetDepartmentById()
    {
        throw new NotImplementedException();
    }

    private void DeleteDepartment()
    {
        Console.WriteLine("Please enter the ID of the Department you wish to delete:");
        var departmentId = Console.ReadLine();
        DeleteProcedure(Int32.Parse(departmentId));
        Console.Clear();
        ShowMainMenu();
    }

    private void DeleteProcedure(int departmentId)
    {
        // Stored Procedure Name
        string procedureName = "usp_DeleteDepartment";

        // Create SQL connection object
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Open Connection
            connection.Open();
            
            // Create a new object using the stored procedure name and connection object
            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                // Set stored procedure type
                command.CommandType = CommandType.StoredProcedure;
                
                // Add parameters to the stored procedure if needed
                command.Parameters.AddWithValue("@DNumber", departmentId);
                
                // Execute procedure
                command.ExecuteNonQuery();
            }
            // Close connection
            connection.Close();
        }
    }

    private void UpdateDepartmentManager()
    {
        Console.WriteLine("Select a Department to edit by ID:");
        int idOfDepartment = Int32.Parse(Console.ReadLine());
        Console.Clear();
        
        // Name
        var updatedSSN = Console.ReadLine();

        UpdateNameProcedure(idOfDepartment, Int32.Parse(updatedSSN));
        Console.Clear();
        ShowMainMenu();
    }

    private void UpdateNameProcedure(int idOfDepartment, int updatedSSN)
    {
        // Stored Procedure Name
        string procedureName = "usp_UpdateDepartmentManager";

        // Create SQL connection object
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Open Connection
            connection.Open();
            
            // Create a new object using the stored procedure name and connection object
            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                // Set stored procedure type
                command.CommandType = CommandType.StoredProcedure;
                
                // Add parameters to the stored procedure if needed
                command.Parameters.AddWithValue("@DNumber", idOfDepartment);
                command.Parameters.AddWithValue("@MgrSSN", updatedSSN);
                
                // Execute procedure
                command.ExecuteNonQuery();
            }
            // Close connection
            connection.Close();
        }
    }
    private void UpdateDepartmentName()
    {
        Console.WriteLine("Select a Department Name to edit by ID:");
        int idOfDepartment = Int32.Parse(Console.ReadLine());
        Console.Clear();
        
        // Name
        var updatedName = Console.ReadLine();

        UpdateNameProcedure(idOfDepartment, updatedName);
        Console.Clear();
        ShowMainMenu();
    }

    private void UpdateNameProcedure(int idOfDepartment, string updatedName)
    {
        // Stored Procedure Name
        string procedureName = "usp_UpdateDepartmentName";

        // Create SQL connection object
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Open Connection
            connection.Open();
            
            // Create a new object using the stored procedure name and connection object
            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                // Set stored procedure type
                command.CommandType = CommandType.StoredProcedure;
                
                // Add parameters to the stored procedure if needed
                command.Parameters.AddWithValue("@DNumber", idOfDepartment);
                command.Parameters.AddWithValue("@DName", updatedName);
                
                // Execute procedure
                command.ExecuteNonQuery();
            }
            // Close connection
            connection.Close();
        }
    }

    private void CreateDepartment()
    {
        Console.Clear();

        // Department Name
        Console.WriteLine("Please enter new Department name:");
        var writtenName = Console.ReadLine();
        if (String.IsNullOrEmpty(writtenName))
        {
            Console.Clear();
            Console.WriteLine("Value can't be null/empty");
            return;
        }
        
        // Department Manager SSN
        Console.WriteLine("Please enter new Department Managers Social Security number:");
        var writtenSSN = Console.ReadLine();
        if (String.IsNullOrEmpty(writtenSSN))
        {
            Console.Clear();
            Console.WriteLine("Value can't be null/empty");
            return;
        }
        var newDepartment = new Department
        {
            Name = writtenName,
            ManagerSSN = Int32.Parse(writtenSSN),
            ManagerStartDate = DateTime.Now
        };
        CreateProcedure(newDepartment);
        Console.Clear();
        ShowMainMenu();
        
    }

    private void CreateProcedure(Department newDepartment)
    {
        // Stored Procedure Name
        string procedureName = "usp_CreateDepartment";

        // Create SQL connection object
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Open Connection
            connection.Open();
            
            // Create a new object using the stored procedure name and connection object
            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                // Set stored procedure type
                command.CommandType = CommandType.StoredProcedure;
                
                // Add parameters to the stored procedure if needed
                command.Parameters.AddWithValue("@DName", newDepartment.Name);
                command.Parameters.AddWithValue("@MgrSSN", newDepartment.ManagerSSN);
                
                // Execute procedure
                command.ExecuteNonQuery();
            }
            // Close connection
            connection.Close();
        }
    }

    private int GetMainMenuSelection()
    {
        var selectionString = Console.ReadLine();
        if (int.TryParse(selectionString, out var selection))
        {
            return selection;
        }

        return -1;
    }
}