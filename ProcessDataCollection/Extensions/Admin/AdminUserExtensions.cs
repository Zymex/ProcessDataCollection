using ProcessDataCollection.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection.Extensions.Admin
{
    public static class AdminUserExtensions
    {
        public static bool UpdateUserId(this ApplicationContext db, Guid userId, string OperatorId)
        {
            if (GetUser(db,userId))
            {
              db.ApplicationUsers.Where(x => x.Guid == userId).FirstOrDefault().OperatorId = OperatorId;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public static bool GetUser(this ApplicationContext db, Guid userId)
        {
            var user = db.ApplicationUsers.Where(x => x.Guid == userId);
            if (user.Any())
            {
                return true;
            }
            return false;
        }
    }
}
