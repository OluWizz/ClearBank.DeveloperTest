namespace ClearBank.DeveloperTest.Types
{
    public class MakePaymentResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; internal set; }
    }
}
