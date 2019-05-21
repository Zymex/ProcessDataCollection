using ProcessDataCollection._ApplicationModels.DataModels;
using ProcessDataCollection.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection.Extensions.Admin
{
    public static class TemplateBuilderExtension
    {
        public static bool CheckTemplateName(this ApplicationContext db, string check)
        {
            //Check to see if the name exists when we create our template.
            if (String.IsNullOrEmpty(check))
            {
                return false;
            }
            foreach (var item in db.TPL_KitTemplates)
            {
                if (item.TemplateName == check)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;   
        }

        public static void CreateKitFromTemplate(this ApplicationContext db, Guid id)
        {
            //Grab out template from the database
            var dataTemplate = db.TPL_KitTemplates.Where(x => x.TemplateId == id).FirstOrDefault();

            //Do work
            Kit newKitFromTemplate = new Kit
            {
                StartQty = 100,
                Opened = true,
                DateAdded = DateTime.Now,
                Processes = //New list of Processes
            };
            
        }
    }
}
