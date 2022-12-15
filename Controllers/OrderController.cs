using AutoMapper;
using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using KaravanCoffeeWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaravanCoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
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

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var orders = await _unitOfWork.Orders.GetAll();
                var results = _mapper.Map<List<OrderDTO>>(orders);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetOrders)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Lagter.");
            }
        }

        [HttpGet("{id:int}", Name = "GetOrder")]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                var orders = await _unitOfWork.Orders.Get(q => q.OrderId == id);
                var result = _mapper.Map<OrderDTO>(orders);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetOrder)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Lagter.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateOrder)}");
                return BadRequest(ModelState);
            }

            try
            {
                var order = _mapper.Map<Order>(orderDTO);
                await _unitOfWork.Orders.Insert(order);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetOrder", new { id = order.OrderId }, order);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateOrder)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderDTO updateOrderDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateOrder)}");
                return BadRequest(ModelState);
            }

            try
            {
                var order = await _unitOfWork.Orders.Get(q => q.OrderId == id);
                if (order == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateOrder)}");
                    return BadRequest("submitted data is invalid");
                }

                _mapper.Map(updateOrderDTO, order);
                _unitOfWork.Orders.Update(order);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateOrder)}");
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attemp in {nameof(DeleteOrder)}");
                return BadRequest();
            }

            try
            {
                var order = await _unitOfWork.Orders.Get(q => q.OrderId == id);
                if (order == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteOrder)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Orders.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteOrder)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }
    }
}
