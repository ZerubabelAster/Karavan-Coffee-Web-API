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
    public class OrderDetailController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OrderDetailController> _logger;
        private readonly IMapper _mapper;

        public OrderDetailController(IUnitOfWork unitOfWork, ILogger<OrderDetailController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            try
            {
                var orderDetails = await _unitOfWork.OrdersDetail.GetAll();
                var results = _mapper.Map<List<OrderDetailDTO>>(orderDetails);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetOrderDetails)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Lagter.");
            }
        }

        [HttpGet("{id:int}", Name = "GetOrderDetail")]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            try
            {
                var orderDetail = await _unitOfWork.OrdersDetail.Get(q => q.OrderDetailId == id);
                var result = _mapper.Map<OrderDetailDTO>(orderDetail);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetOrderDetail)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Lagter.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateOrderDetail([FromBody] CreateOrderDetailDTO orderDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateOrderDetail)}");
                return BadRequest(ModelState);
            }

            try
            {
                var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
                await _unitOfWork.OrdersDetail.Insert(orderDetail);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetOrderDetail", new { id = orderDetail.OrderDetailId }, orderDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateOrderDetail)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateOrderDetail(int id, [FromBody] UpdateOrderDetailDTO updateOrderDetailDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateOrderDetail)}");
                return BadRequest(ModelState);
            }

            try
            {
                var orderDetail = await _unitOfWork.OrdersDetail.Get(q => q.OrderDetailId == id);
                if (orderDetail == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateOrderDetail)}");
                    return BadRequest("submitted data is invalid");
                }

                _mapper.Map(updateOrderDetailDTO, orderDetail);
                _unitOfWork.OrdersDetail.Update(orderDetail);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateOrderDetail)}");
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attemp in {nameof(DeleteOrderDetail)}");
                return BadRequest();
            }

            try
            {
                var branch = await _unitOfWork.OrdersDetail.Get(q => q.OrderDetailId == id);
                if (branch == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteOrderDetail)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.OrdersDetail.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteOrderDetail)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }
    }
}
