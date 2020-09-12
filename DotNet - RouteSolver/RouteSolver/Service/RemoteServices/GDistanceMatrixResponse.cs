/*
 @author Indrit Zeqiri
 @Github https://github.com/ilstarno
 @Linkedin https://www.linkedin.com/in/indrit-zeqiris-3b6b8ba6/
*/
namespace RouteSolver.Service.RemoteServices
{
   
    public sealed class GDistanceMatrixResponse
    {
        public GDistanceMatrixResponse(string[] originAddresses, string[] destinationAddresses, string status)
        {
            OriginAddresses = originAddresses;
            DestinationAddresses = destinationAddresses;
            Status = status;
        }

        public string[] DestinationAddresses { get; set; }


        public string[] OriginAddresses { get; set; }


        public GDistanceMatrixRow[] Rows { get; set; }


        public string Status { get; set; }
    }
}