using Microsoft.AspNetCore.Mvc;
using ProcessDataCollection._ApplicationModels.DataModels;
using ProcessDataCollection._ApplicationModels.DataModels.AdminModels.Audit;
using ProcessDataCollection._ApplicationModels.DataModels.AdminModels.DataTemplate;
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
            else
            {
                return false;
            }
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

        //--3--//


    }
}
