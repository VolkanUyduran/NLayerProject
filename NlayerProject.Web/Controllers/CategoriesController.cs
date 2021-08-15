﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NlayerProject.Core.Models;
using NlayerProject.Core.Services;
using NlayerProject.Web.ApiService;
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
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, CategoryApiService categoryApiService, IMapper mapper)
        {
            _categoryService = categoryService;
            _categoryApiService = categoryApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();
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
        public async Task<IActionResult> Update(int id)
        {
            var category=await _categoryService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));
        }
        [HttpPost]
        public IActionResult  Update(CategoryDto categoryDto) 
        {
            
            var transformDto = _mapper.Map<Category>(categoryDto);
            var UpdateDto = _categoryService.Update(transformDto);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);
            return RedirectToAction("Index");
        }
    }
}
