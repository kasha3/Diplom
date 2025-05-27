using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using TestDesktop.Models;

namespace TestDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public static List<Models.Employee> Employees { get; set; }
        public static List<Models.Departament> Departaments { get; set; }
        public static List<Models.Organization> Organizations { get; set; }
        public static List<Models.Position> Positions { get; set; }
        public static List<Models.Absences> Absences { get; set; }
        public static Main? main;

        public List<CanvasDepartment> canvasDepartments = new List<CanvasDepartment>();
        public Main()
        {
            InitializeComponent();
            Employees = new List<Models.Employee>();
            Departaments = new List<Models.Departament>();
            Organizations = new List<Models.Organization>();
            Positions = new List<Models.Position>();
            Absences = new List<Models.Absences>();
            LoadDb();
            LoadCanvasInfo();
            CreateCanvas();
            main = this;
            MainGrid.Children.Add(CreatePlusButton());
        }
        private void LoadCanvasInfo()
        {
            canvasDepartments.Clear();
            canvasDepartments.Add(new CanvasDepartment() { Name = "Дороги России" });
            if (Organizations == null || Departaments == null) return;
            foreach (var org in Organizations)
            {
                canvasDepartments.Add(new CanvasDepartment() { Name = org.Name });
            }
            foreach (var dep in Departaments)
            {
                canvasDepartments.Add(new CanvasDepartment() { Name = dep.Name });
            }
        }

        private void CreateCanvas()
        {
            List<List<CanvasDepartment>> LevelDepartments = new List<List<CanvasDepartment>>();
            foreach (CanvasDepartment item in canvasDepartments)
            {
                string[] level = item.Name.Split('.');
                if (LevelDepartments.Count == level.Length - 1)
                    LevelDepartments.Add(new List<CanvasDepartment>());

                LevelDepartments[level.Length - 1].Add(item);

                if (level.Length > 2)
                {
                    string ParentDepartment = item.Name.Split(' ')[0];
                    ParentDepartment = ParentDepartment.Substring(0, ParentDepartment.Length - 2);
                    item.Parent = LevelDepartments[level.Length - 2].Find(x => x.Name.Split(' ')[0] == ParentDepartment);
                }
                else if (level.Length == 2)
                    item.Parent = LevelDepartments[level.Length - 2][0];
            }

            int MaxLevel = LevelDepartments.Max(x => x.Count);

            int MaxWidth = 10 + 110 * MaxLevel;
            canvas.Width = MaxWidth;
            canvas.Height = LevelDepartments.Count * 100;
            int Row = 0;
            foreach (List<CanvasDepartment> items in LevelDepartments)
            {
                int Index = 0;
                foreach (CanvasDepartment item in items)
                {
                    item.BockScene = CreateElement(item.Name);
                    int PositionLeft = MaxWidth / 2 - (items.Count * 110 / 2) + 5 + (Index * 110);
                    int PositionTop = Row * 90;
                    item.BockScene.Margin = new Thickness(PositionLeft, PositionTop, 0, 0);

                    canvas.Children.Add(item.BockScene);
                    // Рисуем линию до родителя
                    if (item.Parent != null)
                    {
                        Line Line = new Line()
                        {
                            Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#78B24B")),
                            StrokeThickness = 2,
                            X1 = PositionLeft + 50,
                            Y1 = PositionTop - 10,
                            X2 = item.Parent.BockScene.Margin.Left + 50,
                            Y2 = item.Parent.BockScene.Margin.Top + 50,
                        };
                        Line Line2 = new Line()
                        {
                            Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#78B24B")),
                            StrokeThickness = 2,
                            X1 = PositionLeft + 50,
                            Y1 = PositionTop - 10,
                            X2 = PositionLeft + 50,
                            Y2 = PositionTop - 5,
                        };
                        Polygon Arrow = new Polygon()
                        {
                            Points = new PointCollection() {
                                new Point(0,0),
                                new Point(10,0),
                                new Point(5,5),
                            },
                            Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#78B24B")),
                            Margin = new Thickness(PositionLeft + 45, PositionTop - 5, 0, 0)
                        };
                        canvas.Children.Add(Arrow);
                        canvas.Children.Add(Line);
                        canvas.Children.Add(Line2);
                    }
                    Index++;
                }
                Row++;
            }
        }
        public Grid CreateElement(string Value)
        {
            Grid BlockDepartment = new Grid()
            {
                Height = 50,
                Width = 100,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b6db90"))
            };
            if (Value.StartsWith("Дороги России")) BlockDepartment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#78B24B"));
            BlockDepartment.MouseDown += (s, e) => { LoadEmployees(Value); };

            TextBlock Text = new TextBlock()
            {
                Text = Value,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 9
            };
            BlockDepartment.Children.Add(Text);
            return BlockDepartment;
        }
        public void LoadEmployees(string department)
        {
            parent.Children.Clear();
            if (department.StartsWith("Дороги России"))
            {
                foreach (var employee in Employees)
                {
                    if (Employees.Last().Id == employee.Id)
                    {
                        var lastElement = new Elements.EmployeeItem(employee);
                        lastElement.Margin = new Thickness(0, 0, 0, 60);
                        parent.Children.Add(lastElement);
                    }
                    else
                    {
                        parent.Children.Add(new Elements.EmployeeItem(employee));
                    }
                }
            }
            else if (department.Split(' ')[0].Count() == 4)
            {
                var FindDepartmentsIds = Departaments.Where(x => x.Name == department).
                    Select(x => x.Id);
                var FindPositionsIds = Positions.Where(x => FindDepartmentsIds.
                Contains(x.DepartamentId)).Select(x => x.Id);
                foreach (var employee in Employees.Where(x => FindPositionsIds.Contains(x.PositionId)))
                {
                    if (Employees.Last().Id == employee.Id)
                    {
                        var lastElement = new Elements.EmployeeItem(employee);
                        lastElement.Margin = new Thickness(0, 0, 0, 60);
                        parent.Children.Add(lastElement);
                    }
                    else
                    {
                        parent.Children.Add(new Elements.EmployeeItem(employee));
                    }
                }
            }
            else if (department.Split(' ')[0].Count() < 4)
            {
                var FindDepartmentsIds = Departaments.Where(x => x.OrganizationId == Organizations.
                FirstOrDefault(x => x.Name == department).Id).Select(x => x.Id);
                var FindPositionsIds = Positions.Where(x => FindDepartmentsIds.Contains(x.DepartamentId)).
                    Select(x => x.Id);
                foreach (var employee in Employees.Where(x => FindPositionsIds.Contains(x.PositionId)))
                {
                    if (Employees.Last().Id == employee.Id)
                    {
                        var lastElement = new Elements.EmployeeItem(employee);
                        lastElement.Margin = new Thickness(0, 0, 0, 60);
                        parent.Children.Add(lastElement);
                    }
                    else
                    {
                        parent.Children.Add(new Elements.EmployeeItem(employee));
                    }
                }
            }
            else if (department.Split(' ')[0].Count() > 4)
            {
                var FindDepartmentsIds = Departaments.Where(x => x.Name == department).Select(x => x.Id);
                var FindPositionsIds = Positions.Where(x => FindDepartmentsIds.Contains(x.DepartamentId)).Select(x => x.Id);
                foreach (var employee in Employees.Where(x => FindPositionsIds.Contains(x.PositionId)))
                {
                    if (Employees.Last().Id == employee.Id)
                    {
                        var lastElement = new Elements.EmployeeItem(employee);
                        lastElement.Margin = new Thickness(0, 0, 0, 60);
                        parent.Children.Add(lastElement);
                    }
                    else
                    {
                        parent.Children.Add(new Elements.EmployeeItem(employee));
                    }
                }
            }
        }
        private Button CreatePlusButton()
        {
            Button newButton = new Button()
            {
                Width = 60,
                Height = 60,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#78B24B")),
                Content = "+",
                FontSize = 24,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(20, 40, 40, 20),
            };
            newButton.Click += (s, e) => { MainWindow.init.frame.Navigate(new Pages.Employee(null)); };
            Grid.SetColumn(newButton, 1);
            return newButton;
        }
        private void LoadDb()
        {
            Employees.Clear();
            Departaments.Clear();
            Organizations.Clear();
            Positions.Clear();
            Absences.Clear();
            ApiContext api = new ApiContext();
            Employees = api.GetEmployees();
            Departaments = api.GetDepartaments();
            Organizations = api.GetOrganizations();
            Positions = api.GetPositions();
            Absences = api.GetAbsences();
            if (Employees == null || Departaments == null || Organizations == null || Positions == null || Absences == null) return;
            parent.Children.Clear();
            foreach (var employee in Employees)
            {
                if (Employees.Last().Id == employee.Id)
                {
                    var lastElement = new Elements.EmployeeItem(employee);
                    lastElement.Margin = new Thickness(0, 0, 0, 60);
                    parent.Children.Add(lastElement);
                }
                else
                {
                    parent.Children.Add(new Elements.EmployeeItem(employee));
                }
            }
        }
    }
}
