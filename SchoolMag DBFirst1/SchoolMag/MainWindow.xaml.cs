using System.Windows;
using System.Windows.Input;
using System.Data.Entity;
using System.Linq;

namespace SchoolMag
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SchoolMagDBEntities SubDB;
        public MainWindow()
        {
            InitializeComponent();

            SubDB = new SchoolMagDBEntities();
            SubDB.T_Subjects.Load();

            SubjectDataGrid.ItemsSource = SubDB.T_Subjects.Local.ToBindingList();
        }
        
        private void gBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            //ReturnString = "-1";
            Close();
        }

        private void AddSubjectTextBox_Click(object sender, RoutedEventArgs e)
        {
            SubjectTextBox.Text = LeadTeacherTextBox.Text = ClassYearTextBox.Text = "";

            AddSubGrid.Visibility = Visibility.Visible;
            AddSubButton.Visibility = Visibility.Visible;
            EditSubButton.Visibility = Visibility.Hidden;
        }

        private void AddSubButton_Click(object sender, RoutedEventArgs e)
        {
            T_Subjects newSubject = new T_Subjects()
            {
                Subject = SubjectTextBox.Text,
                LeadTeacher = LeadTeacherTextBox.Text,
                ClassYear = ClassYearTextBox.Text
            };
            SubDB.T_Subjects.Add(newSubject);
            SubDB.SaveChanges();
            SubjectDataGrid.ItemsSource = SubDB.T_Subjects.ToList();
        }

        private void EditSubjectTextBox_Click(object sender, RoutedEventArgs e)
        {
            if (SubjectDataGrid.SelectedItems.Count > 0)
            {
                AddSubGrid.Visibility = Visibility.Visible;
                AddSubButton.Visibility = Visibility.Hidden;
                EditSubButton.Visibility = Visibility.Visible;

                int ID = (SubjectDataGrid.SelectedItem as T_Subjects).SubjectID;
                T_Subjects showSubject = (from m in SubDB.T_Subjects
                                          where m.SubjectID == ID
                                          select m).FirstOrDefault();
                SubjectTextBox.Text = showSubject.Subject;
                LeadTeacherTextBox.Text = showSubject.LeadTeacher;
                ClassYearTextBox.Text = showSubject.ClassYear;
            }
        }

        private void EditSubButton_Click(object sender, RoutedEventArgs e)
        {
            int ID = (SubjectDataGrid.SelectedItem as T_Subjects).SubjectID;
            T_Subjects editSubject = (from m in SubDB.T_Subjects
                                      where m.SubjectID == ID
                                select m).FirstOrDefault();
            editSubject.Subject = SubjectTextBox.Text.Trim();
            editSubject.LeadTeacher = LeadTeacherTextBox.Text.Trim();
            editSubject.ClassYear = ClassYearTextBox.Text.Trim();

            SubDB.SaveChanges();
            SubjectDataGrid.ItemsSource = SubDB.T_Subjects.ToList();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            SubjectTextBox.Text = LeadTeacherTextBox.Text = ClassYearTextBox.Text = "";
            AddSubGrid.Visibility = Visibility.Hidden;
        }

        private void DeleteSubjectTextBox_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this subject?", "Delete operation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                int ID = (SubjectDataGrid.SelectedItem as T_Subjects).SubjectID;
                T_Subjects deleteSubject = (from m in SubDB.T_Subjects
                                             where m.SubjectID == ID
                                             select m).FirstOrDefault();
                SubDB.T_Subjects.Remove(deleteSubject);
                SubDB.SaveChanges();
                SubjectDataGrid.ItemsSource = SubDB.T_Subjects.ToList();
                MessageBox.Show("Delete Successfully!");                
            }
        }

        private void RefreshSubjectTextBox_Click(object sender, RoutedEventArgs e)
        {
            SubjectDataGrid.ItemsSource = SubDB.T_Subjects.ToList();
            AddSubGrid.Visibility = Visibility.Hidden;
        }
    }
}
