using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinishka.mvvm.model
{
    public class Tag
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string filmgenre { get; set; }

        public bool Selected { get; set; }
    }
}
