using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace Test
{
    [ImplementPropertyChanged]
    public class ItemViewModel
    {
        public string HeaderName { get; set; }
        public string ContentName { get; set; }

        public ItemViewModel()
        {
            HeaderName = "HeaderName";
            ContentName = "ContentName";
        }
    }
}
