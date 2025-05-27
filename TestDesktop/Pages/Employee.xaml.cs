using System.Windows;
using System.Windows.Controls;
using TestDesktop.Models;

namespace TestDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Employee : Page
    {
        public Models.Employee _thisEmployee;
        private List<Absences> allAbsences;
        public Employee(Models.Employee employee)
        {
            InitializeComponent();
            allAbsences = new List<Absences>();
            DepartmentComboBox.Items.Clear();
            DirectorComboBox.Items.Clear();
            AssistantComboBox.Items.Clear();
            foreach (var depItem in Main.Departaments)
            {
                ComboBoxItem DepItem = new ComboBoxItem()
                {
                    Tag = depItem.Id,
                    Content = depItem.Name.ToString(),
                };
                DepartmentComboBox.Items.Add(DepItem);
            }
            if (employee != null)
            {
                _thisEmployee = employee;
                LoadData();
                AddAbsenceBtn.IsEnabled = true;
                FullNameTextBox.Text = _thisEmployee.FullName;
                MobilePhoneTextBox.Text = _thisEmployee.MobilePhone;
                BirthDatePicker.SelectedDate = _thisEmployee.BirthDate;
                foreach (ComboBoxItem item in DepartmentComboBox.Items)
                {
                    if (item.Content == Main.Departaments.FirstOrDefault(x => x.Id == Main.Positions.FirstOrDefault(x => x.Id == _thisEmployee.PositionId).DepartamentId).Name)
                    {
                        DepartmentComboBox.SelectedItem = item;
                    }
                }
                PositionTextBox.Text = Main.Positions.FirstOrDefault(x => x.Id == _thisEmployee.PositionId).Name;
                WorkPhoneTextBox.Text = _thisEmployee.WorkPhone;
                EmailTextBox.Text = _thisEmployee.Email;
                OfficeTextBox.Text = _thisEmployee.Office;
                if (_thisEmployee.DirectorId != null)
                {
                    foreach (var dir in Main.Employees)
                    {
                        if (dir.FullName == _thisEmployee.FullName)
                        {
                            return;
                        }
                        ComboBoxItem selectedItem = (ComboBoxItem)DepartmentComboBox.SelectedItem;
                        if ((int)selectedItem.Tag == Main.Positions.FirstOrDefault(x => x.Id == _thisEmployee.PositionId).DepartamentId)
                        {
                            ComboBoxItem dirItem = new ComboBoxItem()
                            {
                                Tag = dir.Id,
                                Content = dir.FullName,
                            };
                            DirectorComboBox.Items.Add(dirItem);
                        }
                    }
                    foreach (ComboBoxItem item in DirectorComboBox.Items)
                    {
                        if ((int)item.Tag == _thisEmployee.DirectorId)
                        {
                            DirectorComboBox.SelectedItem = item;
                        }
                    }
                }
                if (_thisEmployee.AssistantId != null)
                {
                    foreach (var assistant in Main.Employees)
                    {
                        if (assistant.FullName == _thisEmployee.FullName)
                        {
                            return;
                        }
                        ComboBoxItem selectedItem = (ComboBoxItem)DepartmentComboBox.SelectedItem;
                        if ((int)selectedItem.Tag == Main.Positions.FirstOrDefault(x => x.Id == assistant.PositionId).DepartamentId)
                        {
                            ComboBoxItem assItem = new ComboBoxItem()
                            {
                                Tag = assistant.Id,
                                Content = assistant.FullName,
                            };
                            AssistantComboBox.Items.Add(assItem);
                        }
                    }
                    foreach (ComboBoxItem item in AssistantComboBox.Items)
                    {
                        if ((int)item.Tag == _thisEmployee.AssistantId)
                        {
                            AssistantComboBox.SelectedItem = item;
                        }
                    }
                }
            }
        }

        private void LoadData()
        {
            allAbsences.Clear();
            foreach (Models.Absences abs in Main.Absences)
            {
                allAbsences.Add(abs);
            }
            UpdateListViews(allAbsences);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(FullNameTextBox.Text))
            {
                MessageBox.Show("Пустые или некорректные данные о ФИО!");
                return;
            }
            if (String.IsNullOrEmpty(BirthDatePicker.Text))
            {
                MessageBox.Show("Пустые или некорректные данные о Дате рождении!");
                return;
            }
            if (DepartmentComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Пустые или некорректные данные об подразделении!");
                return;
            }
            if (String.IsNullOrEmpty(PositionTextBox.Text))
            {
                MessageBox.Show("Пустые или некорректные данные о должности!");
                return;
            }
            if (String.IsNullOrEmpty(WorkPhoneTextBox.Text))
            {
                MessageBox.Show("Пустые или некорректные данные о рабочем телефоне!");
                return;
            }
            if (String.IsNullOrEmpty(EmailTextBox.Text))
            {
                MessageBox.Show("Пустые или некорректные данные о Email!");
                return;
            }
            if (String.IsNullOrEmpty(OfficeTextBox.Text))
            {
                MessageBox.Show("Пустые или некорректные данные об кабинете!");
                return;
            }
            if (_thisEmployee != null)
            {
                try
                {
                    ApiContext apiContext = new ApiContext();
                    _thisEmployee.FullName = FullNameTextBox.Text;
                    _thisEmployee.BirthDate = BirthDatePicker.SelectedDate.Value;
                    Models.Position redactPosition = Main.Positions.FirstOrDefault(x => x.Id == _thisEmployee.PositionId);
                    redactPosition.Name = PositionTextBox.Text;
                    ComboBoxItem selectedDepartamentItem = (ComboBoxItem)DepartmentComboBox.SelectedItem;
                    redactPosition.DepartamentId = (int)selectedDepartamentItem.Tag;
                    apiContext.PutPosition(redactPosition);
                    _thisEmployee.PositionId = redactPosition.Id;
                    _thisEmployee.WorkPhone = WorkPhoneTextBox.Text;
                    _thisEmployee.MobilePhone = MobilePhoneTextBox.Text;
                    _thisEmployee.Email = EmailTextBox.Text;
                    _thisEmployee.Office = OfficeTextBox.Text;
                    if (DirectorComboBox.SelectedIndex != -1) 
                    {
                        ComboBoxItem selectedDirectorItem = (ComboBoxItem)DirectorComboBox.SelectedItem;
                        _thisEmployee.DirectorId = (int)selectedDepartamentItem.Tag;
                    }
                    if (AssistantComboBox.SelectedIndex != -1)
                    {
                        ComboBoxItem selectedAssistantItem = (ComboBoxItem)AssistantComboBox.SelectedItem;
                        _thisEmployee.AssistantId = (int)selectedAssistantItem.Tag;
                    }
                    apiContext.PutEmployee(_thisEmployee);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    ApiContext apiContext = new ApiContext();
                    Models.Employee newEmployee = new Models.Employee();
                    newEmployee.FullName = FullNameTextBox.Text;
                    newEmployee.BirthDate = BirthDatePicker.SelectedDate.Value;
                    Models.Position newPosition = new Position();
                    newPosition.Name = PositionTextBox.Text;
                    ComboBoxItem selectedDepartamentItem = (ComboBoxItem)DepartmentComboBox.SelectedItem;
                    newPosition.DepartamentId = (int)selectedDepartamentItem.Tag;
                    Main.Positions.Add(newPosition);
                    var newPositionId = apiContext.PostPosition(newPosition);
                    newEmployee.PositionId = newPositionId.Id;
                    newEmployee.WorkPhone = WorkPhoneTextBox.Text;
                    newEmployee.MobilePhone = MobilePhoneTextBox.Text;
                    newEmployee.Email = EmailTextBox.Text;
                    newEmployee.Office = OfficeTextBox.Text;
                    if (DirectorComboBox.SelectedItem != null || AssistantComboBox.SelectedItem != null)
                    {
                        ComboBoxItem selectedDirectorItem = (ComboBoxItem)DirectorComboBox.SelectedItem;
                        newEmployee.DirectorId = (int)selectedDepartamentItem.Tag;
                        ComboBoxItem selectedAssistantItem = (ComboBoxItem)AssistantComboBox.SelectedItem;
                        newEmployee.AssistantId = (int)selectedAssistantItem.Tag;
                    }
                    Main.Employees.Add(newEmployee);
                    apiContext.PostEmployee(newEmployee);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            MainWindow.init.frame.Navigate(new Pages.Main());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Main());
        }

        private void DepartmentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DirectorComboBox.Items.Clear();
            AssistantComboBox.Items.Clear();
            if (DepartmentComboBox.SelectedItem is not ComboBoxItem selectedItem) return;
            int selectedDepartmentId = (int)selectedItem.Tag;
            foreach (var employee in Main.Employees)
            {
                if (_thisEmployee != null && employee.Id == _thisEmployee.Id)
                    continue;
                int employeeDepId = Main.Positions.FirstOrDefault(x => x.Id == employee.PositionId)?.DepartamentId ?? -1;
                if (employeeDepId != selectedDepartmentId)
                    continue;

                ComboBoxItem directorItem = new ComboBoxItem
                {
                    Tag = employee.Id,
                    Content = employee.FullName
                };

                ComboBoxItem assistantItem = new ComboBoxItem
                {
                    Tag = employee.Id,
                    Content = employee.FullName
                };

                DirectorComboBox.Items.Add(directorItem);
                AssistantComboBox.Items.Add(assistantItem);
            }
            if (_thisEmployee != null)
            {
                if (_thisEmployee.DirectorId != null)
                {
                    foreach (ComboBoxItem item in DirectorComboBox.Items)
                    {
                        if ((int)item.Tag == _thisEmployee.DirectorId)
                        {
                            DirectorComboBox.SelectedItem = item;
                            break;
                        }
                    }
                }

                if (_thisEmployee.AssistantId != null)
                {
                    foreach (ComboBoxItem item in AssistantComboBox.Items)
                    {
                        if ((int)item.Tag == _thisEmployee.AssistantId)
                        {
                            AssistantComboBox.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }

        private void UpdateListViews(IEnumerable<Absences> absences)
        {
            TrainingsListView.Items.Clear();
            AbsencesListView.Items.Clear();
            VacationsListView.Items.Clear();
            foreach (var trainingItem in absences.Where(x => x.EmployeeId == _thisEmployee.Id && x.Type == AbsenceType.обучение).ToList())
            {
                TrainingsListView.Items.Add(trainingItem);
            }
            foreach (var absenceItem in absences.Where(x => x.EmployeeId == _thisEmployee.Id && x.Type == AbsenceType.отгул || x.Type == AbsenceType.отсутствие).ToList())
            {
                AbsencesListView.Items.Add(absenceItem);
            }
            foreach (var vacationItem in absences.Where(x => x.EmployeeId == _thisEmployee.Id && x.Type == AbsenceType.отпуск).ToList())
            {
                VacationsListView.Items.Add(vacationItem);
            }
        }

        private void FilterPastEvents(object sender, RoutedEventArgs e)
        {
            var now = DateTime.Now;
            UpdateListViews(allAbsences.Where(a => a.EmployeeId == _thisEmployee.Id && a.EndDate < now));
        }

        private void FilterCurrentEvents(object sender, RoutedEventArgs e)
        {
            var now = DateTime.Now;
            UpdateListViews(allAbsences.Where(a => a.EmployeeId == _thisEmployee.Id && a.StartDate <= now && a.EndDate >= now));
        }

        private void FilterFutureEvents(object sender, RoutedEventArgs e)
        {
            var now = DateTime.Now;
            UpdateListViews(allAbsences.Where(a => a.EmployeeId == _thisEmployee.Id && a.StartDate > now));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.AbsencePage(null, _thisEmployee));
        }

        private void TrainingsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TrainingsListView.SelectedItem is Absences selectedItem)
            {
                MainWindow.init.frame.Navigate(new Pages.AbsencePage(selectedItem, _thisEmployee));
            }
        }

        private void AbsencesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AbsencesListView.SelectedItem is Absences selectedItem)
            {
                MainWindow.init.frame.Navigate(new Pages.AbsencePage(selectedItem, _thisEmployee));
            }
        }

        private void VacationsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VacationsListView.SelectedItem is Absences selectedItem)
            {
                MainWindow.init.frame.Navigate(new Pages.AbsencePage(selectedItem, _thisEmployee));
            }
        }
    }
}
