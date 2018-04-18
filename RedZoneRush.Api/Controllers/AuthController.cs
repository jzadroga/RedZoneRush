using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedZoneRush.Logic.Interfaces;

namespace RedZoneRush.Api.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        /// <summary>Gets the Active Directory service.</summary>
        private IAuthService Service { get; }

        /// <summary>Initializes a new instance.</summary>
        public UserController(IAuthService service)
        {
            this.Service = service;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            this.Service.SendToken("ad");

            return new string[] { "value1", "value2" };
        }

        // POST api/values
        [HttpPost("validate")]
        public async Task<IActionResult> Validate([FromBody]string phoneNum)
        {
            /*using (var db = new UserContext())
            {
                var user = db.Users.First(u => u.PhoneNumber == phoneNum);

                if (user != null)
                {
                    Session["PhoneNumber"] = phone_num;
                    Session["Token"] = user.SendToken();
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }*/

            /*return this.BadRequest(new
            {
                Error = new Error
                {
                    Code = nameof(this.ModelState),
                    Message = (this.ModelState.Values.FirstOrDefault()?.Errors?.FirstOrDefault()?.ErrorMessage?.NullIfWhitespace() ?? "Model state is invalid."),
                }
            });*/

            return this.Ok();
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Auth(string token)
        {
           /* using (var db = new UserContext())
            {
                string number = Session["PhoneNumber"].ToString();

                var user = db.Users.First(u => u.PhoneNumber == number);

                if (user != null && token == Session["Token"].ToString())
                {
                    Session.Remove("Token");
                    Session.Remove("PhoneNumber");
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }*/

            return this.Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
