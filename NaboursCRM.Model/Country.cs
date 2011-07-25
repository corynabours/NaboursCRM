using System;

namespace NaboursCRM.Model
{
    public class Country
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string MailingFormat { get; set; }
    }
}
