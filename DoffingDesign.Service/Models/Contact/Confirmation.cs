namespace DoffingDesign.Service.Models.Contact
{
    public class Confirmation
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        private Confirmation()
        {
            
        }

        public static Confirmation Success()
        {
            return new Confirmation
            {
                IsSuccess = true
            };
        }

        public Confirmation(string message)
        {
            IsSuccess = false;
            ErrorMessage = message;
        }
    }
}