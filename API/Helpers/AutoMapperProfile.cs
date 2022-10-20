namespace WebApi.Helpers;

using AutoMapper;
using WebApi.Entities;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateRequest -> Account
        CreateMap <Models.Accounts.CreateRequest, Account>();

        // UpdateRequest -> Account
        CreateMap<Models.Accounts.UpdateRequest, Account>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));

        // CreateRequest -> Item
        CreateMap<Models.Items.CreateRequest, Item>();

        //UpdateRequest -> item
        CreateMap<Models.Items.UpdateRequest, Item>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
    }
}