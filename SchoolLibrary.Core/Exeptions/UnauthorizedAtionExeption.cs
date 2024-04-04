namespace SchoolLibrary.Core.Exeptions
{
    public class UnauthorizedAtionExeption : Exception
    {
        public UnauthorizedAtionExeption()
        {
               
        }

        public UnauthorizedAtionExeption(string message)
            : base(message) { } 
    }
}
