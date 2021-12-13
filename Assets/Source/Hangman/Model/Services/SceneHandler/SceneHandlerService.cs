using System.Threading.Tasks;

namespace Code.Model.Services.SceneHandler
{
    public interface SceneHandlerService
    {
        Task LoadScene(string scene);
    }
}