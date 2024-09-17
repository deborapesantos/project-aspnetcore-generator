using Asp.Versioning;
using TemplateHexagonal.Ports.API.Presenters.Interfaces;
using TemplateHexagonal.Ports.API.Validation;
using TemplateHexagonal.Ports.API.ViewModels.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TemplateHexagonal.Ports.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiExplorerSettings(GroupName = "V1")]
    public class BiddingController : ControllerBase
    {
        private readonly IBiddingPresenter _biddingPresenter;

        public BiddingController(IBiddingPresenter biddingPresenter)
        {
            _biddingPresenter = biddingPresenter;
        }

        [HttpGet]
        [Route("biddings")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllRequestViewModel param)
        {
            return Ok(_biddingPresenter.GetAll(param));
        }
    }
}
