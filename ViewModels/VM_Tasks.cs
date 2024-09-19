using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ПР43_Осокин.Classes;
using ПР43_Осокин.Context;
using ПР43_Осокин.Models;

namespace ПР43_Осокин.ViewModels
{
    public class VM_Tasks : Notification
    {
        public TasksContext tasksContext = new TasksContext();
        public ObservableCollection<Tasks> Tasks { get; set; }
        public VM_Tasks() => Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks);
        public RealyCommand OnAddTasks
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    Tasks newTasks = new Tasks();
                    Tasks.Add(newTasks);
                    tasksContext.Tasks.Add(newTasks);
                    tasksContext.SaveChanges();
                });
            }
        }
    }
}
