namespace Domain.Interfaces
{
    public interface IRepository<Tmodel> where Tmodel : class
    {
        Task<List<Tmodel>> Get();
        Task<Tmodel> Get(int Id);
        void Create(Tmodel model);
        void Update(Tmodel model);
        void Delete(Tmodel model);         
        void CreateRange(List<Tmodel> models);
        void UpdateRange(List<Tmodel> models);
        void DeleteRange(List<Tmodel> models); 

    }
}
