using EmpireForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmpireForm.Controllers
{
    //Controller for the API
    public class RegistrationController : ApiController
    {

        public RegistrationController()
        {
        }

        //Get registrants from DB
        public IEnumerable<tblRegistrant> Get()
        {
            using (empire_dbContext dbContext = new empire_dbContext())
            {
                return dbContext.tblRegistrants.ToList();
            }
        }

        //Post registrants to DB
        public IHttpActionResult Post(RegistrantViewModel registrant)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (empire_dbContext dbContext = new empire_dbContext())
            {
                dbContext.tblRegistrants.Add(new tblRegistrant()
                {
                    fname = registrant.Fname,
                    lname = registrant.Lname
                });

                dbContext.SaveChanges();
            }

            return Ok();
        }

    }
}

