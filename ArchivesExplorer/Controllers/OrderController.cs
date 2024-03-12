using ArchivesExplorer.Requests;
using ArchivesExplorer.Responses;
using ArchivexExplorer.Core.Interfaces.Services;
using ArchivexExplorer.Domain.Constants;
using ArchivexExplorer.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchivesExplorer.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserConstants.SuperUserRole)]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderRequest request)
        {
            await _orderService.CreateOrder(_mapper.Map<OrderModel>(request));

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetAllOrders()
        {
            var result = await _orderService.GetAllOrders();

            return Ok(_mapper.Map<IEnumerable<OrderResponse>>(result));
        }
    }
}
