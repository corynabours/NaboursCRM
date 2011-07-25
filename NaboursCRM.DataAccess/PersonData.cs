using System;
using System.Collections.Generic;
using NaboursCRM.Model;
using NaboursCRM.Model.Repositories;
using NHibernate.Criterion;

namespace NaboursCRM.DataAccess
{
    public class PersonData : PersonRepository
    {
        public IList<Person> GetAll()
        {
            var session = NHibernateFactory.OpenSession();
            var ivrExtensions = session
                .CreateCriteria(typeof (Person))
                .AddOrder(Order.Asc("LastName"))
                .List<Person>();
            return ivrExtensions;
        }

        public int GetCountOfAll()
        {
            var session = NHibernateFactory.OpenSession();
            var result = session
                .CreateQuery("select count(*) from Person")
                .UniqueResult();

            var count = Convert.ToInt32(result);
            return count;
        }

        public Guid AddPerson(Person newPerson)
        {
            var session = NHibernateFactory.OpenSession();
            var transaction = session.BeginTransaction();
            session.SaveOrUpdate(newPerson);
            transaction.Commit();
            return newPerson.Id;
        }

        public void DeletePerson(Guid idToDelete)
        {
            var person = GetPerson(idToDelete);
            var session = NHibernateFactory.OpenSession();
            var transaction = session.BeginTransaction();
            session.Delete(person);
            transaction.Commit();
        }

        public Person GetPerson(Guid personId)
        {
            var session = NHibernateFactory.OpenSession();
            var person = session
                .CreateCriteria(typeof (Person))
                .Add(Restrictions.Eq("Id", personId))
                .UniqueResult<Person>();
            return person;
        }

        public void UpdatePerson(Person person)
        {
            var session = NHibernateFactory.OpenSession();
            var transaction = session.BeginTransaction();
            session.SaveOrUpdate(person);
            transaction.Commit();
        }

        public void RenewSession()
        {
            NHibernateFactory.RenewSession();
        }
    }
}
