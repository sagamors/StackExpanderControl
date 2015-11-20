using System.Collections.ObjectModel;
using System.Windows;
using PropertyChanged;

namespace Test
{
    [ImplementPropertyChanged]
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<ItemViewModel> Items { get; set; }
        public MainWindow()
        {
            Items = new ObservableCollection<ItemViewModel>();
            Items.Add(new ItemViewModel() {ContentName = "ContentName1", HeaderName = "HeaderName1" });
            Items.Add(new ItemViewModel() { ContentName = "ContentName2", HeaderName = "HeaderName2" });
            InitializeComponent();
        }
    }
}
