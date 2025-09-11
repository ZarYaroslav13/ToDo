using ToDo.API.Infrastructure.Entities;
using ToDo.API.Infrastructure.Enums;

namespace ToDo.API.Infrastructure;

public static class DbSeeder
{
    private static List<User> _users = new()
    {
        new()
        {
            Id = 1,
            Name = "John",
            Surname = "Doe",
            Email = "JohnDoeEmail123@gmail.com",
            Password = "John12345"
        },
        new()
        {
            Id = 2,
            Name = "Alice",
            Surname = "Smith",
            Email = "AliceSmith456@gmail.com",
            Password = "Alice456"
        },
        new()
        {
            Id = 3,
            Name = "Robert",
            Surname = "Johnson",
            Email = "RobertJ789@gmail.com",
            Password = "Robert789"
        },
        new()
        {
            Id = 4,
            Name = "Emily",
            Surname = "Brown",
            Email = "EmilyBrown101@gmail.com",
            Password = "Emily101"
        },
        new()
        {
            Id = 5,
            Name = "Michael",
            Surname = "Davis",
            Email = "MichaelDavis202@gmail.com",
            Password = "Michael202"
        },
        new()
        {
            Id = 6,
            Name = "Sophia",
            Surname = "Wilson",
            Email = "SophiaWilson303@gmail.com",
            Password = "Sophia303"
        },
        new()
        {
            Id = 7,
            Name = "David",
            Surname = "Miller",
            Email = "DavidMiller404@gmail.com",
            Password = "David404"
        }

    };

