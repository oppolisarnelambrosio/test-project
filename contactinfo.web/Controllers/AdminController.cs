using AutoMapper;
using contactinfo.web.Data;
using contactinfo.web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contactinfo.web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AdminController(
            ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<IActionResult> Index()
        {
            var contacts = await _context.Contacts.ToListAsync();
            var contactModel = _mapper.Map<List<ContactViewModel>>(contacts);    

            return View(contactModel);
        }
    }
}
