using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
	public interface IRepository<TEntity>
	{
		TEntity Get(object id);
		IList<TEntity> Get(params KeyValuePair<string, object>[] parameters);
		void Delete(TEntity entityToDelete);
		void Delete(object id);
		void Insert(TEntity entity);
		void Update(TEntity entity);
	}
}