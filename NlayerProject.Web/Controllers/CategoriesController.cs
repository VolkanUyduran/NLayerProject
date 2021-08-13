using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NlayerProject.Core.Models;
using NlayerProject.Core.Services;
using NlayerProject.Web.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NlayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            var transformDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return View(transformDto);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var transformDto = _mapper.Map<Category>(categoryDto);
            await _categoryService.AddAsync(transformDto);
            return RedirectToAction("Index");
        }
    }
}
