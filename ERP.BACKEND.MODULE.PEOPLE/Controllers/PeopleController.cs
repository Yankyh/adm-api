﻿using ERP.BACKEND.MODULE.PEOPLE.APPLICATION.DTOs;
using ERP.BACKEND.MODULE.PEOPLE.APPLICATION.Interfaces;
using ERP.BACKEND.MODULE.PEOPLE.DOMAIN.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ERP.BACKEND.MODULE.PEOPLE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PeopleController : BaseController<People, PeopleDTO>
    {
        public PeopleController(IPeopleApplication app) : base(app)
        { }
    }
}
