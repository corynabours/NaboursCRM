using NHibernate;

namespace NaboursCRM.DataAccess
{
    public class NHibernateFactory
    {
        private static ISessionFactory _sessionFactory;
        private static ISession _session;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new NHibernate.Cfg.Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof(NHibernateFactory).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return _session ?? (_session = SessionFactory.OpenSession());
        }
    }
}
