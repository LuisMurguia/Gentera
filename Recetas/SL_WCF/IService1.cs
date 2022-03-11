using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumnos))]
        SL_WCF.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.RecetasAlumnos))]
        SL_WCF.Result GetByIdEF(int Id);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumnos))]
        SL_WCF.Result GetByMatricula(int matricula);


        [OperationContract]
        SL_WCF.Result Add(ML.RecetasAlumnos alumno);
        // TODO: Add your service operations here

        [OperationContract]
        SL_WCF.Result Update(ML.Receta alumno);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Receta))]
        SL_WCF.Result GetByIdReceta(int Id);
    }

    [DataContract]

    public class Result
    {

        [DataMember]
        public bool Correct { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public Exception Ex { get; set; }

        [DataMember]
        public object Object { get; set; }

        [DataMember]
        public List<object> Objects { get; set; }

    }
    // Use a data contract as illustrated in the sample below to add composite types to service operations.


}
