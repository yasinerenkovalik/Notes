using Notes.Application;
using Notes.Domail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Persistence
{
    public class NoteService : INoteService
    {
        public void Add(Note note)
        {
            throw new NotImplementedException();
        }

        public void Deleted(Note note)
        {
            throw new NotImplementedException();
        }

        public Note Get(Expression<Func<Note, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Note> GetAll(Expression<Func<Note, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
