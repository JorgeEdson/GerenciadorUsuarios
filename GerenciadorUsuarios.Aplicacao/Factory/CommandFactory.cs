namespace GerenciadorUsuarios.Aplicacao.Factory
{
    public static class CommandFactory
    {
        public static Command<T, R> Create<T, R>(T data) => new Command<T, R>(data);
    }

    public class Command<T, R> : IRequest<R>
    {
        public T Data { get; set; }

        public Command(T data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
