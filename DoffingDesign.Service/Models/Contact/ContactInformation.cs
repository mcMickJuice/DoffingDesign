namespace DoffingDesign.Service.Models.Contact
{
    public class ContactInformation:BasicInformation
    {
        public string Message { get; set; }
        public string Website { get; set; }
        public bool NewsletterSubscribe { get; set; }
    }
}