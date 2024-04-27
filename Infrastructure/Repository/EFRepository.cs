using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EFRepository<T> : IRepository<T> where T : EntityBase
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Alterar(T entidade)
        {
            _context.Set<T>().Update(entidade);
            _context.SaveChanges();
        }

        public void Cadastrar(T entidade)
        {
            entidade.DataCriacao = DateTime.Now;
            _context.Set<T>().Add(entidade);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            _context.Set<T>().Remove(ObterPorId(id));
            _context.SaveChanges();
        }

        public T ObterPorId(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public IList<T> ObterTodos()
        {
            return _context.Set<T>().ToList();
        }
    }

}
