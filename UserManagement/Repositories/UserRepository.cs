using System;
using System.Threading.Tasks;
using UserManagement.Data.Models;

namespace UserManagement.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        internal Task GetT()
        {
            throw new NotImplementedException();
        }
    }
}
