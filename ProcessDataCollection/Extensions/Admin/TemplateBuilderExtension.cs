using ProcessDataCollection.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection.Extensions.Admin
{
    public static class TemplateBuilderExtension
    {
        public static string CheckTemplateName(this ApplicationContext db, string check)
        {
            //Check to see if the name exists when we create our template.
            if (String.IsNullOrEmpty(check))
            {
            return 500("The value cannot be empty.");
            }
            try
            {
             var checkMe = db.TPL_KitTemplates.Where(x => x.TemplateName == check).FirstOrDefault();
             if (check)
             {
                 return 500("The template name is currently in use");
             }
            }
            catch (System.Exception ex)
            {
                
                throw;
                return ex;
            }
            return check;
        }
    }
}
