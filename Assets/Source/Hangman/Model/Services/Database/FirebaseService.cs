using System.Threading.Tasks;
using Code.Model.Repositories;

namespace Code.Model.Services.Database
{
    public class FirebaseService : DatabaseService
    {
        public Task<bool> ExistKey(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task Save<T>(T userDto, string key) where T : Dto
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Load<T>(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}