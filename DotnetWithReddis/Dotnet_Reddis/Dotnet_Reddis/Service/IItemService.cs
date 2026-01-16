namespace Dotnet_Reddis.Service
{
    public interface IItemService
    {
        Task<Item> GetItemAsync(int itemId);
    }
}