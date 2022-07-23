namespace UserAuthExample.Data
{
    public class Message
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Token { get; set; }

        public Message(string to, string subject, string token)
        {
            To = to;
            Subject = subject;
            Token = token;
        }


    }
}
