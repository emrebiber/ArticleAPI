namespace ArticleAPI.DAL.Repositories.User
{
    public interface IUserRepository
    {
        void AddUser(Models.User user);
        Models.User GetUser(string email, string password);
        Models.User GetUser(string email);
        void ActivateUser(string activationGuid);
    }
}
