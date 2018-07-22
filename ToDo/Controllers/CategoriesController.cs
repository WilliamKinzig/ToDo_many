using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using System.Collections.Generic;
using System;

namespace ToDo.Controllers
{
  public class CategoriesController : Controller
  {
    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategories);
    }
    [HttpGet("/categories/new")]
    public ActionResult CreateForm()
    {
      return View();
    }
    [HttpPost("/categories")]
    public ActionResult Create()
    {
      Category newCategory = new Category(Request.Form["category-name"]);
      newCategory.Save();
      return RedirectToAction("Success", "Home");
    }
    [HttpGet("/categories/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
      Category thisCategory = Category.Find(id);
      return View(thisCategory);
    }
    [HttpPost("/categories/{id}/update")]
    public ActionResult Update(int id)
    {
      Category thisCategory = Category.Find(id);
      thisCategory.Edit(Request.Form["newname"]);
      return RedirectToAction("Index");
    }
    [HttpGet("/categories/{id}")]
    public ActionResult Details(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(id);
      List<Item> categoryItems = selectedCategory.GetItems();
      List<Item> allItems = Item.GetAll();
      model.Add("selectedCategory", selectedCategory);
      model.Add("categoryItems", categoryItems);
      model.Add("allItems", allItems);
      return View(model);
    }
    [HttpPost("/categories/{categoryId}/items/new")]
    public ActionResult AddItem(int categoryId)
    {
        Category category = Category.Find(categoryId);
        Item item = Item.Find(Int32.Parse(Request.Form["item-id"]));
        category.AddItem(item);
        return RedirectToAction("Details",  new { id = categoryId });
    }
  }
}
