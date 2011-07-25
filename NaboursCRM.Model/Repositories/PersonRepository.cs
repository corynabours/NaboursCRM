using System;
using System.Collections.Generic;

namespace NaboursCRM.Model.Repositories
{
    public interface PersonRepository
    {
        IList<Person> GetAll();
        int GetCountOfAll();
        Guid AddPerson(Person newPerson);
        void DeletePerson(Guid idToDelete);
        Person GetPerson(Guid personId);
        void UpdatePerson(Person person);
    }
}
