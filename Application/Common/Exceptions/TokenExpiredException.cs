namespace Application.Common.Exceptions
{
    public class TokenExpiredException : Exception
    {
        public DateTime DataExpiracao { get; set; }

        public TokenExpiredException(DateTime dataExpiracao)
        { DataExpiracao = dataExpiracao; }

        public override string Message => "O token expirou em " + DataExpiracao.ToString("dd/MM/yyyy HH:mm:ss");
    }
}