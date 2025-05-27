using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestDesktop.Models
{
    public class Employee : INotifyPropertyChanged
    {
        public int Id { get; set; } //Идентификатор сотрудника
        public int PositionId { get; set; } //Идентификатор должности
        public string? FullName { get; set; } //ФИО
        public DateTime BirthDate { get; set; } //Дата рождения
        public string? WorkPhone { get; set; } //Рабочий телефон
        public string? Office { get; set; } //Кабинет
        public string? Email { get; set; } //Email
        public string? MobilePhone { get; set; } //Мобильный телефон
        public int? DirectorId { get; set; } //Идентификатор руководителя
        public int? AssistantId { get; set; } //Идентификатор помощника
        public DateTime? TerminationDate { get; set; } //Дата увольнения

        public Position? Position { get; set; } //Должность, по ней можно узнать Departament, depId, depName

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
