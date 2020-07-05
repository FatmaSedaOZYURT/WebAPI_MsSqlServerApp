using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.DAL
{
    public class BaseEntity
    {
        protected NORTHWNDEntities db;
        public BaseEntity()
        {
            db = new NORTHWNDEntities();
        }
    }
}
