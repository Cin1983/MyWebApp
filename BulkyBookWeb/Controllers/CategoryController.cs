﻿using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList = _db.Categories;

        return View(objCategoryList);
    }

    //GET Method
    public IActionResult Create()
    {

        return View();
    }
    //POST Method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder can't exactly match the name.");
        }

        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }




    //GET Method
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

        if(categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }
    
    
    //POST Method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder can't exactly match the name.");
        }

        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category edited successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }



    //GET Method
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }


    //POST Method
    [HttpPost, ActionName("DeletePOST")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _db.Categories.Find(id);
        if (obj == null)
        {
            return NotFound();
        }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
    }
   
}
