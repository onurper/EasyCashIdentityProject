using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete;
using EasyCashIdentityProject.DataAccessLayer.Repositories;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
namespace EasyCashIdentityProject.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
    {
        private readonly Context db;
        public EfCustomerAccountProcessDal(Context db) : base(db)
        {
            this.db = db;
        }

        public List<CustomerAccountProcess> MyLastProcess(int id)
        {
            List<CustomerAccountProcess> values = db.CustomerAccountProcesses.Include(x=>x.SenderCustomer).Where(x => x.ReceiverId == id || x.SenderId == id).ToList();

            return values;
        }
    }
}