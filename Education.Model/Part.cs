using System.Collections.Generic;

namespace Education.Model
{
    public class Part
    {
        public Part()
        {
            Persons = new List<Person>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public virtual  ICollection<Person>  Persons { get; set; }
    }
}