public interface IUserService
{
    bool UserExists(string login, string password);
}
public class UserService : IUserService
{
    private readonly YourDbContext dbContext;

    public UserService(YourDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public bool UserExists(string login, string password)
    {
        return dbContext.Users.Any(u => u.Login == login && u.Password == password);
    }
}
