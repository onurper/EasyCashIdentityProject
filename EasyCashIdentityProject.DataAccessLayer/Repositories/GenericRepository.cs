using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete;

namespace EasyCashIdentityProject.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private Context _context { get; set; }

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetById(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _context.Set<T>().Add(t);
        }

        public void Update(T t)
        {
            _context.Update(t);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}