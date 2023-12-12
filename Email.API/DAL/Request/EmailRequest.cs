namespace Email.API.DAL.Request
{
    public class EmailRequest
    {
        public string RecipientEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
