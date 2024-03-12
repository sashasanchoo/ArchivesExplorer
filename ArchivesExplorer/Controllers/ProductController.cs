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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, 
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("Category/{categoryName?}")]
        public async Task<ActionResult<IEnumerable<ShortProductResponse>>> GetAllProducts([FromRoute] string? categoryName = "")
        {
            var result = await _productService.GetAllProducts(categoryName);

            return Ok(_mapper.Map<IEnumerable<ShortProductResponse>>(result));
        }

        [AllowAnonymous]
        [HttpGet("Name/{productName?}")]
        public async Task<ActionResult<IEnumerable<ShortProductResponse>>> FindProductByName([FromRoute] string? productName)
        {
            var result = await _productService.GetProductByName(productName);

            return Ok(_mapper.Map<IEnumerable<ShortProductResponse>>(result));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseWithComments>> GetProduct([FromRoute] string id)
        {
            var productModel = await _productService.GetProductById(Guid.Parse(id));

            var result = _mapper.Map<ProductResponseWithComments>(productModel);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateProduct([FromForm] ProductUpdatingRequestWithImage request)
        {
            await _productService.UpdateProduct(_mapper.Map<ProductModel>(request.Product), 
                request.Product.CategoryName,
                request.DataFiles);

            return Ok();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> CreateProduct([FromForm] ProductCreateRequestWithImage request)
        {
            await _productService.CreateProduct(
                _mapper.Map<ProductModel>(request.Product), 
                request.Product.CategoryName,
                request.DataFiles);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] string id)
        {
            await _productService.DeleteProduct(Guid.Parse(id));

            return Ok();
        }
    }
}
