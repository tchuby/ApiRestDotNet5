using ApiRest.Api.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiRest.Api.Model.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return person;
        }

        public Person Update(Person person)
        {
            if (!Existis(person.Id))
                return null;

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result == null)
                return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                //
            }
        }

        private bool Existis(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
