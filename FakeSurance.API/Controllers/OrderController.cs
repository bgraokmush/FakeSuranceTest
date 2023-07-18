using FakeSurance.API.Model.User;
using FakeSurance.Business.Abstract;
using FakeSurance.DataAccess.Abstract;
using FakeSurance.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace FakeSurance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/xml")] // for xml
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;
        private readonly IPdfService _PdfService;
        private readonly HttpClient _httpClient;

        public OrderController(IOrderService orderService, HttpClient httpClient, IPdfService pdfService)
        {
            _OrderService = orderService;
            _httpClient = httpClient;
            _PdfService = pdfService;

        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _OrderService.ListOrder();

            if (result is null)
            {
                return BadRequest("Order not found");
            }

            return Ok(result);
        }

        [HttpGet("print/{id}")]
        public ActionResult print(int id)
        {
            var result = _OrderService.GetOrder(id);

            if(result is null)
            {
                return BadRequest("Order not found");
            }

            byte[] pdfByte = _PdfService.GeneratePdfFromTable(result);
            string fileName = $"{result.Title}.pdf";
            Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");
            return File(pdfByte, "application/pdf");
        }

        [HttpGet("{id}")]
        public ActionResult GetByID(int id)
        {
            var result = _OrderService.GetOrder(id);

            if(result is null)
            {
                return BadRequest("Order not found");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromHeader]UserInfoModel userInfo, Order order)
        {
            if (await isValid(userInfo.Name, userInfo.Password))
            {
                _OrderService.AddOrder(order);
                return Ok("Order is added succesfuly!");
                
            }
            else
            {
                return BadRequest("invalid access");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromHeader]UserInfoModel userInfo, Order order)
        {
            if(!await isValid(userInfo.Name, userInfo.Password))
            {
                return BadRequest("invalid access");
            }

            if (_OrderService.GetOrder(order.Id) is not null)
            {
                _OrderService.UpdateOrder(order);
                return Ok("Order is updated succesfuly!");
            }

            return BadRequest("Order not found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromHeader]UserInfoModel userInfo, int id)
        {
            var result = _OrderService.GetOrder(id);

            if(result is null)
            {
                  return BadRequest("Order not found");
            }
            if(!await isValid(userInfo.Name, userInfo.Password))
            {
                return BadRequest("invalid access");
            }  
            
            _OrderService.DeleteOrder(id);
            return Ok("Order is deleted succesfuly!");
        }

        private async Task<bool> isValid(string name, string password)
        {
            var url = "https://localhost:7295/api/Users/GetByName/";
            HttpResponseMessage response = _httpClient.GetAsync(url + name).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                
                var user = XDocument.Parse(content);
                
                if(user.Element("User").Element("Password").Value == password &&
                   user.Element("User").Element("isAdmin").Value == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            
        }
    }
}
