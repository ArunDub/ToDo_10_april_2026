namespace Application.Intrerfaces
{
    public interface IService<Tmodel, TDto, TVm> where Tmodel : class
    {
        Task<List<TVm>> Get();
        Task<TDto> Get(int Id);
        Task<TDto> Create(TDto dto);
        Task<TDto> Update(TDto dto); 
        Task<int> Delete(int Id);
        Task<List<TDto>> CreateRange(List<TDto> dto);
        Task<List<TDto>> UpdateRange(List<TDto> dto);
        Task<int> DeleteRange(List<TDto> dto);
    }
}
