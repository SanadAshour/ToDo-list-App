using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace T0_Do_List
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowData();
        }
        private AppDbContext ADC = new AppDbContext();

        private void ShowData()
        {
            TaskList.ItemsSource = ADC.TodoItem.ToList();
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            ADC.Add(new TodoItem {
                Title= Title.Text,
                Description= Description.Text,
                TaskDate= TaskDate.SelectedDate,
                Status = State.Text
                });
            
            ADC.SaveChanges();

            Title.Clear();
            Description.Clear();
            TaskDate.SelectedDate = null;

            ShowData();
            MessageBox.Show("ITEMS ADDED!","CONFIRMATION",MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}