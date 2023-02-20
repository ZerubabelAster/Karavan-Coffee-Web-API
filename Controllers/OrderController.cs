using AutoMapper;
using CoreApiResponse;
using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using KaravanCoffeeWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KaravanCoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWork unitOfWork, ILogger<OrderController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;

        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var orders = await _unitOfWork.Orders.GetAll();
                var results = _mapper.Map<List<OrderDTO>>(orders);
                return CustomResult("Order Loaded Succssfully", results, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetOrders)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetOrders)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = "Administrator, Customer")]
        [HttpGet("{id:int}", Name = "GetOrder")]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                var orders = await _unitOfWork.Orders.Get(q => q.OrderId == id);
                var result = _mapper.Map<OrderDTO>(orders);
                return CustomResult($"Order Loaded Succfully", result, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetOrder)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetOrder)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateOrder)}");
                return CustomResult($"Invalid Post Attempt {nameof(CreateOrder)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var order = _mapper.Map<Order>(orderDTO);
                await _unitOfWork.Orders.Insert(order);
                await _unitOfWork.Save();

                return CustomResult("Order Created Successfully", System.Net.HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateOrder)}");
                return CustomResult($"Something Went Wrong in the {nameof(CreateOrder)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = "Customer")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderDTO updateOrderDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateOrder)}");
                return CustomResult($"Invalid Update Attempt in {nameof(UpdateOrder)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var order = await _unitOfWork.Orders.Get(q => q.OrderId == id);
                if (order == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateOrder)}");
                    return CustomResult("Submitted data is invalid", System.Net.HttpStatusCode.BadRequest);
                }

                _mapper.Map(updateOrderDTO, order);
                _unitOfWork.Orders.Update(order);
                await _unitOfWork.Save();

                return CustomResult("Updated Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateOrder)}");
                return CustomResult($"Something Went Wrong in the {nameof(UpdateOrder)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attemp in {nameof(DeleteOrder)}");
                return CustomResult($"Invalid Delete attempt in {nameof(DeleteOrder)}");
            }

            try
            {
                var order = await _unitOfWork.Orders.Get(q => q.OrderId == id);
                if (order == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteOrder)}");
                    return CustomResult($"Invlaid Delete attempt in {nameof(DeleteOrder)}", System.Net.HttpStatusCode.BadRequest);
                }

                await _unitOfWork.Orders.Delete(id);
                await _unitOfWork.Save();

                return CustomResult("Deleted Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteOrder)}");
                return CustomResult("Internal Server Error. Please Try Again Later", System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
