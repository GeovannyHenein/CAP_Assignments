using UrlShortner.Models;

namespace UrlShortner.Helper;

public class DataMock
{
    public static readonly List<User> Users = new List<User>
    {
        new User { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Password = PasswordHelper.HashPassword("password123", "a1b2c3d4e5f6g7h8i9j0"), PasswordSalt = "a1b2c3d4e5f6g7h8i9j0", Roles = new List<string> { "Admin", "User" } },
        new User { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Password = PasswordHelper.HashPassword("password456", "b2c3d4e5f6g7h8i9j0a1"), PasswordSalt = "b2c3d4e5f6g7h8i9j0a1", Roles = new List<string> { "User" } },
        new User { FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com", Password = PasswordHelper.HashPassword("password789", "c3d4e5f6g7h8i9j0a1b2"), PasswordSalt = "c3d4e5f6g7h8i9j0a1b2", Roles = new List<string> { "Admin" } },
        new User { FirstName = "Emily", LastName = "Davis", Email = "emily.davis@example.com", Password = PasswordHelper.HashPassword("securepass", "d4e5f6g7h8i9j0a1b2c3"), PasswordSalt = "d4e5f6g7h8i9j0a1b2c3", Roles = new List<string> { "Manager" } },
        new User { FirstName = "David", LastName = "Brown", Email = "david.brown@example.com", Password = PasswordHelper.HashPassword("password321", "e5f6g7h8i9j0a1b2c3d4"), PasswordSalt = "e5f6g7h8i9j0a1b2c3d4", Roles = new List<string> { "User" } },
        new User { FirstName = "Sarah", LastName = "Miller", Email = "sarah.miller@example.com", Password = PasswordHelper.HashPassword("pass1234", "f6g7h8i9j0a1b2c3d4e5"), PasswordSalt = "f6g7h8i9j0a1b2c3d4e5", Roles = new List<string> { "Admin" } },
        new User { FirstName = "James", LastName = "Wilson", Email = "james.wilson@example.com", Password = PasswordHelper.HashPassword("secure123", "g7h8i9j0a1b2c3d4e5f6"), PasswordSalt = "g7h8i9j0a1b2c3d4e5f6", Roles = new List<string> { "User" } },
        new User { FirstName = "Olivia", LastName = "Taylor", Email = "olivia.taylor@example.com", Password = PasswordHelper.HashPassword("password987", "h8i9j0a1b2c3d4e5f6g7"), PasswordSalt = "h8i9j0a1b2c3d4e5f6g7", Roles = new List<string> { "Manager" } },
        new User { FirstName = "Isabella", LastName = "Anderson", Email = "isabella.anderson@example.com", Password = PasswordHelper.HashPassword("pass4567", "i9j0a1b2c3d4e5f6g7h8"), PasswordSalt = "i9j0a1b2c3d4e5f6g7h8", Roles = new List<string> { "User" } },
        new User { FirstName = "Liam", LastName = "Thomas", Email = "liam.thomas@example.com", Password = PasswordHelper.HashPassword("pass6789", "j0a1b2c3d4e5f6g7h8i9"), PasswordSalt = "j0a1b2c3d4e5f6g7h8i9", Roles = new List<string> { "Admin" } },
        new User { FirstName = "Sophia", LastName = "Martinez", Email = "sophia.martinez@example.com", Password = PasswordHelper.HashPassword("secure567", "a2b3c4d5e6f7g8h9i0j1"), PasswordSalt = "a2b3c4d5e6f7g8h9i0j1", Roles = new List<string> { "User" } },
        new User { FirstName = "Lucas", LastName = "Lee", Email = "lucas.lee@example.com", Password = PasswordHelper.HashPassword("password890", "b3c4d5e6f7g8h9i0j1a2"), PasswordSalt = "b3c4d5e6f7g8h9i0j1a2", Roles = new List<string> { "Manager" } },
        new User { FirstName = "Ava", LastName = "Lopez", Email = "ava.lopez@example.com", Password = PasswordHelper.HashPassword("pass8901", "c4d5e6f7g8h9i0j1a2b3"), PasswordSalt = "c4d5e6f7g8h9i0j1a2b3", Roles = new List<string> { "Admin" } },
        new User { FirstName = "Ethan", LastName = "White", Email = "ethan.white@example.com", Password = "oauth2.0", PasswordSalt = "n/a", Roles = new List<string> { "User" } }
    };

    public static readonly List<string> Roles = new List<string>
    {
        "Admin",
        "User",
        "Manager"
    };

    public static readonly List<string> Permissions = new List<string>
    {
        "AddCustomer",
        "EditCustomer",
        "DeleteCustomer",
        "ViewCustomerDetails",
        "ManageInventory",
        "PlaceOrders",
        "ManagePayments",
        "ViewReports",
        "AssignTasks",
        "ApproveExpenses",
        "ScheduleMeetings",
        "ManageProjects",
        "AccessSensitiveData",
        "GenerateReports",
        "ModerateDiscussions"
    };

    public static readonly List<(string Role, string Permission)> RolesPermissionsMatrix = new List<(string, string)>
    {
        ("Admin", "AddCustomer"),
        ("Admin", "EditCustomer"),
        ("Admin", "DeleteCustomer"),
        ("Admin", "ViewCustomerDetails"),
        ("Admin", "ManageInventory"),
        ("Admin", "PlaceOrders"),
        ("Admin", "ManagePayments"),
        ("Admin", "ViewReports"),
        ("Admin", "AssignTasks"),
        ("User", "ApproveExpenses"),
        ("User", "ScheduleMeetings"),
        ("User", "ManageProjects"),
        ("User", "AccessSensitiveData"),
        ("Manager", "GenerateReports"),
        ("Manager", "ModerateDiscussions"),
        ("Manager", "ViewReports"),
        ("Admin", "ViewCustomerDetails"),
        ("Admin", "ManageInventory"),
        ("Admin", "PlaceOrders"),
        ("User", "ApproveExpenses"),
        ("User", "ManageProjects"),
        ("Manager", "ViewReports"),
        ("Manager", "AssignTasks"),
        ("Manager", "GenerateReports")
    };

    public static User? GetUserByEmail(string email)
    {
        return Users.FirstOrDefault(user => user.Email!.Equals(email, StringComparison.OrdinalIgnoreCase));
    }
}
