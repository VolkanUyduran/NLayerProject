using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NlayerProject.API.Dtos;
using NlayerProject.API.Filters;
using NlayerProject.Core.Models;
using NlayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NlayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products =await _productService.GetAllAsync();
            var transformDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(transformDto);
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productId = await _productService.GetByIdAsync(id);
            var transformDto = _mapper.Map<ProductDto>(productId);
            return Ok(transformDto);
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithByCategoryId(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(product));

        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var transformDto = _mapper.Map<Product>(productDto);
            var newProduct = await _productService.AddAsync(transformDto);
            return Created(string.Empty,_mapper.Map<ProductDto>(newProduct));
        }
        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            //if (string.IsNullOrEmpty(productDto.Id.ToString()) || productDto.Id<=0)
            //{
            //    throw new Exception("Id Alanı gereklidir");
            //}
            //Yukarıdaki kod bloğu update işleminde Id kontrolü sağlıyor.yani eğer id verilmezse id alanı gereklidir kontrolü.
            var transformDto = _mapper.Map<Product>(productDto);
            var updateCategory =  _productService.Update(transformDto);
            return NoContent();
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var deletedProduct = _productService.GetByIdAsync(id).Result;
            _productService.Remove(deletedProduct);
            return NoContent();
        }
    }
}
