﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            this._context = context;
        }


        public IActionResult Index()
        {
            var tweets = _context.Tweets.ToList();

            foreach (var t in tweets)
            {
                t.User = _context.Users.ToList().Find(u => u.userId == t.UserId);
            }
            ViewData["Tweets"] = tweets;

            return View();
        }

        public IActionResult Details(int Id)
        {
            ViewData["Tweet"] = _context.Tweets.ToList().Find(t => t.TweetId == Id);
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind("TweetId", "TweetContent", "TweetDate", "UserId")] TweetModel tweet)
        {
            if (ModelState.IsValid) //check the state of model
            {
                tweet.User = _context.Users.ToList().Find(u => u.userId == tweet.UserId);
                if (tweet.User != null)
                {
                    _context.Tweets.Add(tweet);
                    _context.SaveChanges();
                    return RedirectToAction("Index");

                }

            }

            return NotFound();
            //return View(product);
        }
    }
}
