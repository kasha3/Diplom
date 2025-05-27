using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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
using TestDesktop.Pages;

namespace TestDesktop.Elements
{
    /// <summary>
    /// Логика взаимодействия для EmployeeItem.xaml
    /// </summary>
    public partial class EmployeeItem : UserControl
    {
        Models.Employee _this;
        public EmployeeItem(Models.Employee employee)
        {
            InitializeComponent();
            if (employee != null)
            {
                _this = employee;
                if (employee.TerminationDate != null && employee.TerminationDate.Value.AddDays(30).Ticks >= DateTime.Now.Ticks)
                {
                    UpdateEmployeeUI();
                }
                departamentAndPos.Text = Main.Departaments.ToList().FirstOrDefault(x => x.Id == Main.Positions.ToList().
                FirstOrDefault(x => x.Id == employee.PositionId).DepartamentId).Name.ToString() + " - " + 
                Main.Positions.ToList().FirstOrDefault(x => x.Id == employee.PositionId).Name.ToString();
                fullname.Text = employee.FullName?.ToString();
                phoneNumberAndEmail.Text = employee.WorkPhone?.ToString() + " " + employee.Email?.ToString();
                office.Text = employee.Office?.ToString();
            }
            MainGrid.MouseDown += (s, e) => { MainWindow.init.frame.Navigate(new Pages.Employee(employee)); };
        }

        private void TerminateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_this != null)
            {
                var result = MessageBox.Show($"Вы уверены что хотите уволить сотрудника {_this.FullName} ?",
                    "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    // на хостинге не доступны процедуры
                    //using (var db = new HRContext())
                    //{
                    //    var sql = "CALL TerminateEmployee(@p0);";
                    //    db.Database.ExecuteSqlRaw(sql, _this.Id);
                    //}
                    ApiContext apiContext = new ApiContext();
                    _this.TerminationDate = DateTime.Now;
                    apiContext.PutEmployee(_this);
                    UpdateEmployeeUI();
                }
            }
        }
        private void UpdateEmployeeUI()
        {
            MainGrid.Background = new SolidColorBrush(Colors.Gray);
            MainGrid.Opacity = 0.8;
            TerminateBtn.Visibility = Visibility.Hidden;
        }
    }
}
