namespace Common.Exceptions.NotFound
{
    public class ArgumentNotFound: BaseNotFoundException
    {
        public ArgumentNotFound(string nameof) : base()
        {
            CustomMessage = $"Argument {nameof} cannot be found.";
        }
    }
}
