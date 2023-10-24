namespace Application.Common.Exceptions
{
    public class InvalidTokenException : Exception
    {
        public override string Message => "Token inválido.";
    }
}