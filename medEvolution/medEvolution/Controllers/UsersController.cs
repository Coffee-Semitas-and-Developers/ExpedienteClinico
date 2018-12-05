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
	[Authorize]
	public class UsersController : Controller
	{
		
		// GET: Users
		ApplicationDbContext context = new ApplicationDbContext();
		public ActionResult Index()
		{

			{
				if (User.Identity.IsAuthenticated)
				{
					var user = User.Identity;
					ViewBag.Name = user.Name;

					ViewBag.displayMenu = "No";

					if (isAdminUser())
					{
						ViewBag.displayMenu = "Yes";
					}
					return View();
				}
				else
				{
					ViewBag.Name = "Not Logged IN";
				}
				return View();
			}
		}
		public Boolean isAdminUser()
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = User.Identity;
				ApplicationDbContext context = new ApplicationDbContext();
				var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
				var s = UserManager.GetRoles(user.GetUserId());
				if (s[0].ToString() == "Administrador")
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