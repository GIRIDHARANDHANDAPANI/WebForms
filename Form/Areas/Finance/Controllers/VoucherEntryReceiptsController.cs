using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Form.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Form.Areas.Finance.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VoucherEntryReceiptsController : Controller
    {
        private ERPMasterWtDataContext _context;

        public VoucherEntryReceiptsController(ERPMasterWtDataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetReceivingAccount(DataSourceLoadOptions loadOptions)
        {
            var tbl20101salespersonmasters = _context.Qry201ReceivingAccounts.Select(i => new
            {
                
                i.AccountId,
                i.AccountHead,
                i.AccountHeadArabic,
                i.IsLedgerObselete

            });


            return Json(await DataSourceLoader.LoadAsync(tbl20101salespersonmasters, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetAccountHead(DataSourceLoadOptions loadOptions)
        {
            var tbl20101salespersonmasters = _context.Qry201ListOfAccounts.Select(i => new
            {
                i.MasterGroupId,
                i.MasterGroup,
                i.AccountGroup,
                i.AccountGroupId,
                i.AccountId,
                i.AccountHead,
                i.AccountHeadArabic,
                i.ReferenceNo,
                i.IsLedgerObselete
            });


            return Json(await DataSourceLoader.LoadAsync(tbl20101salespersonmasters, loadOptions));
        }
    }
}