    private static List<UserTask> _userTasks = new()
{
    // Tasks for User 1 (John Doe)
    new UserTask { Id = 1, Title = "Buy ice cream", Description = "Buy strawberry ice cream", Priority = TaskPriority.Low, Deadline = DateTime.Now.AddDays(2), UserId = 1 },
    new UserTask { Id = 2, Title = "Finish report", Description = "Complete the quarterly report", Priority = TaskPriority.High, Deadline = DateTime.Now.AddDays(1), UserId = 1 },
    new UserTask { Id = 3, Title = "Call Mike", Description = "Discuss project details", Priority = TaskPriority.Medium, Deadline = DateTime.Now.AddDays(3), UserId = 1 },
    new UserTask { Id = 4, Title = "Grocery shopping", Description = "Buy vegetables and fruits", Priority = TaskPriority.Medium, Deadline = DateTime.Now.AddDays(4), UserId = 1 },
    new UserTask { Id = 5, Title = "Clean desk", Description = "Organize office desk", Priority = TaskPriority.Low, Deadline = DateTime.Now.AddDays(5), UserId = 1 },

    // Tasks for User 2 (Alice Smith)
    new UserTask { Id = 6, Title = "Plan birthday party", Description = "Organize Alice's birthday party", Priority = TaskPriority.Medium, Deadline = DateTime.Now.AddDays(5), UserId = 2 },
    new UserTask { Id = 7, Title = "Buy groceries", Description = "Milk, eggs, and bread", Priority = TaskPriority.Low, Deadline = DateTime.Now.AddDays(2), UserId = 2 },
    new UserTask { Id = 8, Title = "Gym session", Description = "Attend yoga class", Priority = TaskPriority.Medium, Deadline = DateTime.Now.AddDays(1), UserId = 2 },
    new UserTask { Id = 9, Title = "Call dentist", Description = "Schedule dental checkup", Priority = TaskPriority.High, Deadline = DateTime.Now.AddDays(3), UserId = 2 },
    new UserTask { Id = 10, Title = "Read book", Description = "Read 20 pages of a novel", Priority = TaskPriority.Low, Deadline = DateTime.Now.AddDays(4), UserId = 2 },

    // Tasks for User 3 (Robert Johnson)
    new UserTask { Id = 11, Title = "Fix bike", Description = "Repair the front tire", Priority = TaskPriority.High, Deadline = DateTime.Now.AddDays(3), UserId = 3 },
    new UserTask { Id = 12, Title = "Read book", Description = "Finish reading 'C# in Depth'", Priority = TaskPriority.Low, Deadline = DateTime.Now.AddDays(7), UserId = 3 },
    new UserTask { Id = 13, Title = "Team meeting", Description = "Weekly project meeting", Priority = TaskPriority.Medium, Deadline = DateTime.Now.AddDays(1), UserId = 3 },
    new UserTask { Id = 14, Title = "Update resume", Description = "Add recent projects", Priority = TaskPriority.High, Deadline = DateTime.Now.AddDays(4), UserId = 3 },
    new UserTask { Id = 15, Title = "Laundry", Description = "Wash clothes", Priority = TaskPriority.Low, Deadline = DateTime.Now.AddDays(2), UserId = 3 },

    // Tasks for User 4 (Emily Brown)
    new UserTask { Id = 16, Title = "Buy flowers", Description = "Roses for mom", Priority = TaskPriority.Low, Deadline = DateTime.Now.AddDays(1), UserId = 4 },
    new UserTask { Id = 17, Title = "Submit assignment", Description = "History assignment", Priority = TaskPriority.High, Deadline = DateTime.Now.AddDays(2), UserId = 4 },
    new UserTask { Id = 18, Title = "Clean kitchen", Description = "Deep clean the kitchen", Priority = TaskPriority.Medium, Deadline = DateTime.Now.AddDays(3), UserId = 4 },
    new UserTask { Id = 19, Title = "Attend workshop", Description = "Photography workshop", Priority = TaskPriority.Medium, Deadline = DateTime.Now.AddDays(5), UserId = 4 },
    new UserTask { Id = 20, Title = "Meditation", Description = "Morning meditation session", Priority = TaskPriority.Low, Deadline = DateTime.Now.AddDays(1), UserId = 4 },

    // Tasks for User 5 (Michael Davis)
    new UserTask { Id = 21, Title = "Pay bills", Description = "Electricity and internet", Priority = TaskPriority.High, Deadline = DateTime.Now.AddDays(2), UserId = 5 },
    new UserTask { Id = 22, Title = "Buy gift", Description = "Gift for friend's wedding", Priority = TaskPriority.Medium, Deadline = DateTime.Now.AddDays(4), UserId = 5 },
    new UserTask { Id = 23, Title = "Watch tutorial", Description = "Learn about Blazor Server", Priority = TaskPriority.Low, Deadline = DateTime.Now.AddDays(1), UserId = 5 },
    new UserTask { Id = 24, Title = "Plan vacation", Description = "Decide destination and dates", Priority = TaskPriority.Medium, Deadline = DateTime.Now.AddDays(10), UserId = 5 },
    new UserTask { Id = 25, Title = "Car wash", Description = "Clean interior and exterior", Priority = TaskPriority.Low, Deadline = DateTime.Now.AddDays(3), UserId = 5 },

    // Tasks for User 6 (Sophia Wilson)
    new UserTask { Id = 26, Title = "Doctor appointment", Description = "Annual checkup", Priority = TaskPriority.High, Deadline = DateTime.Now.AddDays(3), UserId = 6 },
    new UserTask { Id = 27, Title = "Bake cake", Description = "Chocolate cake for party", Priority = TaskPriority.Medium, Deadline = DateTime.Now.AddDays(2), UserId = 6 },
    new UserTask { Id = 28, Title = "Walk the dog", Description = "Evening walk in park", Priority = TaskPriority.Low, Deadline = DateTime.Now.AddDays(1), UserId = 6 },
    new UserTask { Id = 29, Title = "Clean garage", Description = "Organize tools and boxes", Priority = TaskPriority.Medium, Deadline = DateTime.Now.AddDays(5), UserId = 6 },
    new UserTask { Id = 30, Title = "Read research paper", Description = "Cybersecurity topic", Priority = TaskPriority.High, Deadline = DateTime.Now.AddDays(4), UserId = 6 },

    // Tasks for User 7 (David Miller)
    new UserTask { Id = 31, Title = "Car service", Description = "Oil change and tire rotation", Priority = TaskPriority.High, Deadline = DateTime.Now.AddDays(5), UserId = 7 },
    new UserTask { Id = 32, Title = "Finish homework", Description = "Math exercises", Priority = TaskPriority.Medium, Deadline = DateTime.Now.AddDays(1), UserId = 7 },
    new UserTask { Id = 33, Title = "Call parents", Description = "Weekly check-in call", Priority = TaskPriority.Low, Deadline = DateTime.Now.AddDays(2), UserId = 7 },
    new UserTask { Id = 34, Title = "Grocery shopping", Description = "Prepare weekly meal plan", Priority = TaskPriority.Medium, Deadline = DateTime.Now.AddDays(3), UserId = 7 },
    new UserTask { Id = 35, Title = "Organize books", Description = "Sort and arrange bookshelf", Priority = TaskPriority.Low, Deadline = DateTime.Now.AddDays(4), UserId = 7 },
};

    
    public static List<User> Users => _users ??= new();
    
    public static List<UserTask> UsersTasks => _userTasks ??= new();
}