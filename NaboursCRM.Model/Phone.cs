using System;

namespace NaboursCRM.Model
{
    [Serializable]
    public class Phone
    {
        public virtual Guid Id { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual PhoneType Type { get; set; }
    }
}
