using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AllocateTool.AllocateToolException
{
    /// <summary>
    /// ThreadMain中ForwardMailItem方法引起的异常
    /// </summary>
    [Serializable]
    public partial class AllocateToolForwardMailItemException:ApplicationException
    {
        public AllocateToolForwardMailItemException() { }

        public AllocateToolForwardMailItemException(string message) : base(message)
        {

        }

        public AllocateToolForwardMailItemException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
