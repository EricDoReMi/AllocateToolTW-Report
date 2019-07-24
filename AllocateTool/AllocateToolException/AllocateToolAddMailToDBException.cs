using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AllocateTool.AllocateToolException
{
    /// <summary>
    /// ThreadMain中AddMailToDB方法引起的异常
    /// </summary>
    [Serializable]
    public partial class AllocateToolAddMailToDBException : ApplicationException
    {
        public AllocateToolAddMailToDBException() { }

        public AllocateToolAddMailToDBException(string message) : base(message)
        {

        }

        public AllocateToolAddMailToDBException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
