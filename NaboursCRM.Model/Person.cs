using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NaboursCRM.Model
{
    [Serializable]
    [DataContract]
    public class Person
    {
        private IList<Phone> _phoneNumbers = new List<Phone>();
        private IList<Address> _addresses = new List<Address>();

        [DataMember]
        public virtual Guid Id { get; set; }

        [DataMember]
        public virtual string FirstName { get; set; }

        [DataMember]
        public virtual string LastName { get; set; }

        public virtual IList<Phone> PhoneNumbers
        {
            get { return _phoneNumbers; }
            set { _phoneNumbers = value; }
        }

        public virtual IList<Address> Addresses
        {
            get { return _addresses; }
            set { _addresses = value; }
        }
    }
}
