using System;
using System.Collections.Generic;
using System.Text;

namespace infraestructure.data.database
{
    public class unit_of_work
    {
        private readonly repository_context _dataContext;

        public unit_of_work(repository_context dataContext)
        {
            _dataContext = dataContext;
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}
