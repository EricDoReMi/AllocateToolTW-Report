using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AllocateTool.AllocateToolException
{
    /// <summary>
    /// ThreadMain中SaveMailItemToDisk方法引起的异常
    /// </summary>
    [Serializable]
    public partial class AllocateToolSaveFileToDiskException : ApplicationException
    {
        public AllocateToolSaveFileToDiskException() { }

        public AllocateToolSaveFileToDiskException(string message) : base(message)
        {

        }

        public AllocateToolSaveFileToDiskException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
