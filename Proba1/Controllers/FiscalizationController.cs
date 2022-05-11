using Cis;
using Set3_Fiskalizacija.Cis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Proba1.Controllers
{
    [Route("api/Fiskalizacija")]
    public class FiscalizationController : Controller
    {
        // GET: Fiscalization
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<String> JirGenerate(String invoice)
        {
            return await CreateFiscalBill.CreateBill(invoice);
        }
    }
}