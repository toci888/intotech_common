using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Bll
{
    public abstract class ServiceBase
    {
        protected IErrorLogger ErrorLogger;

        protected ServiceBase(IErrorLogger errorLogger) 
        {
            ErrorLogger = errorLogger;
        }
    }
}
