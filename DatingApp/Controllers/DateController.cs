using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dating.BusinessLayer.Interface;
using DatingApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{
    [Route("api/date")]
    [ApiController]
    public class DateController : ControllerBase
    {
        private readonly IDateService _dateService;

        /// <summary>
        /// Inject Date service object
        /// </summary>
        /// <param name="userService"></param>

        public DateController(IDateService dateService)
        {
            _dateService = dateService;
        }

        /// <summary>
        /// post api to send request user by calling Date service method
        /// Post api/invitation
        /// </summary>
        /// <param name="dateDetails"></param>
        /// <returns></returns>
        [Route("invitation")]
        [HttpPost]
        public async Task<ActionResult<string>> SendInvitation(DateDetails dateDetails)
        {
            //business logic goes here
            try
            {
                var result = await _dateService.SendRequest(dateDetails);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

    }
}
