using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Logger
{
    public class DataLogger : IDataLogger
    {
        public void WriteLog(string message)
        {
            //Use File logging here or configure log4Net or NLog or Enterprise Library
            
        }

        public void WriteException(string message, Exception ex)
        {
            //Use File logging here or configure log4Net or NLog or Enterprise Library
        }
    }

    public interface IDataLogger
    {
        void WriteLog(string message);
        void WriteException(string message , Exception ex);
    }
}
