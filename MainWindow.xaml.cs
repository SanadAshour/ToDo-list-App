using Microsoft.EntityFrameworkCore;
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
            fillCategoryCB();
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
            TaskList.ItemsSource = ADC.TodoItem.Include(t => t.Category).ToList();
        }

        private bool ValidateData()
        {
            bool valid = true;
            if (Title.Text == "")
            {
                valid = false;
                MessageBox.Show("PLEASE ENTER A TITLE!", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (Description.Text == "")
            {
                valid = false;
                MessageBox.Show("PLEASE ENTER A DESCRIPTION!", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (TaskDate.Text == "")
            {
                valid = false;
                MessageBox.Show("PLEASE ENTER A DATE!", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (State.Text == "")
            {
                valid = false;
                MessageBox.Show("PLEASE SELECT A STATE!", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return valid;
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }

                ADC.Add(new TodoItem
                {
                    Title = Title.Text,
                    Description = Description.Text,
                    TaskDate = TaskDate.SelectedDate,
                    Status = State.Text,
                    CategoryId = (int)CategoryCB.SelectedValue
                });

                ADC.SaveChanges();
                ClearData();
                MessageBox.Show("ITEMS ADDED!", "CONFIRMATION", MessageBoxButton.OK, MessageBoxImage.Information);
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
                CategoryCB.SelectedValue = item.CategoryId;
                EditMode();
            }
        }

        private void EditMode()
        {
            updatebtn.IsEnabled = true;
            deletebtn.IsEnabled = true;
            addbtn.IsEnabled = false;
        }

        private void NewMode()
        {
            updatebtn.IsEnabled = false;
            deletebtn.IsEnabled = false;
            addbtn.IsEnabled = true;
        }

        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }

            if(selectedId != 0)
            {
            var item = ADC.TodoItem.Find(selectedId);
            item.Title = Title.Text;
            item.Description = Description.Text;
            item.TaskDate = TaskDate.SelectedDate;
            item.Status = State.Text;
            item.CategoryId = (int)CategoryCB.SelectedValue;
            ADC.TodoItem.Update(item);
            ADC.SaveChanges();
            ClearData();
            NewMode();
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
                NewMode() ;
                MessageBox.Show("ITEMS DELETED!", "CONFIRMATION", MessageBoxButton.OK, MessageBoxImage.Information);
                ShowData();
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
            NewMode();
        }

        private void ManageCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow w = new CategoryWindow();
            w.ShowDialog();
        }

        private void fillCategoryCB()
        {
            CategoryCB.ItemsSource = ADC.Categories.ToList();
        }
    }
}
