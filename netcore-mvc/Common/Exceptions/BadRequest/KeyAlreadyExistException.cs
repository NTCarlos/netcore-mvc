namespace Common.Exceptions.BadRequest
{
    public class KeyAlreadyExistException : BaseBadRequestException
    {
        public KeyAlreadyExistException() : base()
        {
            CustomMessage = "Setting for that Key Already Exist.";
        }
    }
}
