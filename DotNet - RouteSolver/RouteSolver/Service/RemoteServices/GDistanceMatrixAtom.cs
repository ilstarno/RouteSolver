/*
 @author Indrit Zeqiri
 @Github https://github.com/ilstarno
 @Linkedin https://www.linkedin.com/in/indrit-zeqiris-3b6b8ba6/
*/
namespace RouteSolver.Service.RemoteServices
{
    
    public sealed class GDistanceMatrixAtom
    {
        public GDistanceMatrixAtom(string text)
        {
            Text = text;
        }

        public string Text { get; set; }


        public double Value { get; set; }
    }
}