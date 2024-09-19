using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ПР43_Осокин.Classes;
using ПР43_Осокин.Context;
using ПР43_Осокин.Models;

namespace ПР43_Осокин.ViewModels
{
    public class VM_Categorys : Notification
    {
        public CategorysContext categorysContext = new CategorysContext();
        public ObservableCollection<Categorys> Categorys { get; set; }
        public VM_Categorys() => Categorys = new ObservableCollection<Categorys>(categorysContext.Categorys);
        public RealyCommand OnAddCategorys
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Categorys newCategorys = new Categorys();
                    Categorys.Add(newCategorys);
                    categorysContext.Categorys.Add(newCategorys);
                    categorysContext.SaveChanges();
                });
            }
        }
    }
}
