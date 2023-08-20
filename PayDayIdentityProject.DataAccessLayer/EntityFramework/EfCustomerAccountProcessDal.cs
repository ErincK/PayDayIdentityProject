using PayDayIdentityProject.DataAccessLayer.Abstract;
using PayDayIdentityProject.DataAccessLayer.Repositories;
using PayDayIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayDayIdentityProject.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDal:GenericRepository<CustomerAccountProcess>,ICustomerAccountProcessDal
    {
    }
}
