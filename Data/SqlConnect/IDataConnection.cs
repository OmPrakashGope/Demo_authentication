using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlConnect
{
    public interface IDataConnection
    {
        Task<dynamic> GetData(string proc, Object parameters);
        Task<dynamic> InsertData<T>(string proc, Object parameters);
    }
}
