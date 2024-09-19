using ПР43_Осокин.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using Schema = System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace ПР43_Осокин.Models
{
    public class Tasks : Notification
    {
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                Match match = Regex.Match(value, "^.{1,255}$");
                if (!match.Success) MessageBox.Show("Название задачи не должно быть пустым, и не более 255 символов!", "Не корректный ввод названия задачи.");
                else
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                Match match = Regex.Match(value, "^.{1,1000}$");
                if (!match.Success) MessageBox.Show("Описание не должно быть пустым, и не более 1000 символов!", "Не корректный ввод описания.");
                else
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        private int categoryId;
        public int CategoryId
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }
        private string priority;
        public string Priority
        {
            get { return priority; }
            set
            {
                Match match = Regex.Match(value, "^.{1,20}$");
                if (!match.Success) MessageBox.Show("Приоритет задачи не должен быть пустым, и не более 20 символов!", "Не корректный ввод приоритета.");
                else
                {
                    priority = value;
                    OnPropertyChanged("Priority");
                }
            }
        }
        private DateTime term;
        public DateTime Term
        {
            get { return term; }
            set
            {
                term = value;
                OnPropertyChanged("Term");
            }
        }
        [Schema.NotMapped]
        private bool isEnable;

        [Schema.NotMapped]
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                OnPropertyChanged("IsEnable");
                OnPropertyChanged("IsEnableText");
            }
        }
        [Schema.NotMapped]
        public string IsEnableText
        {
            get
            {
                if (IsEnable) return "Сохранить";
                else return "Изменить";
            }
        }
        [Schema.NotMapped]
        public RealyCommand OnEdit
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    IsEnable = !IsEnable;
                    if (!IsEnable) (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.tasksContext.SaveChanges();
                });
            }
        }
        [Schema.NotMapped]
        public RealyCommand OnDelete
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить задачу?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.Tasks.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.tasksContext.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.tasksContext.SaveChanges();
                    }
                });
            }
        }
        [Schema.NotMapped]
        public ObservableCollection<Categorys> Categorys
        {
            get
            {
                return new ObservableCollection<Categorys>(new Context.CategorysContext().Categorys);
            }
        }
    }
}
