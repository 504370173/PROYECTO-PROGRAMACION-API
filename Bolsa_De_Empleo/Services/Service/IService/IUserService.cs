using DataAccess.Entities;

namespace Services.Service.IService
{
    public interface IUserService
    {
        public Task<List<User>> GetAll();
        public Task<User> Create(User user);
    }
}
