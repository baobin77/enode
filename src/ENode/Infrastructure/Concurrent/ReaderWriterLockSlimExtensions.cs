using System;
using System.Threading;

namespace ENode.Infrastructure.Concurrent
{
    /// <summary>
    /// 
    /// </summary>
    public static class ReaderWriterLockSlimExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="readerWriterLockSlim"></param>
        /// <param name="action"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AtomRead(this ReaderWriterLockSlim readerWriterLockSlim, Action action)
        {
            if (readerWriterLockSlim == null)
            {
                throw new ArgumentNullException("readerWriterLockSlim");
            }
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            readerWriterLockSlim.EnterReadLock();

            try
            {
                action();
            }
            finally
            {
                readerWriterLockSlim.ExitReadLock();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="readerWriterLockSlim"></param>
        /// <param name="function"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T AtomRead<T>(this ReaderWriterLockSlim readerWriterLockSlim, Func<T> function)
        {
            if (readerWriterLockSlim == null)
            {
                throw new ArgumentNullException("readerWriterLockSlim");
            }
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }

            readerWriterLockSlim.EnterReadLock();

            try
            {
                return function();
            }
            finally
            {
                readerWriterLockSlim.ExitReadLock();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="readerWriterLockSlim"></param>
        /// <param name="action"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AtomWrite(this ReaderWriterLockSlim readerWriterLockSlim, Action action)
        {
            if (readerWriterLockSlim == null)
            {
                throw new ArgumentNullException("readerWriterLockSlim");
            }
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            readerWriterLockSlim.EnterWriteLock();

            try
            {
                action();
            }
            finally
            {
                readerWriterLockSlim.ExitWriteLock();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="readerWriterLockSlim"></param>
        /// <param name="function"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T AtomWrite<T>(this ReaderWriterLockSlim readerWriterLockSlim, Func<T> function)
        {
            if (readerWriterLockSlim == null)
            {
                throw new ArgumentNullException("readerWriterLockSlim");
            }
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }

            readerWriterLockSlim.EnterWriteLock();

            try
            {
                return function();
            }
            finally
            {
                readerWriterLockSlim.ExitWriteLock();
            }
        }
    }
}