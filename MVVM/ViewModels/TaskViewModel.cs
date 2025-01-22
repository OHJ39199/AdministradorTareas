using AdministradorTareas.MVVM.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdministradorTareas.MVVM.ViewModels
{
    class TaskViewModel : BindableObject
    {
        private Tasks? _task;
        public Tasks Task
        {
            get => _task;
            set
            {
                if (_task != value)
                {
                    _task = value;
                    OnPropertyChanged();
                }
            }
        }
        public TaskViewModel(Tasks task)
        {
            Task = task;
        }

        public void LoadTask(string taskId)
        {
            // Aquí cargaría la tarea basada en el ID
            
            Task = new Tasks
            {
                Name = "Example Task",
                Description = "This is an example task",
                Image = "example.png",
                Assigned = true
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddTask()
        {
            Tasks.Add(new Tasks
            {
                Name = "New Task",
                Description = "Description of new task",
                Image = "default.png",
                Assigned = false
            });
        }
    }
}

