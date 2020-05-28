﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EDUProjects.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Authorization;
using EDUProjects.Models;

namespace EDUProjects.Controllers
{
    public class UsersController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                //if (result.Succeeded)
               // {
                   // return RedirectToAction("index", "home");
                //}

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            

            return View(model);
        }
    }
}
