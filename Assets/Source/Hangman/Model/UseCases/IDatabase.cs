using System.Threading.Tasks;
using System;

public interface IDatabase : IDisposable
{
    public Task SetUserdata(UserData userdata);
    public Task<UserData> GetUserdata(string userID);
}
