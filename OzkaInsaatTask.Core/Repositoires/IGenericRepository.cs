namespace OzkaInsaatTask.Core.Repositoires
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> GetByIdAsync(int id);
		IQueryable<T> GetAll();
		Task AddAsync(T entity);
		void Update(T entity);
		void Remove(T entity);
	}
}
