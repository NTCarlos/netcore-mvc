namespace Services.Exceptions.NotFound
{
    class ArgumentNotFound: BaseNotFoundException
    {
        public ArgumentNotFound(string nameof) : base()
        {
            CustomMessage = $"Argument {nameof} cannot be found.";
        }
    }
}
