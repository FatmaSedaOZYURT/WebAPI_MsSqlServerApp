using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.DAL
{
    public class UsersDAL : BaseEntity
    {
        public User GetUserByApiKey(string apiKey)
        {
            return db.Users.SingleOrDefault(a => a.UserKey.ToString() == apiKey);
        }

        public User GetUserByName(string name)
        {
            return db.Users.SingleOrDefault(a => a.Name == name);
        }
    }
}
