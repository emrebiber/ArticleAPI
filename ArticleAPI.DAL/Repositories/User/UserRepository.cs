using Dapper;
using MySql.Data.MySqlClient;

namespace ArticleAPI.DAL.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        public Models.User GetUser(string email, string password)
        {
            using (var connection = new MySqlConnection(DbConfig.GetConnectionString()))
            {
                var sql = "select * from User where Email = @email and Password = @password and IsActive = 1";

                return connection.QuerySingleOrDefault<Models.User>(sql, new { email = email, password = password });
            }
        }

        public Models.User GetUser(string email)
        {
            using (var connection = new MySqlConnection(DbConfig.GetConnectionString()))
            {
                var sql = "select * from User where Email = @email and IsActive = 1";

                return connection.QuerySingleOrDefault<Models.User>(sql, new { email = email });
            }
        }

        public void AddUser(Models.User user)
        {
            using (var connection = new MySqlConnection(DbConfig.GetConnectionString()))
            {
                connection.Query("insert into User ( FullName, Email, Password, CreatedDate,IsActive, IsDeleted, ActivationGuid, Salt ) " +
                                 "values (@FullName, @Email, @Password, @CreatedDate, @IsActive, @IsDeleted, @ActivationGuid, @Salt) ",
                    new
                    {
                        FullName = user.FullName,
                        Email = user.Email,
                        Pwd = user.Pwd,
                        CreatedDate = user.CreatedDate,
                        IsActive = user.IsActive,
                        IsDeleted = user.IsDeleted,
                        ActivationGuid = user.ActivationGuid,
                        Salt = user.Salt
                    });
            }
        }

        public void ActivateUser(string activationGuid)
        {
            using (var connection = new MySqlConnection(DbConfig.GetConnectionString()))
            {
                var sql = "Update User Set IsActive = 1, ActivationGuid = '' where ActivationGuid = @guid";
                connection.Query(sql,
                    new
                    {
                        guid = activationGuid
                    });
            }
        }
    }
}
