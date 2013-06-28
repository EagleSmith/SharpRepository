﻿using System;
using SharpRepository.Repository;
using SharpRepository.Repository.Aspects;
using NLog;

namespace SharpRepository.Logging.NLog
{
    public class NLogRepositoryLogger<T, TKey> : RepositoryAspect<T, TKey> where T : class
    {
        private readonly Logger _logger;

        public NLogRepositoryLogger()
        {
            _logger = LogManager.GetLogger("SharpRepository");
        }

        public override void OnInitialize(IRepository<T, TKey> repository)
        {
            _logger.Debug(String.Format("Initialized IRepository<{0}, {1}>", typeof(T).Name, typeof(TKey).Name));
        }

        public override bool OnAddExecuting(T entity)
        {
            _logger.Debug(String.Format("Adding {0} entity", typeof(T).Name));
            return true;
        }

        public override void OnAddExecuted(T entity)
        {
            _logger.Debug(String.Format("Added {0} entity", typeof(T).Name));
        }

        public override bool OnUpdateExecuting(T entity)
        {
            _logger.Debug(String.Format("Updating {0} entity", typeof(T).Name));

            return true;
        }

        public override void OnUpdateExecuted(T entity)
        {
            _logger.Debug(String.Format("Updated {0} entity", typeof(T).Name));
        }

        public override bool OnDeleteExecuting(T entity)
        {
            _logger.Debug(String.Format("Deleting {0} entity", typeof(T).Name));

            return true;
        }

        public override void OnDeleteExecuted(T entity)
        {
            _logger.Debug(String.Format("Deleted {0} entity", typeof(T).Name));
        }

        public override bool OnSaveExecuting()
        {
            _logger.Debug(String.Format("Saving {0} entity", typeof(T).Name));

            return true;
        }

        public override void OnSaveExecuted()
        {
            _logger.Debug(String.Format("Saved {0} entity", typeof(T).Name));
        }
    }
}