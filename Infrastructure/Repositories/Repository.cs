using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<Tmodel> : IRepository<Tmodel> where Tmodel : class
    {
        protected readonly AppDbContext _appDbContext;  //isko protected is liye kiya ki derive class me bhi access hona hai(TodoGroupRepository)
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<List<Tmodel>> Get()
        {
           return _appDbContext.Set<Tmodel>().ToListAsync();
        }
        public Task<Tmodel> Get(int Id)
        {
            return _appDbContext.Set<Tmodel>().FindAsync(Id).AsTask();
        }
        public void Create(Tmodel model)
        {
            _appDbContext.Set<Tmodel>().AddAsync(model);
        }
        public void Update(Tmodel model)
        {
            _appDbContext.Set<Tmodel>().Update(model);
        }
        public void Delete(Tmodel model)
        {
            _appDbContext.Set<Tmodel>().Remove(model);
        }
        public void CreateRange(List<Tmodel> models)
        {
            _appDbContext.Set<Tmodel>().AddRange(models);
        }
        public void UpdateRange(List<Tmodel> models)
        {
            _appDbContext.Set<Tmodel>().UpdateRange(models);
        }
        public void DeleteRange(List<Tmodel> models)
        {
            _appDbContext.Set<Tmodel>().RemoveRange(models);
        }      
        
    }
}
