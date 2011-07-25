
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using NaboursCRM.Model;

namespace NaboursCRM.Service
{
    [ServiceContract]
    public interface IContacts
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/")]
        List<Person> GetContacts();
    }
}
