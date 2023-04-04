﻿using Microsoft.EntityFrameworkCore;
using OzkaInsaatTask.Core.Repositoires;

namespace OzkaInsaatTask.Repository.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly AppDbContext _context;
		private readonly DbSet<T> _dbSet;

		public GenericRepository(AppDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public IQueryable<T> GetAll()
		{
			return _dbSet.AsNoTracking();

		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public void Remove(T entity)
		{
			_dbSet.Remove(entity);

		}

		public void Update(T entity)
		{
			_dbSet.Update(entity);
		}
	}
}