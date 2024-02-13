using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        private readonly SqlConnection _connection;

        public List<User> GetWithRoles()
        {
            var query = @"
            SELECT
                [User].*,
                [Role].*
            FROM
                [User]
                LEFT JOIN [UserRole] ON [User].[Id] = [UserRole].[UserId]
                LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
            ORDER BY
                [User].[Id] ASC";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;

                        if (role != null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");

            return users;
        }
    }
}