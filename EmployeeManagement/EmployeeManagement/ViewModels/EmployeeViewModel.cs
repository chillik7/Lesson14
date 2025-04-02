using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeViewModel : BaseViewModel

    {
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        public ObservableCollection<string> Departments { get; set; }

        private Employee _selectedEmployee;
        private string _selectedDepartment;

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set { _selectedEmployee = value; OnPropertyChanged(nameof(SelectedEmployee)); }
        }

        public string SelectedDepartment
        {
            get => _selectedDepartment;
            set
            {
                _selectedDepartment = value;
                FilterEmployees();
                OnPropertyChanged(nameof(SelectedDepartment));
            }
        }

        public ICommand AddEmployeeCommand { get; }
        public ICommand EditEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }

        public EmployeeViewModel()
        {
            Employees = new ObservableCollection<Employee>
            {
                new Employee { Name = "Иван Иванов", Position = "Менеджер", Department = "Продажи" },
                new Employee { Name = "Анна Смирнова", Position = "Разработчик", Department = "IT" }
            };

            Departments = new ObservableCollection<string> { "Все", "Продажи", "IT", "HR" };
            SelectedDepartment = "Все"; }

            private bool CanEditEmployee(object obj) => SelectedEmployee != null;
            private bool CanDeleteEmployee(object obj) => SelectedEmployee != null;


        private void AddEmployee()
        {
            Employees.Add(new Employee { Name = "Новый сотрудник", Position = "Должность", Department = "IT" });
        }

        private void EditEmployee()
        {
            if (SelectedEmployee == null) return;
            SelectedEmployee.Name = "Измененный сотрудник";
        }

        private void DeleteEmployee()
        {
            if (SelectedEmployee != null)
                Employees.Remove(SelectedEmployee);
        }

        private void FilterEmployees()
        {
            if (SelectedDepartment == "Все") return;
            Employees = new ObservableCollection<Employee>(Employees.Where(e => e.Department == SelectedDepartment));
            OnPropertyChanged(nameof(Employees));
        }
    }
}
