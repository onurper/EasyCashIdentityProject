using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.EntityLayer.Concrete;

namespace EasyCashIdentityProject.BusinessLayer.Concrete
{
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _customerAccountDal;

        public CustomerAccountManager(ICustomerAccountDal customerAccountDal)
        {
            _customerAccountDal = customerAccountDal;
        }

        public void TDelete(CustomerAccount t) => _customerAccountDal.Delete(t);

        public void TInsert(CustomerAccount t) => _customerAccountDal.Insert(t);

        public void TSaveChange() => _customerAccountDal.SaveChange();

        public void TUpdate(CustomerAccount t) => _customerAccountDal.Update(t);

        public CustomerAccount TGetById(int id) => _customerAccountDal.GetById(id);

        public CustomerAccount TGetById(string id) => _customerAccountDal.GetById(id);

        public List<CustomerAccount> TGetList() => _customerAccountDal.GetList();
    }
}