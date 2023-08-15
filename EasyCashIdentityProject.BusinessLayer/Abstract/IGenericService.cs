namespace EasyCashIdentityProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TInsert(T t);

        void TUpdate(T t);

        void TDelete(T t);

        T TGetById(int id);

        T TGetById(string id);

        List<T> TGetList();

        void TSaveChange();
    }
}