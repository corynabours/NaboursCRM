namespace NaboursCRM.Model
{
    public class PhoneType
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }

        public static PhoneType Home
        {
            get { return new PhoneType {Description = "Home", Id = 1}; }
        }
        public static PhoneType Work
        {
            get { return new PhoneType { Description = "Work", Id = 2 }; }
        }
        public static PhoneType Cell
        {
            get { return new PhoneType { Description = "Cell", Id = 3 }; }
        }

    }
}
