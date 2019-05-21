using ProcessDataCollection._ApplicationModels.DataModels.AdminModels.Audit;
using ProcessDataCollection.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection.Extensions.Audit
{
    public static class AuditExtensions
    {
        //--1--// AUDIT LOG
        public static ApplicationActionLog Audit(this ApplicationContext db, ApplicationActionLog applicationAuditLog)
        {
            db.AU_APPLICATION_LOG.Add(applicationAuditLog);
            db.SaveChanges();
            return applicationAuditLog;
        }
        public static UserActionLog Audit(this ApplicationContext db, UserActionLog userActionLog)
        {
            db.AU_USER_LOG.Add(userActionLog);
            db.SaveChanges();
            return userActionLog;
        }
        public static KitActionLog Audit(this ApplicationContext db, KitActionLog kitActionLog)
        {
            db.AU_KIT_LOG.Add(kitActionLog);
            db.SaveChanges();
            return kitActionLog;
        }
        public static ProcessActionLog Audit(this ApplicationContext db, ProcessActionLog processActionLog)
        {
            db.AU_PROCESS_LOG.Add(processActionLog);
            db.SaveChanges();
            return processActionLog;
        }
        //--1--// 
    }
}
