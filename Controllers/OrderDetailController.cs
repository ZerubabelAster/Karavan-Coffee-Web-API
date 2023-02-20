using AutoMapper;
using CoreApiResponse;
using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using KaravanCoffeeWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaravanCoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : BaseController
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

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            try
            {
                var orderDetails = await _unitOfWork.OrdersDetail.GetAll();
                var results = _mapper.Map<List<OrderDetailDTO>>(orderDetails);
                return CustomResult("Order Details Loaded Succssfully", results, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetOrderDetails)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetOrderDetails)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = "Administrator, Cutomer")]
        [HttpGet("{id:int}", Name = "GetOrderDetail")]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            try
            {
                var orderDetail = await _unitOfWork.OrdersDetail.Get(q => q.OrderDetailId == id);
                var result = _mapper.Map<OrderDetailDTO>(orderDetail);
                return CustomResult("Order Details Loaded Succssfully", result, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetOrderDetail)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetOrderDetail)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateOrderDetail([FromBody] CreateOrderDetailDTO orderDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateOrderDetail)}");
                return CustomResult($"Invalid Post Attempt {nameof(CreateOrderDetail)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
                await _unitOfWork.OrdersDetail.Insert(orderDetail);
                await _unitOfWork.Save();

                return CustomResult("Order Details Created Successfully", System.Net.HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateOrderDetail)}");
                return CustomResult($"Something Went Wrong in the {nameof(CreateOrderDetail)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = "Administrator, Customer")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateOrderDetail(int id, [FromBody] UpdateOrderDetailDTO updateOrderDetailDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateOrderDetail)}");
                return CustomResult($"Invalid Update Attempt in {nameof(UpdateOrderDetail)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var orderDetail = await _unitOfWork.OrdersDetail.Get(q => q.OrderDetailId == id);
                if (orderDetail == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateOrderDetail)}");
                    return CustomResult("Submitted data is invalid", System.Net.HttpStatusCode.BadRequest);
                }

                _mapper.Map(updateOrderDetailDTO, orderDetail);
                _unitOfWork.OrdersDetail.Update(orderDetail);
                await _unitOfWork.Save();

                return CustomResult("Updated Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateOrderDetail)}");
                return CustomResult($"Something Went Wrong in the {nameof(UpdateOrderDetail)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attemp in {nameof(DeleteOrderDetail)}");
                return CustomResult($"Invalid Update Attempt in {nameof(DeleteOrderDetail)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var branch = await _unitOfWork.OrdersDetail.Get(q => q.OrderDetailId == id);
                if (branch == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteOrderDetail)}");
                    return CustomResult($"Invlaid Delete attempt in {nameof(DeleteOrderDetail)}", System.Net.HttpStatusCode.BadRequest);
                }

                await _unitOfWork.OrdersDetail.Delete(id);
                await _unitOfWork.Save();

                return CustomResult("Deleted Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteOrderDetail)}");
                return CustomResult("Internal Server Error. Please Try Again Later", System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
