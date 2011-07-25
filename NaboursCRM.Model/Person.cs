using System;
using System.Collections.Generic;

namespace NaboursCRM.Model
{
    [Serializable]
    public class Person
    {
        public Person()
        {
            PhoneNumbers = new List<Phone>();
            Addresses = new List<Address>();
        }

        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual IList<Phone> PhoneNumbers { get; private set; }
        public virtual IList<Address> Addresses { get; private set; }
    }
}
