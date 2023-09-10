using Task = APIPermission.Models.Task;

namespace APIPermission.Data.Repositories
{
    public interface INoSQL
    {
        void Add(Task task);

        void Update(string id, Task taskUpdated);

        IEnumerable<Task> Get();

        Task Get(string id);

        void Delete(string id);

    }
}
