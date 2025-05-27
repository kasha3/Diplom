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
using TestDesktop.Models;

namespace TestDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для AbsencePage.xaml
    /// </summary>
    public partial class AbsencePage : Page
    {
        Models.Absences _abs;
        Models.Employee _emp;
        public AbsencePage(Absences absence, Models.Employee employee)
        {
            InitializeComponent();
            string[] types = { "обучение", "отгул", "отсутствие", "отпуск" };
            for (int i = 0; i < types.Length; i++)
            {
                ComboBoxItem typeItem = new ComboBoxItem()
                {
                    Content = types[i],
                };
                AbsenceTypeCmbx.Items.Add(typeItem);
            }
            if (employee != null) _emp = employee;
            if (absence != null)
            {
                _abs = absence;
                StartDateDatePicker.SelectedDate = _abs.StartDate;
                EndDateDatePicker.SelectedDate = _abs.EndDate;
                DescriptionTextBox.Text = _abs.Description;
                if (_abs.Paid == true)
                {
                    PaidCheckBox.IsEnabled = true;
                    PaidCheckBox.IsChecked = true;
                }
                switch (_abs.Type)
                {
                    case AbsenceType.обучение: { AbsenceTypeCmbx.SelectedIndex = 0; PaidCheckBox.IsEnabled = true; break; };
                    case AbsenceType.отгул: { AbsenceTypeCmbx.SelectedIndex = 1; PaidCheckBox.IsEnabled = false; break; };
                    case AbsenceType.отсутствие: { AbsenceTypeCmbx.SelectedIndex = 2; PaidCheckBox.IsEnabled = false; break; }
                    case AbsenceType.отпуск: { AbsenceTypeCmbx.SelectedIndex = 3; PaidCheckBox.IsEnabled = false; break; }
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StartDateDatePicker.SelectedDate.Value == null || StartDateDatePicker.Text == null)
                {
                    MessageBox.Show("Неверный ввод Стартовой даты!");
                    return;
                }
                if (EndDateDatePicker.SelectedDate.Value == null || EndDateDatePicker.Text == null)
                {
                    MessageBox.Show("Неверный ввод Конечной даты!");
                    return;
                }
                if (DescriptionTextBox.Text == null)
                {
                    MessageBox.Show("Неверный ввод описания!");
                    return;
                }
                if (AbsenceTypeCmbx.SelectedIndex == -1)
                {
                    MessageBox.Show("Неверно выбран тип!");
                    return;
                }
                if (_abs != null && _emp != null)
                {
                    ApiContext api = new ApiContext();
                    _abs.EmployeeId = _emp.Id;
                    _abs.StartDate = StartDateDatePicker.SelectedDate.Value;
                    _abs.EndDate = EndDateDatePicker.SelectedDate.Value;
                    switch (AbsenceTypeCmbx.SelectedIndex)
                    {
                        case 0: { _abs.Type = AbsenceType.обучение;
                                if (PaidCheckBox.IsChecked == true) _abs.Paid = true; 
                                else if (PaidCheckBox.IsChecked == false) _abs.Paid = false; break; }
                        case 1: { _abs.Type = AbsenceType.отгул; 
                                if (PaidCheckBox.IsChecked == true) _abs.Paid = true; 
                                else if (PaidCheckBox.IsChecked == false) _abs.Paid = false; break; }
                        case 2: { _abs.Type = AbsenceType.отсутствие; 
                                if (PaidCheckBox.IsChecked == true) _abs.Paid = true; 
                                else if (PaidCheckBox.IsChecked == false) _abs.Paid = false; break; }
                        case 3: { _abs.Type = AbsenceType.отпуск; 
                                if (PaidCheckBox.IsChecked == true) _abs.Paid = true; 
                                else if (PaidCheckBox.IsChecked == false) _abs.Paid = false; break; }
                    }
                    _abs.Description = DescriptionTextBox.Text;
                    api.PutAbsence(_abs);
                    MainWindow.init.frame.Navigate(new Pages.Employee(_emp));
                }
                else if (_abs == null && _emp != null)
                {
                    ApiContext api = new ApiContext();
                    Absences newAbsence = new Absences();
                    newAbsence.EmployeeId = _emp.Id;
                    newAbsence.StartDate = StartDateDatePicker.SelectedDate.Value;
                    newAbsence.EndDate = EndDateDatePicker.SelectedDate.Value;
                    switch (AbsenceTypeCmbx.SelectedIndex)
                    {
                        case 0: { newAbsence.Type = AbsenceType.обучение; 
                                if (PaidCheckBox.IsChecked == true) newAbsence.Paid = true; 
                                else if (PaidCheckBox.IsChecked == false) newAbsence.Paid = false; break; }
                        case 1: { newAbsence.Type = AbsenceType.отгул; 
                                if (PaidCheckBox.IsChecked == true) newAbsence.Paid = true;
                                else if (PaidCheckBox.IsChecked == false) newAbsence.Paid = false; break; }
                        case 2: { newAbsence.Type = AbsenceType.отсутствие; 
                                if (PaidCheckBox.IsChecked == true) newAbsence.Paid = true;
                                else if (PaidCheckBox.IsChecked == false) newAbsence.Paid = false; break; }
                        case 3: { newAbsence.Type = AbsenceType.отпуск; 
                                if (PaidCheckBox.IsChecked == true) newAbsence.Paid = true;
                                else if (PaidCheckBox.IsChecked == false) newAbsence.Paid = false; break; }
                    }
                    newAbsence.Description = DescriptionTextBox.Text;
                    api.PostAbsences(newAbsence);
                    Main.Absences.Add(newAbsence);
                    MainWindow.init.frame.Navigate(new Pages.Employee(_emp));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AbsenceTypeCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (AbsenceTypeCmbx.SelectedIndex)
            {
                case 0: { PaidCheckBox.IsEnabled = true; break; }
                case 1: { PaidCheckBox.IsEnabled = false; PaidCheckBox.IsChecked = false; break; }
                case 2: { PaidCheckBox.IsEnabled = false; PaidCheckBox.IsChecked = false; break; }
                case 3: { PaidCheckBox.IsEnabled = false; PaidCheckBox.IsChecked = false; break; }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (_emp != null) MainWindow.init.frame.Navigate(new Pages.Employee(_emp));
            else MainWindow.init.frame.Navigate(new Pages.Employee(null));
        }
    }
}
