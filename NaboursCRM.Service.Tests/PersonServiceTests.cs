using System;
using System.Collections.Generic;
using NaboursCRM.Model;
using NaboursCRM.Model.Repositories;
using NUnit.Framework;
using Rhino.Mocks;

namespace NaboursCRM.Service.Tests
{
    [TestFixture]
    public class PersonServiceTests
    {

        protected MockRepository _mocks;
        protected PersonService _contactsService;
        protected PersonRepository _repository;

        [SetUp]
        public void Initialize()
        {
            _mocks = new MockRepository();
            _repository = _mocks.DynamicMock<PersonRepository>();
            _contactsService = new PersonService(_repository);
        }

        [Test]
        public void ShouldBeCreatable()
        {
            Assert.DoesNotThrow(delegate { new PersonService(); });
        }

        [Test]
        public void ShouldBeAbletoGetListofContacts()
        {
            var results = new List<Person>();
            _repository.Expect(r => r.GetAll()).Return(results);
            _mocks.ReplayAll();
            var contacts = _contactsService.GetPeople();
            _mocks.VerifyAll();
            Assert.AreEqual(results, contacts);
        }

        [Test]
        public void ShouldBeAbleToGetAContact()
        {
            var samplePerson = new Person();
            var id = Guid.NewGuid();
            _repository.Expect(r => r.GetPerson(id)).Return(samplePerson);
            _mocks.ReplayAll();
            var contact = _contactsService.GetPerson(id.ToString());
            _mocks.VerifyAll();
            Assert.AreSame(samplePerson, contact);
        }

        [Test]
        public void ShouldBeAbleToAddAContact()
        {
            var samplePerson = new Person();
            var id = Guid.NewGuid();
            _repository.Expect(r => r.AddPerson(samplePerson)).Return(id).Repeat.Twice();
            _mocks.ReplayAll();
            _contactsService.AddPerson(samplePerson);
            _contactsService.AddPersonForJsonp(samplePerson);
            _mocks.VerifyAll();
        }

        [Test]
        public void ShouldBeAbleToUpdateAContact()
        {
            var samplePerson = new Person();
            var id = Guid.NewGuid();
            _repository.Expect(r => r.UpdatePerson(samplePerson)).Repeat.Twice();
            _mocks.ReplayAll();
            _contactsService.UpdatePerson(id.ToString(), samplePerson);
            _contactsService.UpdatePersonForJsonp(id.ToString(), samplePerson);
            _mocks.VerifyAll();
        }

        [Test]
        public void ShouldBeAbleToDeleteAContact()
        {
            var id = Guid.NewGuid();
            _repository.Expect(r => r.DeletePerson(id)).Repeat.Twice();
            _mocks.ReplayAll();
            _contactsService.DeletePerson(id.ToString());
            _contactsService.DeletePersonForJsonp(id.ToString());
            _mocks.VerifyAll();
        }
    }
}
