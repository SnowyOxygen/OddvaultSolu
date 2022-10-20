namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Items;

public interface IItemService
{
    IEnumerable<Item> GetAll();
    Item GetById(int id);
    void Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}

public class ItemService : IItemService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public ItemService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Item> GetAll()
    {
        return _context.Items;
    }

    public Item GetById(int id)
    {
        return GetItem(id);
    }

    public void Create(CreateRequest model)
    {
        // map model to new user object
        var item = _mapper.Map<Item>(model);

        // save item
        _context.Items.Add(item);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
        var item = GetItem(id);

        // copy model to item and save
        _mapper.Map(model, item);
        _context.Items.Update(item);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var item = GetItem(id);
        _context.Items.Remove(item);
        _context.SaveChanges();
    }

    // helper methods

    private Item GetItem(int id)
    {
        var item = _context.Items.Find(id);
        if (item == null) throw new KeyNotFoundException("Account not found");
        return item;
    }
}
