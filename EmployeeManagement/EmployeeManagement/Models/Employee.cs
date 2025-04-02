using System.ComponentModel;

namespace EmployeeManagement.Models
{
    public class Employee : INotifyPropertyChanged
    {
        private string _name;
        private string _position;
        private string _department;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Position
        {
            get => _position;
            set { _position = value; OnPropertyChanged(nameof(Position)); }
        }

        public string Department
        {
            get => _department;
            set { _department = value; OnPropertyChanged(nameof(Department)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
