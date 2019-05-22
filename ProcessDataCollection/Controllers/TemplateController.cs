using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessDataCollection._ApplicationModels.DataModels.AdminModels.DataTemplate;
using ProcessDataCollection.Context;
using ProcessDataCollection.Extensions.Admin;

namespace ProcessDataCollection.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private ApplicationContext db;
        public TemplateController(ApplicationContext db)
        {
            this.db = db;
        }
        

        [HttpPost]
        public Boolean KitTemplateBuilder([FromForm] string template)
        {
            return db.TemplateBuilder(template);
        }
        [HttpPost]
        public Boolean BuildKitFromTemplate([FromForm] KitTemplateModel model)
        {
                db.CreateKitFromTemplate(model);
                return true;
        }
        [HttpPost]
        public ProcessTemplate ProcessTemplateBuilder([FromForm] ProcessTemplate template)
        {
            return db.TemplateBuilder(template);
        }

    }
}
