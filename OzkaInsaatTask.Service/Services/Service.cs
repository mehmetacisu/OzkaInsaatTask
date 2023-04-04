using Microsoft.EntityFrameworkCore;
using OzkaInsaatTask.Core.Repositoires;
using OzkaInsaatTask.Core.Services;
using OzkaInsaatTask.Repository;

namespace OzkaInsaatTask.Service.Services
{
	public class Service<T> : IService<T> where T : class
	{
		private readonly IGenericRepository<T> _repository;
		private readonly AppDbContext _context;

		public Service(IGenericRepository<T> repository,AppDbContext context)
		{
			_context = context;
			_repository = repository;
		}

		public async Task<T> AddAsync(T entity)
		{
			await _repository.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _repository.GetAll().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);

		}

		public async Task RemoveAsync(T entity)
		{
			_repository.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			_repository.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
