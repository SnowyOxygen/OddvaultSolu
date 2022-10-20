namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Accounts;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class AccountsController : ControllerBase
{
    private IAccountService _accountService;
    private IMapper _mapper;

    public AccountsController(
        IAccountService accountService,
        IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var accounts = _accountService.GetAll();
        return Ok(accounts);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var account = _accountService.GetById(id);
        return Ok(account);
    }

    [HttpPost]
    public IActionResult Create(CreateRequest model)
    {
        _accountService.Create(model);
        return Ok(new { message = "Account created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _accountService.Update(id, model);
        return Ok(new { message = "Account updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _accountService.Delete(id);
        return Ok(new { message = "Account deleted" });
    }
}