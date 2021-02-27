namespace Core.Interfaces
{
    public interface IImageServiceRepository
    {
        System.Threading.Tasks.Task<string> GetImagesByModelAsync(int id);
    }
}