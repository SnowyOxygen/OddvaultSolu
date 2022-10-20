namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Accounts;

public interface IAccountService
{
    IEnumerable<Account> GetAll();
    Account GetById(int id);
    void Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}

public class AccountService : IAccountService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public AccountService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Account> GetAll()
    {
        return _context.Accounts;
    }

    public Account GetById(int id)
    {
        return GetAccount(id);
    }

    public void Create(CreateRequest model)
    {
        // map model to new user object
        var account = _mapper.Map<Account>(model);

        // save account
        _context.Accounts.Add(account);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
        var account = GetAccount(id);

        // copy model to account and save
        _mapper.Map(model, account);
        _context.Accounts.Update(account);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var account = GetAccount(id);
        _context.Accounts.Remove(account);
        _context.SaveChanges();
    }

    // helper methods

    private Account GetAccount(int id)
    {
        var account = _context.Accounts.Find(id);
        if (account == null) throw new KeyNotFoundException("Account not found");
        return account;
    }
}