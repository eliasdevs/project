using AppWebCRUD.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWebCRUD.Data.repositories.implements
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppWebCrudContext _appWebCrudContext) : base(_appWebCrudContext)
        {
        }
    }
}
