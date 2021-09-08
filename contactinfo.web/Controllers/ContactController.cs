using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using contactinfo.web.Data;
using contactinfo.web.Data.Entities;
using contactinfo.web.Models;
using AutoMapper;

namespace contactinfo.web.Controllers
{
    public class ContactController : Controller
    {
        //To Do: Apply repository and unit of work pattern
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ContactController(
            ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Address,State,Country,ZipCode,PhoneNumber,Notes")] ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newContact = _mapper.Map<Contact>(model);
                _context.Add(newContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SubmitSuccess));
            }
            return View(model);
        }

        public IActionResult SubmitSuccess()
        {
            return View();
        }

    }
}
