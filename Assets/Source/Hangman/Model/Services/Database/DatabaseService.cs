using System.Threading.Tasks;

public interface DatabaseService
{
    Task<bool> ExistKey(string key);
    Task Save<T>(T userDto, string key) where T : Dto;
    Task<T> Load<T>(string key);
}
