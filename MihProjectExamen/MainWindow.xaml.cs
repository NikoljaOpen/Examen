using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary;
using Application = ClassLibrary.Application;
using Task = ClassLibrary.Task;

namespace MihProjectExamen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Application application = Application.GetApplication();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TaskListBox.ItemsSource = application.TaskLists;
            TaskListBox.SelectedIndex = 0;
        }

        private void Update()
        {
            int id = TaskListBox.SelectedIndex;
            TaskListBox.ItemsSource = new List<TaskList>();
            TaskListBox.ItemsSource = application.TaskLists;
            TaskListBox.SelectedIndex = id;
            if (TaskListBox.SelectedItem != null)
            {
                TaskBox.ItemsSource = new List<Task>();
                TaskBox.ItemsSource = application.TaskLists[id].Tasks;
            }
            
        }

        private void TaskListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TaskListBox.SelectedItem != null)
            {
                int id = TaskListBox.SelectedIndex;
                TaskBox.ItemsSource = new List<Task>();
                TaskBox.ItemsSource = application.TaskLists[id].Tasks;
                NameBox.Content = application.TaskLists[id].Name;
            }
        }

        private void AddTaskListTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                application.TaskLists.Add(new TaskList(AddTaskListTextBox.Text, new List<Task>()));
                AddTaskListTextBox.Text = "";
                AddTaskListTextBox.Visibility = Visibility.Hidden;
                Update();
            }
        }

        private void AddTaskListBt_Click(object sender, RoutedEventArgs e)
        {
            AddTaskListTextBox.Visibility = Visibility.Visible;
            AddTaskListTextBox.Focus();
        }

        private void AddTaskBt_Click(object sender, RoutedEventArgs e)
        {
            AddTaskTextBox.Visibility = Visibility.Visible;
            AddTaskTextBox.Focus();
        }

        private void AddTaskTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int id = TaskListBox.SelectedIndex;
                application.TaskLists[id].Tasks.Add(new Task(AddTaskTextBox.Text, DateTime.Now));
                AddTaskTextBox.Text = "";
                AddTaskTextBox.Visibility = Visibility.Hidden;
                Update();
            }
        }

        private void DeliteTask_Click(object sender, RoutedEventArgs e)
        {
            int id = TaskListBox.SelectedIndex;
            Button button = (Button)sender;
            Task task = application.TaskLists[id].Tasks.Where(t => t.Title == button.Tag.ToString()).FirstOrDefault();
            application.TaskLists[id].Tasks.Remove(task);
            Update();
        }

        private void DeliteTaskList_Click(object sender, RoutedEventArgs e)
        {
            int id = TaskListBox.SelectedIndex;
            Button button = (Button)sender;
            if (application.TaskLists[id].TasksCount != 0)
            {
                CheckedWindow wind = new CheckedWindow(application.TaskLists[id].TasksCount);
                if(wind.ShowDialog() == true)
                {
                    application.TaskLists.Remove(application.TaskLists[id]);
                    Update();
                }
            }
        }
    }
}
