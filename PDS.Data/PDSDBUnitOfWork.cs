using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Data
{
    public class PDSDBUnitOfWork
    {
        private PDSDBContext _context;

        protected PDSDBContext Context
        {
            get { return _context ?? (_context = PDSDBContextFactory.Get()); }
        }

        public void SaveChanges()
        {
            //Context.Commit();
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

