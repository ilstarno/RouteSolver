/*
 @author Indrit Zeqiri
 @Github https://github.com/ilstarno
 @Linkedin https://www.linkedin.com/in/indrit-zeqiris-3b6b8ba6/
*/
namespace RouteSolver.Service.RemoteServices
{
    
    public sealed class GDistanceMatrixElement
    {
        public GDistanceMatrixElement(GDistanceMatrixAtom duration, string status)
        {
            Duration = duration;
            Status = status;
        }

        public GDistanceMatrixAtom Distance { get; set; }


        public GDistanceMatrixAtom Duration { get; set; }


        public string Status { get; set; }
    }
}