using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using System.Threading.Tasks;

namespace netcore_mvc.Controllers
{
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;
        private readonly ILogger<SettingController> _logger;
        public SettingController(ISettingService settingService, ILogger<SettingController> logger)
        {
            _settingService = settingService;
            _logger = logger;
        }
        // GET: SettingController
        public async Task<ActionResult> Index()
        {
            var settings = await _settingService.GetAll();
            ViewBag.Settings = settings;
            return View();
        }

        // GET: SettingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SettingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SettingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SettingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
