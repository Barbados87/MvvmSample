using System;

namespace MVVMExample.ViewModelBase
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataEventArgs<T> : EventArgs
    {
        /// <summary>
        ///
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        public DataEventArgs(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Gets or sets a value indicating whether event was cancelled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if canceled; otherwise, <c>false</c>.
        /// </value>
        public bool Cancel { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class DataEventArgs<T1, T2> : EventArgs
    {
        /// <summary>
        ///
        /// </summary>
        public T1 Data { get; set; }

        /// <summary>
        ///
        /// </summary>
        public T2 Data2 { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        /// <param name="data2"></param>
        public DataEventArgs(T1 data, T2 data2)
        {
            Data = data;
            Data2 = data2;
        }

        /// <summary>
        /// Gets or sets a value indicating whether event was cancelled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if canceled; otherwise, <c>false</c>.
        /// </value>
        public bool Cancel { get; set; }
    }
}