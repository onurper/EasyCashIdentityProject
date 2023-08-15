namespace EasyCashIdentityProject.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T t);

        void Update(T t);

        void Delete(T t);

        T GetById(int id);

        T GetById(string id);

        List<T> GetList();

        void SaveChange();
    }
}