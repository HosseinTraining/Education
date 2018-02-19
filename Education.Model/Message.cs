using System.Collections.Generic;

namespace Education.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Person Sender { get; set; }
        public Person Reciver { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}