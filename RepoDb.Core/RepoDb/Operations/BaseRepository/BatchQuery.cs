﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepoDb
{
    /// <summary>
    /// A base object for all entity-based repositories.
    /// </summary>
    public abstract partial class BaseRepository<TEntity, TDbConnection> : IDisposable
    {
        #region BatchQuery<TEntity>

        /// <summary>
        /// Query the rows from the database by batch.
        /// </summary>
        /// <param name="page">The page of the batch to be used. This is a zero-based index (the first page is 0).</param>
        /// <param name="rowsPerBatch">The number of data per batch to be returned.</param>
        /// <param name="orderBy">The order definition of the fields to be used.</param>
        /// <param name="where">The dynamic expression to be used.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>An enumerable list of data entity objects.</returns>
        public IEnumerable<TEntity> BatchQuery(int page,
            int rowsPerBatch,
            IEnumerable<OrderField> orderBy,
            object where = null,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.BatchQuery<TEntity>(where: where,
                page: page,
                rowsPerBatch: rowsPerBatch,
                orderBy: orderBy,
                hints: hints,
                transaction: transaction);
        }

        /// <summary>
        /// Query the rows from the database by batch.
        /// </summary>
        /// <param name="page">The page of the batch to be used. This is a zero-based index (the first page is 0).</param>
        /// <param name="rowsPerBatch">The number of data per batch to be returned.</param>
        /// <param name="orderBy">The order definition of the fields to be used.</param>
        /// <param name="where">The query expression to be used.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>An enumerable list of data entity objects.</returns>
        public IEnumerable<TEntity> BatchQuery(int page, int rowsPerBatch,
            IEnumerable<OrderField> orderBy,
            Expression<Func<TEntity, bool>> where = null,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.BatchQuery<TEntity>(page: page,
                rowsPerBatch: rowsPerBatch,
                orderBy: orderBy,
                where: where,
                hints: hints,
                transaction: transaction);
        }

        /// <summary>
        /// Query the rows from the database by batch.
        /// </summary>
        /// <param name="page">The page of the batch to be used. This is a zero-based index (the first page is 0).</param>
        /// <param name="rowsPerBatch">The number of data per batch to be returned.</param>
        /// <param name="orderBy">The order definition of the fields to be used.</param>
        /// <param name="where">The query expression to be used.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>An enumerable list of data entity objects.</returns>
        public IEnumerable<TEntity> BatchQuery(int page,
            int rowsPerBatch,
            IEnumerable<OrderField> orderBy,
            QueryField where = null,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.BatchQuery<TEntity>(page: page,
                rowsPerBatch: rowsPerBatch,
                orderBy: orderBy,
                where: where,
                hints: hints,
                transaction: transaction);
        }

        /// <summary>
        /// Query the rows from the database by batch.
        /// </summary>
        /// <param name="page">The page of the batch to be used. This is a zero-based index (the first page is 0).</param>
        /// <param name="rowsPerBatch">The number of data per batch to be returned.</param>
        /// <param name="orderBy">The order definition of the fields to be used.</param>
        /// <param name="where">The query expression to be used.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>An enumerable list of data entity objects.</returns>
        public IEnumerable<TEntity> BatchQuery(int page,
            int rowsPerBatch,
            IEnumerable<OrderField> orderBy,
            IEnumerable<QueryField> where = null,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.BatchQuery<TEntity>(page: page,
                rowsPerBatch: rowsPerBatch,
                orderBy: orderBy,
                where: where,
                hints: hints,
                transaction: transaction);
        }

        /// <summary>
        /// Query the rows from the database by batch.
        /// </summary>
        /// <param name="page">The page of the batch to be used. This is a zero-based index (the first page is 0).</param>
        /// <param name="rowsPerBatch">The number of data per batch to be returned.</param>
        /// <param name="orderBy">The order definition of the fields to be used.</param>
        /// <param name="where">The query expression to be used.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>An enumerable list of data entity objects.</returns>
        public IEnumerable<TEntity> BatchQuery(int page,
            int rowsPerBatch,
            IEnumerable<OrderField> orderBy,
            QueryGroup where = null,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.BatchQuery<TEntity>(page: page,
                rowsPerBatch: rowsPerBatch,
                orderBy: orderBy,
                where: where,
                hints: hints,
                transaction: transaction);
        }

        #endregion

        #region BatchQueryAsync<TEntity>

        /// <summary>
        /// Query the rows from the database by batch in an asynchronous way.
        /// </summary>
        /// <param name="page">The page of the batch to be used. This is a zero-based index (the first page is 0).</param>
        /// <param name="rowsPerBatch">The number of data per batch to be returned.</param>
        /// <param name="orderBy">The order definition of the fields to be used.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>An enumerable list of data entity objects.</returns>
        public Task<IEnumerable<TEntity>> BatchQueryAsync(int page,
            int rowsPerBatch,
            IEnumerable<OrderField> orderBy,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.BatchQueryAsync<TEntity>(page: page,
                rowsPerBatch: rowsPerBatch,
                orderBy: orderBy,
                hints: hints,
                transaction: transaction);
        }

        /// <summary>
        /// Query the rows from the database by batch in an asynchronous way.
        /// </summary>
        /// <param name="page">The page of the batch to be used. This is a zero-based index (the first page is 0).</param>
        /// <param name="rowsPerBatch">The number of data per batch to be returned.</param>
        /// <param name="orderBy">The order definition of the fields to be used.</param>
        /// <param name="where">The dynamic expression to be used.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>An enumerable list of data entity objects.</returns>
        public Task<IEnumerable<TEntity>> BatchQueryAsync(int page,
            int rowsPerBatch,
            IEnumerable<OrderField> orderBy,
            object where = null,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.BatchQueryAsync<TEntity>(page: page,
                rowsPerBatch: rowsPerBatch,
                orderBy: orderBy,
                where: where,
                hints: hints,
                transaction: transaction);
        }

        /// <summary>
        /// Query the rows from the database by batch in an asynchronous way.
        /// </summary>
        /// <param name="page">The page of the batch to be used. This is a zero-based index (the first page is 0).</param>
        /// <param name="rowsPerBatch">The number of data per batch to be returned.</param>
        /// <param name="orderBy">The order definition of the fields to be used.</param>
        /// <param name="where">The query expression to be used.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>An enumerable list of data entity objects.</returns>
        public Task<IEnumerable<TEntity>> BatchQueryAsync(int page,
            int rowsPerBatch,
            IEnumerable<OrderField> orderBy,
            Expression<Func<TEntity, bool>> where = null,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.BatchQueryAsync<TEntity>(page: page,
                rowsPerBatch: rowsPerBatch,
                orderBy: orderBy,
                where: where,
                hints: hints,
                transaction: transaction);
        }

        /// <summary>
        /// Query the rows from the database by batch in an asynchronous way.
        /// </summary>
        /// <param name="page">The page of the batch to be used. This is a zero-based index (the first page is 0).</param>
        /// <param name="rowsPerBatch">The number of data per batch to be returned.</param>
        /// <param name="orderBy">The order definition of the fields to be used.</param>
        /// <param name="where">The query expression to be used.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>An enumerable list of data entity objects.</returns>
        public Task<IEnumerable<TEntity>> BatchQueryAsync(int page,
            int rowsPerBatch,
            IEnumerable<OrderField> orderBy,
            QueryField where = null,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.BatchQueryAsync<TEntity>(page: page,
                rowsPerBatch: rowsPerBatch,
                orderBy: orderBy,
                where: where,
                hints: hints,
                transaction: transaction);
        }

        /// <summary>
        /// Query the rows from the database by batch in an asynchronous way.
        /// </summary>
        /// <param name="page">The page of the batch to be used. This is a zero-based index (the first page is 0).</param>
        /// <param name="rowsPerBatch">The number of data per batch to be returned.</param>
        /// <param name="orderBy">The order definition of the fields to be used.</param>
        /// <param name="where">The query expression to be used.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>An enumerable list of data entity objects.</returns>
        public Task<IEnumerable<TEntity>> BatchQueryAsync(int page,
            int rowsPerBatch,
            IEnumerable<OrderField> orderBy,
            IEnumerable<QueryField> where = null,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.BatchQueryAsync<TEntity>(page: page,
                rowsPerBatch: rowsPerBatch,
                orderBy: orderBy,
                where: where,
                hints: hints,
                transaction: transaction);
        }

        /// <summary>
        /// Query the rows from the database by batch in an asynchronous way.
        /// </summary>
        /// <param name="page">The page of the batch to be used. This is a zero-based index (the first page is 0).</param>
        /// <param name="rowsPerBatch">The number of data per batch to be returned.</param>
        /// <param name="orderBy">The order definition of the fields to be used.</param>
        /// <param name="where">The query expression to be used.</param>
        /// <param name="hints">The table hints to be used.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>An enumerable list of data entity objects.</returns>
        public Task<IEnumerable<TEntity>> BatchQueryAsync(int page,
            int rowsPerBatch,
            IEnumerable<OrderField> orderBy,
            QueryGroup where = null,
            string hints = null,
            IDbTransaction transaction = null)
        {
            return DbRepository.BatchQueryAsync<TEntity>(page: page,
                rowsPerBatch: rowsPerBatch,
                orderBy: orderBy,
                where: where,
                hints: hints,
                transaction: transaction);
        }

        #endregion
    }
}
