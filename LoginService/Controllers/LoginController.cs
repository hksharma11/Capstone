using LoginService.Command;
using LoginService.Models;
using LoginService.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IMediator mediator;

        public LoginController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<EcomLogin> GetLoginById(int loginId)
        {
            return await mediator.Send(new GetLoginByIdQuery { loginId=loginId});
        }


        [HttpPost]
        public async Task<EcomLogin> AddLogin(string password, string token, DateTime datetime, string loginRole)
        {
            return await mediator.Send(new AddLoginCommand {password=password,token=token, datetime=datetime,loginRole=loginRole });
        }
    }
}
