﻿using medEvolution.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace medEvolution.Controllers
{
    public class RolController : Controller
    {
		// GET: Rol
		ApplicationDbContext context = new ApplicationDbContext();
		public ActionResult Index()
        {
			if (User.Identity.IsAuthenticated)
			{


				if (!isAdminUser())
				{
					return RedirectToAction("Index", "Rol");
				}
			}
			else
			{
				return RedirectToAction("Index", "Rol");
			}

			var Roles = context.Roles.ToList();
			return View(Roles);
		}
		public Boolean isAdminUser()
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = User.Identity;
				
				var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
				var s = UserManager.GetRoles(user.GetUserId());
				if (s[0].ToString() =="Administrador" )
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}
	}

}