using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
	public class Repository<TEntity> : IRepository<TEntity>
	{
		public void Delete(TEntity entityToDelete)
		{
			throw new NotImplementedException();
		}

		public void Delete(object id)
		{
			throw new NotImplementedException();
		}

		public TEntity Get(object id)
		{
			throw new NotImplementedException();
		}

		public IList<TEntity> Get(params KeyValuePair<string, object>[] parameters)
		{
			throw new NotImplementedException();
		}

		public void Insert(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public void Update(TEntity entity)
		{
			throw new NotImplementedException();
		}
	}
}
