using Microsoft.AspNetCore.Mvc;
using ProcessDataCollection._ApplicationModels.DataModels;
using ProcessDataCollection._ApplicationModels.DataModels.AdminModels.Audit;
using ProcessDataCollection._ApplicationModels.DataModels.AdminModels.DataTemplate;
using ProcessDataCollection._ApplicationModels.DataModels.AdminModels.Process;
using ProcessDataCollection._ApplicationModels.DataModels.AdminModels.ResolutionDictionary;
using ProcessDataCollection.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection.Extensions.Admin
{
    public static class AdminExtensions
    {
        //--1--//Template Builder

        public static bool TemplateBuilder(this ApplicationContext db, string name)
        {
            //Here we add our new template after we determine our check.
            KitTemplate template = new KitTemplate();
            if (db.CheckTemplateName(name))
            {
                template.TemplateName = name;
                db.TPL_KitTemplates.Add(template);
                db.SaveChanges();
                return true;
            }
                return false;
        }

        public static ProcessTemplate TemplateBuilder(this ApplicationContext db, ProcessTemplate template)
        {
            db.TPL_ProcessTemplates.Add(template);
            db.SaveChanges();
            return template;
        }
        //--1--//

        //--2--//Resolutions Added
        public static Reason DictionaryBuilder(this ApplicationContext db, Reason reason)
        {
            db.RES_Reasons.Add(reason);
            db.SaveChanges();
            return reason;
        }
        public static ReasonCategory DictionaryBuilder(this ApplicationContext db, ReasonCategory reasonCategory)
        {
            db.RES_ReasonCategories.Add(reasonCategory);
            db.SaveChanges();
            return reasonCategory;
        }
        public static CategoryItems DictionaryBuilder(this ApplicationContext db, CategoryItems categoryItems)
        {
            db.RES_CategoryItems.Add(categoryItems);
            db.SaveChanges();
            return categoryItems;
        }
        //--2--//

        //--3--// Other Admin actions
        public static bool AddProcessName(this ApplicationContext db, string name)
        {
            if (CheckProcessName(db, name))
            {
                var newProcessDefinition = db.DEF_ProcessDefinitions.Add(new ProcessDefinitions
                {
                    Name = name
                });
                db.Add(newProcessDefinition);
                return true;
            }
                return false;
            
        }
        public static bool CheckProcessName(this ApplicationContext db, string name)
        {
            //Validation checking
            if (String.IsNullOrEmpty(name))
            {
                return false;
            }

            var checkName = db.DEF_ProcessDefinitions.Where(x => x.Name == name).FirstOrDefault();
            if (checkName.Name == name)
            {
                return false;
            }
                return true;

        }
        public static Kit CreateKit(this ApplicationContext db, Kit kit)
        {
            db._Kit.Add(kit);
            db.SaveChanges();
            return kit;
        }
        public static Process CreateProcess(this ApplicationContext db, Process process)
        {
            db._Processes.Add(process);
            db.SaveChanges();
            return process;
        }
        public static bool ToggleStatus(this ApplicationContext db, Guid Id)
        {
            var toggle = db._Kit.Where(x => x.Id == Id).FirstOrDefault();
            if (toggle.Opened)
            {
                toggle.Opened = false;
                return false;
            }
            else
            {
                toggle.Opened = true;
                return true;
            }

        }
        public static void UpdateKitQty(this ApplicationContext db,Guid id, int value)
        {
            var oldQty = db._Kit.Where(x => x.Id == id).FirstOrDefault().StartQty;
            oldQty = oldQty + value;

            //Now we update our process qty
            UpdateProcessQty(db, id, value);
        }

        public static void UpdateProcessQty(this ApplicationContext db, Guid id, int value)
        {
            //We itterate through our processes, updating the qtys of each
            var processesToUpdate = db._Processes.Where(x => x.KitId == id);

            foreach (var process in processesToUpdate)
            {
                //Updating our values
                process.In = process.In + value;
                db.Update(process);
            }
            db.SaveChanges();

        }
        //--3--//


    }
}
