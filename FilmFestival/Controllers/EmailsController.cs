using FilmFestival.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FilmFestival.Controllers
{
    public class EmailsController : ApiController
    {
        EmailServices emailServices = new EmailServices();

        [HttpGet]
        public IHttpActionResult SendAccountEmail()
        {
            emailServices.SendAccountEmail();
            return Ok("yes");
        }
    }
}
