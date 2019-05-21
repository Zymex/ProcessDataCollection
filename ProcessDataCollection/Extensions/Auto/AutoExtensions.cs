using ProcessDataCollection._ApplicationModels.DataModels;
using ProcessDataCollection.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection.Extensions.Auto
{
    public static class AutoExtensions
    {
        public static void AutoItems(this ApplicationContext db, int IN, int OUT, int ProcessEntriesId)
        {
            var value = IN - OUT;

            for (int i = 0; i < value; i++)
            {
                ProcessItems p = new ProcessItems {
                    ProcessEntriesId = ProcessEntriesId,
                    Category = "Not Modified",
                    Reason = "Not Modified",
                    Qty = 1
                };
                db._ProcessItems.Add(p);
                db.SaveChanges();
            }
        }
    }
}
