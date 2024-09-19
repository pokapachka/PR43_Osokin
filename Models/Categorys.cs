using ПР43_Осокин.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using ПР43_Осокин.Classes;
using Schema = System.ComponentModel.DataAnnotations.Schema;

namespace ПР43_Осокин.Models
{
    public class Categorys : Notification
    {
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                Match match = Regex.Match(value, "^.{1,255}$");
                if (!match.Success) MessageBox.Show("Название категории не должно быть пустым, и не более 255 символов!", "Не корректный ввод названия категории.");
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
                if (!match.Success) MessageBox.Show("Описание категории не должно быть пустым, и не более 1000 символов!", "Не корректный ввод описания категории.");
                else
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
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
                    if (!IsEnable) (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_categorys.categorysContext.SaveChanges();
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
                    if (MessageBox.Show("Вы уверены, что хотите удалить категорию?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_categorys.Categorys.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_categorys.categorysContext.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_categorys.categorysContext.SaveChanges();
                    }
                });
            }
        }
    }
}
