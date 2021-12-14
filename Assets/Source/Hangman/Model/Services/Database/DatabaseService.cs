using System.Threading.Tasks;

public interface DatabaseService
{
    Task<bool> ExistKey(string collection, string document);
    Task Save<T>(T userDto, string collection, string document) where T : Dto;
    Task<T> Load<T>(string collection, string document);
}
