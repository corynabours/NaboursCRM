namespace NaboursCRM.Model
{
    public class AddressType
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }


        public static AddressType Mailing
        {
            get { return new AddressType { Description = "Mailing", Id = 1 }; }
        }

        public static AddressType Home 
        {
            get { return new AddressType { Description = "Primary home", Id = 2 }; }
        }

        public static AddressType Work 
        {
            get { return new AddressType { Description = "Work", Id = 3 }; }
        }

        public static AddressType Property 
        {
            get { return new AddressType { Description = "Property", Id = 4 }; }
        }
    }
}
