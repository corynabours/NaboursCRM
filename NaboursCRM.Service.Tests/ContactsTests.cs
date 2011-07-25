using System;
using System.Collections.Generic;
using NaboursCRM.Model;
using NaboursCRM.Model.Repositories;
using NUnit.Framework;
using Rhino.Mocks;

namespace NaboursCRM.Service.Tests
{
    [TestFixture]
    public class ContactsTests
    {

        protected MockRepository _mocks;
        protected Contacts _contactsService;
        protected PersonRepository _repository;

        [SetUp]
        public void Initialize()
        {
            _mocks = new MockRepository();
            _repository = _mocks.DynamicMock<PersonRepository>();
            _contactsService = new Contacts(_repository);
        }

        [Test]
        public void ShouldBeCreatable()
        {
            Assert.DoesNotThrow(delegate { new Contacts(); });
        }

        [Test]
        public void ShouldBeAbletoGetListofContacts()
        {
            var results = new List<Person>();
            _repository.Expect(r => r.GetAll()).Return(results);
            _mocks.ReplayAll();
            var contacts = _contactsService.GetContacts();
            _mocks.VerifyAll();
            Assert.AreEqual(results, contacts);
        }

    }
}
