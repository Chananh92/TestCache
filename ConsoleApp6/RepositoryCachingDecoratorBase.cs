using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ConsoleApp6
{
	public class RepositoryCachingDecoratorBase<TEntity>
		where TEntity : class
	{
		private ICacheManager<object> Cache { get; }
		private TimeSpan? ExpirationTime { get; }
		private string EntityPrefix { get; }
		private IList<string> EntityKeyNames { get; }

		public RepositoryCachingDecoratorBase(ICacheManager<object> cache, TimeSpan? expirationTime)
		{
			Cache = cache;
			ExpirationTime = expirationTime;
			EntityPrefix = $"{typeof(TEntity)}:";
			var EntityKeyNames = typeof(TEntity).GetProperties().Where(prop => prop.IsDefined(typeof(KeyAttribute), false)).Select(x => x.Name).ToList();
		}

		public TReturn ExecuteQueryEntityWithCache<TReturn>(Func<TReturn> execQuery, params KeyValuePair<string, object>[] cachingParameters)
		{
			var cacheKey = cachingParameters.GetHashCode().ToString();

			var cachedResult = Cache.Get<TReturn>(cacheKey);
			if (cachedResult != null)
				return cachedResult;

			var result = execQuery();

			var regionBuilder = new StringBuilder(EntityPrefix);
			foreach (var entityKey in EntityKeyNames)
			{
				var propValue = typeof(TEntity).GetProperty(entityKey).GetValue(result, null);
				regionBuilder.Append($"{entityKey}{propValue}");
			}

			//Cache.Expire("", )

			return result;
		}

		public void FlushEntityFromCache(TEntity entity, IList<string> cacheKeys)
		{
			throw new NotImplementedException();
		}

		private string GenerateCachingKey(params KeyValuePair<string, object>[] cachingParameters)
		{
			var cachingBuider = new StringBuilder(EntityPrefix);

			foreach (var cachingParameter in cachingParameters)
			{
				cachingBuider.Append($"{cachingParameter.Key}_{cachingParameter.Value}");
			}

			return cachingBuider.ToString();
		}
	}
}