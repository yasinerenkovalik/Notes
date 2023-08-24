using Notes.Application.Repository;
using Notes.Domail;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Notes.Persistence.DTOs;

namespace Notes.Persistence.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly Context _context;
        public NoteRepository(Context context)
        {
            _context = context;
        }
        public bool Add(Note note)
        {
            var addedEntity = _context.Entry(note);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
            addedEntity.State = EntityState.Detached;
            return true;
        }
        public Note? Get(Expression<Func<Note?, bool>> filter)
        {
            return _context.Set<Note>().FirstOrDefault(filter);
        }

        public Note GetById(int id)
        {
            return _context.Set<Note>().FirstOrDefault(n => n.Id == id);
            
        }

        public List<Note> GetUserNotes(int id)
        {
            return _context.Set<Note>().Where(n => n.UserId == id).ToList();
        }

        public void Delete(Note entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
            addedEntity.State = EntityState.Detached;
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
