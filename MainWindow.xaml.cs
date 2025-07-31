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
        private int selectedId = 0;
        private AppDbContext ADC = new AppDbContext();

        private void ClearData()
        {
            Title.Clear();
            Description.Clear();
            TaskDate.SelectedDate = null;
        }

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
            ClearData();
            MessageBox.Show("ITEMS ADDED!","CONFIRMATION",MessageBoxButton.OK, MessageBoxImage.Information);
            ShowData();
        }

        private void TaskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TaskList.SelectedItem is TodoItem item)
            {
                Title.Text = item.Title;
                Description.Text = item.Description;
                TaskDate.SelectedDate = item.TaskDate;
                State.Text = item.Status;
                selectedId = item.Id;
            }
        }

        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if(selectedId != 0)
            {
            var item = ADC.TodoItem.Find(selectedId);
            item.Title = Title.Text;
            item.Description = Description.Text;
            item.TaskDate = TaskDate.SelectedDate;
            item.Status = State.Text;
            ADC.TodoItem.Update(item);
            ADC.SaveChanges();
            ClearData();
            MessageBox.Show("ITEMS UPDATED!", "CONFIRMATION", MessageBoxButton.OK, MessageBoxImage.Information);
            ShowData();
            }
        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedId != 0)
            {
                var item = ADC.TodoItem.Find(selectedId);
                ADC.TodoItem.Remove(item);
                ADC.SaveChanges();
                ClearData();
                MessageBox.Show("ITEMS DELETED!", "CONFIRMATION", MessageBoxButton.OK, MessageBoxImage.Information);
                ShowData();
            }
        }
    }
}
