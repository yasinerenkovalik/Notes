using Notes.Application.Repository;
using Notes.Domail;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Notes.Persistence.Repository
{
    public class NoteService : INoteRepository
    {
        private readonly Context _context;
        public NoteService(Context context)
        {
            _context = context;
        }
        public void Add(Note note)
        {
            var addedEntity = _context.Entry(note);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
            addedEntity.State = EntityState.Detached;
        }

        public void Deleted(Note note)
        {
            var addedEntity = _context.Entry(note);
            addedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
            addedEntity.State = EntityState.Detached;
        }

        public Note Get(Expression<Func<Note, bool>> filter)
        {
            return _context.Set<Note>().FirstOrDefault(filter);
        }

        public List<Note> GetAll(Expression<Func<Note, bool>>? filter = null)
        {
            return filter == null ? _context.Set<Note>().ToList() :
                _context.Set<Note>().Where(filter).ToList();
        }

        public void Update(Note note)
        {
            var addedEntity = _context.Entry(note);
            addedEntity.State = EntityState.Modified;
            _context.SaveChanges();
            addedEntity.State = EntityState.Detached;
        }
    }
}
