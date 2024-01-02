namespace MarketPlace.Domain.WorkOut
{
    public interface IWorkOutRepository
    {
        Task<WorkOut> Get();
        Task<WorkOut> Update(WorkOut workOut);
        Task<WorkOut> Delete(WorkOut workOut);
        Task<WorkOut> Create(WorkOut workOut);
        Task<IEnumerable<WorkOut>> GetAll();
    }
}
