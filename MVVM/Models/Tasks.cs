
namespace AdministradorTareas.MVVM.Models
{
    public class Tasks
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public bool Assigned { get; set; }
        public string? AssignedMember { get; set; }
        public int Priority { get; set; }

        internal static void Add(Tasks tasks)
        {
            throw new NotImplementedException();
        }

        internal static Tasks FirstOrDefault(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
