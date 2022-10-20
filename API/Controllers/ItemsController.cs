namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Items;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private IItemService _itemService;
    private IMapper _mapper;

    public ItemsController(
        IItemService itemService,
        IMapper mapper)
    {
        _itemService = itemService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var items = _itemService.GetAll();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var item = _itemService.GetById(id);
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Create(CreateRequest model)
    {
        _itemService.Create(model);
        return Ok(new { message = "Item created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _itemService.Update(id, model);
        return Ok(new { message = "Item updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _itemService.Delete(id);
        return Ok(new { message = "Item deleted" });
    }
}