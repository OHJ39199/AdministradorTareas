using System.Collections.ObjectModel;

namespace AdministradorTareas.MVVM.Models
{
    public class Members
    {
        
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Image { get; set; }

        public ObservableCollection<Tasks> AssignedTasks { get; set; } = [];

    }
}
