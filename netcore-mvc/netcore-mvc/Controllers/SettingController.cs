﻿using Common.DTO;
using Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;
        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        // GET: SettingController
        public async Task<ActionResult> Index()
        {
            return View(await _settingService.GetAll());
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
        public async Task<ActionResult> Create(SettingDto setting)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var created = await _settingService.Add(setting);
                }
                catch(CustomException e)
                {
                    ModelState.AddModelError(e.HttpCode.ToString(), e.CustomMessage);
                    return View(setting);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(setting);
        }

        // GET: SettingController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                return View(await _settingService.Get(id));
            }
            catch (CustomException e)
            {
                ModelState.AddModelError(e.HttpCode.ToString(), e.CustomMessage);
                return View();
            }
        }

        // POST: SettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SettingDto setting)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _settingService.Update(setting);
                }
                catch (CustomException e)
                {
                    ModelState.AddModelError(e.HttpCode.ToString(), e.CustomMessage);
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(setting);
        }

        // GET: SettingController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return View(await _settingService.Get(id));
            }
            catch (CustomException e)
            {
                ModelState.AddModelError(e.HttpCode.ToString(), e.CustomMessage);
                return View();
            }
        }

        // POST: SettingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, SettingDto setting)
        {
            try
            {
                await _settingService.Delete(id);
            }
            catch (CustomException e)
            {
                ModelState.AddModelError(e.HttpCode.ToString(), e.CustomMessage);
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
