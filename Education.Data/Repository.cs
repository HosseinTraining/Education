using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Model;

namespace Education.Data
{
    public class PersonRepository
    {
        private EducationContext _ctx;

        public PersonRepository()
        {
            _ctx = new EducationContext();
        }
        public bool Add(Person person)
        {
            _ctx.Persons.Add(person);
            return Save();
        }

        public Person Find(int id)
        {
            return _ctx.Persons.Find(id);
        }
        public IQueryable<Person> GetAll()
        {
            return _ctx.Persons;
        }

        public bool Update(Person person)
        {
            _ctx.Persons.Attach(person);
            _ctx.Entry(person).State = EntityState.Modified;
            return Save();
        }
        public bool Delete(Person person)
        {
            _ctx.Persons.Remove(person);
            return Save();
        }
        public bool Save()
        {
            return Convert.ToBoolean(_ctx.SaveChanges());
        }

        public IQueryable<Person> GetAllWithMessages()
        {
            return _ctx.Persons.Include("Messages");
        }

        public Person FindWithMessages(int personId)
        {
            return _ctx.Persons.Include("Messages").AsEnumerable().FirstOrDefault(x => x.Id == personId);
        }
    }
}
