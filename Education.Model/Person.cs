using System.Collections.Generic;

namespace Education.Model
{
    public class Person
    {
        public Person()
        {
            Messages = new List<Message>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public ApiUser ApiUser { get; set; }
    }
}