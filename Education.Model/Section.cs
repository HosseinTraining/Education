using System.Collections.Generic;

namespace Education.Model
{
    public class Section
    {
        public Section()
        {
            Parts = new List<Part>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}