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
        public string Header { get; set; }
        public string Content { get; set; }

        public ItemViewModel()
        {
            Header = "Header";
            Content = "Content";
        }
    }
}
