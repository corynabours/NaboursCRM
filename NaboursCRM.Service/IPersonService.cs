
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using NaboursCRM.Model;

namespace NaboursCRM.Service
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/")]
        List<Person> GetPeople();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/{id}")]
        Person GetPerson(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/")]
        void AddPerson(Person newPerson);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, UriTemplate = "/{id}")]
        void UpdatePerson(string id, Person updatedPerson);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/{id}")]
        void DeletePerson(string id);

        //JSONP, cross-domain scripting does not allow POST,PUT,DELETE, just get.
        //so additional methods to allow those operations.
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, UriTemplate = "/Add")]
        void AddPersonForJsonp(Person newPerson);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, UriTemplate = "/{id}/Update")]
        void UpdatePersonForJsonp(string id, Person updatedPerson);

        [OperationContract]
        [WebGet(UriTemplate = "/{id}/Delete")]
        void DeletePersonForJsonp(string id);

    }
}
