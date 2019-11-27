using System;
using System.Collections.Generic;
using System.Text;

namespace infraestructure.interfaces
{
    public interface Iunit_of_work
    {
        void Commit();
        void Rollback();
    }
}
