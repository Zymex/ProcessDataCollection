using ProcessDataCollection._ApplicationModels.DataModels;
using ProcessDataCollection._ApplicationModels.DataModels.AdminModels.DataTemplate;
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

        public static Boolean CreateKitFromTemplate(this ApplicationContext db, KitTemplateModel model)
        {
            //This function allows the user to build a kit from a template.

            //Grab out template from the database
            var dataTemplate = db.TPL_KitTemplates.Where(x => x.TemplateId == model.Id).FirstOrDefault();

            //Grab out list of attached processes
            var dataTemplateProcessList = db.TPL_ProcessTemplates.Where(x => x.KitTemplateId == model.Id).ToList();

            //Do work
            Kit newKitFromTemplate = new Kit
            {
                StartQty = model.StartQty,
                Opened = true,
                DateAdded = DateTime.Now,
                WorkOrder = model.WorkOrder,
                PartNumber = model.PartNumber
                //Save part number as template name
            };


            //Define a list to add to
            List<Process> newProcessList = new List<Process>();

            //Now we add to our new process list
            foreach (var process in dataTemplateProcessList)
            {
                newProcessList.Add(new Process
                {
                    In = newKitFromTemplate.StartQty,
                    PartNumber = newKitFromTemplate.PartNumber,
                    StepOrder = process.StepOrder,
                    ProcessName = process.ProcessName,
                    KitId = newKitFromTemplate.Id,
                    WorkOrder = newKitFromTemplate.WorkOrder
                });

            }
            //Now we set the KitProcesses equal to our new list
            newKitFromTemplate.Processes = newProcessList;

            //Add our object & save
            db.Add(newKitFromTemplate);
            db.SaveChanges();
            return true;

        }
    }
}
