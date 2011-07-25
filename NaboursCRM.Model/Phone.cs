using System;

namespace NaboursCRM.Model
{
    public interface IPhone
    {
        Guid Id { get; set; }
        string PhoneNumber { get; set; }
        PhoneType Type { get; set; }
    }

    [Serializable]
    public class Phone : IPhone
    {
        public virtual Guid Id { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual PhoneType Type { get; set; }
    }
}
