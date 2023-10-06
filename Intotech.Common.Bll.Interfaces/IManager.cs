using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Bll.Interfaces
{
    public interface IManager : IService
    {
        public void AcceptLanguageHeader(string header);
    }
}
