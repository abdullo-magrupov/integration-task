using Synel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synel.DAL.Repositories
{
    public class LogRepository
    {
        private SynelDbContext db;

        public LogRepository()
        {
            db = new SynelDbContext();
        }

        public IQueryable<Log> GetAll()
        {
            return db.Logs;
        }
    }
}
