using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intotech.Common.Bll.Interfaces;

namespace Intotech.Common.Bll
{
    public abstract class ServiceBase : IService
    {
        protected IErrorLogger ErrorLogger;

        protected ServiceBase(IErrorLogger errorLogger) 
        {
            ErrorLogger = errorLogger;
        }
    }
}
