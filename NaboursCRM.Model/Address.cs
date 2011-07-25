using System;

namespace NaboursCRM.Model
{
    public class Address
    {
        public virtual Guid Id { get; set; }
        public virtual string ExtraLine1 { get; set; }
        public virtual string ExtraLine2 { get; set; }
        public virtual string StreetAddress { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual Country Country { get; set; }
        public virtual AddressType Type { get; set; }
    }
}
