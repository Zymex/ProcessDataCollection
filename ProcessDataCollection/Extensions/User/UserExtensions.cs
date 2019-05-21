using ProcessDataCollection._ApplicationModels.DataModels;
using ProcessDataCollection.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessDataCollection.Extensions.Auto;
namespace ProcessDataCollection.Extensions.User
{
    public static class UserExtensions
    {

        public static ProcessEntries AddEntries(this ApplicationContext db, ProcessEntries processEntries)
        {
            db._ProcessEntries.Add(processEntries);

            //Auto our Items
            db.AutoItems(processEntries.In, processEntries.Out, processEntries.Id);
            db.SaveChanges();

            return processEntries;
        }
        public static ProcessItems ResolveIssues(this ApplicationContext db, ProcessItems processItems)
        {
            //DO A BUNCH OF STUFF
            return processItems;
        }

        //

        //

    }
}
