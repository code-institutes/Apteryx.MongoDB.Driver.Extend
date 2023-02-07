using System;
using System.Linq.Expressions;
using System.Threading;
using MongoDB.Driver;

namespace Apteryx.MongoDB.Driver.Extend
{
    public abstract partial class MongoDbProvider
    {
        #region 替换(同步)

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public ReplaceOneResult WhereReplaceOne<T>(
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>(typeof(T).Name).ReplaceOne(r=>r.Id == id, document, options, cancellationToken);
        }
        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public ReplaceOneResult WhereReplaceOne<T>(
            IClientSessionHandle session,
            string id,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>(typeof(T).Name).ReplaceOne(session, r => r.Id == id, document, options, cancellationToken);
        }
        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public ReplaceOneResult WhereReplaceOne<T>(
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>(typeof(T).Name).ReplaceOne(filter, document, options, cancellationToken);
        }
        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public ReplaceOneResult WhereReplaceOne<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default) where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>(typeof(T).Name).ReplaceOne(session, filter, document, options, cancellationToken);
        }
        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public ReplaceOneResult WhereReplaceOne<T>(
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>(typeof(T).Name).ReplaceOne(filter, document, options, cancellationToken);
        }

        /// <summary>
        /// 替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public ReplaceOneResult WhereReplaceOne<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>(typeof(T).Name).ReplaceOne(session, filter, document, options, cancellationToken);
        }
        /// <summary>
        /// 动态表替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public ReplaceOneResult DynamicCollectionWhereReplaceOne<TForeign, T>(
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}")
                .ReplaceOne(filter, document, options, cancellationToken);
        }
        /// <summary>
        /// 动态表替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public ReplaceOneResult DynamicCollectionWhereReplaceOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            FilterDefinition<T> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}")
                .ReplaceOne(session, filter, document, options, cancellationToken);
        }
        /// <summary>
        /// 动态表替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public ReplaceOneResult DynamicCollectionWhereReplaceOne<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}")
                .ReplaceOne(filter, document, options, cancellationToken);
        }
        /// <summary>
        /// 动态表替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public ReplaceOneResult DynamicCollectionWhereReplaceOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter,
            T document,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}")
                .ReplaceOne(session, filter, document, options, cancellationToken);
        }
        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndReplaceOne<T>(
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>(typeof(T).Name).FindOneAndReplace<T>(r=>r.Id == id, document, options, cancellationToken);
        }
        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndReplaceOne<T>(
            IClientSessionHandle session,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>(typeof(T).Name).FindOneAndReplace<T>(session, r=>r.Id == id, document, options, cancellationToken);
        }
        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndReplaceOne<T>(
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>(typeof(T).Name).FindOneAndReplace(filter, document, options, cancellationToken);
        }
        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndReplaceOne<T>(
            IClientSessionHandle session,
            FilterDefinition<T> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>(typeof(T).Name).FindOneAndReplace(session, filter, document, options, cancellationToken);
        }
        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndReplaceOne<T>(
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>(typeof(T).Name).FindOneAndReplace(filter, document, options, cancellationToken);
        }
        /// <summary>
        /// 查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T FindOneAndReplaceOne<T>(
            IClientSessionHandle session,
            Expression<Func<T, bool>> filter,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>(typeof(T).Name).FindOneAndReplace(session, filter, document, options, cancellationToken);
        }
        /// <summary>
        /// 动态表查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndReplaceOne<TForeign, T>(
            TForeign foreignDocument, 
            string id,
            T document, FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndReplace<T>(r=>r.Id == id, document, options, cancellationToken);
        }
        /// <summary>
        /// 动态表查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="id">文档默认ID</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndReplaceOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            string id,
            T document,
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndReplace<T>(session, r=>r.Id == id, document, options, cancellationToken);
        }
        /// <summary>
        /// 动态表查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndReplaceOne<TForeign, T>(TForeign foreignDocument, FilterDefinition<T> filter,
            T document, FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndReplace(filter, document, options, cancellationToken);
        }
        /// <summary>
        /// 动态表查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndReplaceOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument, 
            FilterDefinition<T> filter,
            T document, 
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndReplace(session,filter, document, options, cancellationToken);
        }
        /// <summary>
        /// 动态表查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndReplaceOne<TForeign, T>(
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter, 
            T document, 
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndReplace(filter, document, options, cancellationToken);
        }
        /// <summary>
        /// 动态表查询替换单条(自动更新UpdateTime字段)
        /// </summary>
        /// <typeparam name="TForeign">文档类型</typeparam>
        /// <typeparam name="T">文档类型</typeparam>
        /// <param name="session">会话句柄(作用于事务)</param>
        /// <param name="foreignDocument">上级文档对象</param>
        /// <param name="filter">Lambda过滤器</param>
        /// <param name="document">文档对象</param>
        /// <param name="options">查询替换操作设置</param>
        /// <param name="cancellationToken">取消操作设置</param>
        /// <returns></returns>
        public T DynamicCollectionFindOneAndReplaceOne<TForeign, T>(
            IClientSessionHandle session,
            TForeign foreignDocument,
            Expression<Func<T, bool>> filter, 
            T document, 
            FindOneAndReplaceOptions<T> options = null,
            CancellationToken cancellationToken = default)
            where TForeign : BaseMongoEntity
            where T : BaseMongoEntity
        {
            document.UpdateTime = DateTime.Now;
            return Database.GetCollection<T>($"{typeof(T).Name}_{foreignDocument.Id}").FindOneAndReplace(session,filter, document, options, cancellationToken);
        }

        #endregion
    }
}
