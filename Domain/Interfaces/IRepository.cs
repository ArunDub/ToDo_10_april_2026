namespace Domain.Interfaces
{
    public interface IRepository<Tmodel> where Tmodel : class
    {
        Task<IEnumerable<Tmodel>> Get();
        Task<Tmodel> Get(int Id);
        void Create(Tmodel model);
        void Update(Tmodel model);
        void Delete(int Id);

        void CreateRange(IEnumerable<Tmodel> models);
        void UpdateRange(IEnumerable<Tmodel> models);
        void DeleteRange(IEnumerable<Tmodel> models); 

    }
}
