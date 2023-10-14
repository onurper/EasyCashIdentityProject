using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.EntityLayer.Concrete;

namespace EasyCashIdentityProject.BusinessLayer.Concrete
{
    public class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessDal _customerAccountProcessDal;

        public CustomerAccountProcessManager(ICustomerAccountProcessDal customerAccountProcessDal)
        {
            _customerAccountProcessDal = customerAccountProcessDal;
        }

        public void TDelete(CustomerAccountProcess t) => _customerAccountProcessDal.Delete(t);

        public void TInsert(CustomerAccountProcess t) => _customerAccountProcessDal.Insert(t);

        public void TSaveChange() => _customerAccountProcessDal.SaveChange();

        public void TUpdate(CustomerAccountProcess t) => _customerAccountProcessDal.Update(t);

        public CustomerAccountProcess TGetById(int id) => _customerAccountProcessDal.GetById(id);

        public CustomerAccountProcess TGetById(string id) => _customerAccountProcessDal.GetById(id);

        public List<CustomerAccountProcess> TGetList() => _customerAccountProcessDal.GetList();

        public List<CustomerAccountProcess> MyLastProcess(int id)
        {
            return _customerAccountProcessDal.MyLastProcess(id);
        }
    }
}