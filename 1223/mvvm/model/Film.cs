using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinishka.mvvm.model
{
    public class Film
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string regiser { get; set; } = string.Empty;
        public string create { get; set; } = string.Empty;
        public string filmgenre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public List<Tag> Tags { get; set; } = new();
    }

}
