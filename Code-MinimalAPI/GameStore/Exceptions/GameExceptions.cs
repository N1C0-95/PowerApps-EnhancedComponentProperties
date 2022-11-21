namespace GameStore.Exceptions
{
    public class GameExceptions : Exception 
    {
        public int ErrorCode;

        public GameExceptions(string message, int errorCode)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}
