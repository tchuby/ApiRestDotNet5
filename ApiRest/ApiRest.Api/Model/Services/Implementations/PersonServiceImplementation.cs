using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Api.Model.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private Person person;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            //
        }

        public List<Person> FindAll()
        {
            var people = new List<Person>();
            for(int i = 1; i < 7; i++)
            {
                string gender = "Female";

                if(i % 2 == 1)
                    gender = "Male";

                Person person = new Person
                {
                    Id = i,
                    FirstName = "Person #"+i,
                    LastName = "XX",
                    Address = "Blumenau - SC.",
                    Gender = gender
                };

                people.Add(person);
            }
            return people;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = id,
                FirstName = "Mussum",
                LastName = "Manguaça",
                Address = "Morro da Mangueira.",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
