using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Site.Dal;
using School_Site.Model;

namespace School_Site.Controllers
{

    [ApiController]
    [Route("api/admin")]   // מומלץ לחסום בגישה רק למנהלים
    public class AdminTextsController : Controller
    {
        private readonly AppDbContext _db;

        public AdminTextsController(AppDbContext db)
        {
            _db = db;
        }

        // GET /AdminTexts
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var texts = await _db.SiteTexts.ToListAsync();
            return View(texts);
        }

        // רשימת טקסטים לפי שפה


        [HttpPost("update-text")]
        public async Task<IActionResult> UpdateText(UpdateTextRequest req)
        {
            var record = await _db.SiteTexts
                .FirstOrDefaultAsync(x => x.Key == req.Key && x.Language == req.Language);

            if (record == null)
            {
                record = new SiteText
                {
                    Key = req.Key,
                    Language = req.Language,
                    Value = req.Value
                };
                _db.SiteTexts.Add(record);
            }
            else
            {
                record.Value = req.Value;
            }

            await _db.SaveChangesAsync();
            return Ok(new { success = true });
        }

    }

}
