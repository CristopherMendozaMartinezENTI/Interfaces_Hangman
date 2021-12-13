using System.Threading.Tasks;
using Code.Model.Repositories;
using Code.Model.Repositories.User;

namespace Code.Model.Services.Database
{
    public interface DatabaseService
    {
        Task<bool> ExistKey(string key);
        Task Save<T>(T userDto, string key) where T : Dto;
        Task<T> Load<T>(string key);
    }
}