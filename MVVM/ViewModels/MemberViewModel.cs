using AdministradorTareas.MVVM.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AdministradorTareas.MVVM.ViewModels
{
    internal class MemberViewModel : BindableObject
    {
        private Members _member;
        public ICommand EditMemberCommand { get; }
        public ICommand AssignTaskCommand { get; }
        public ObservableCollection<Tasks> Tasks { get; set; }

        public MemberViewModel(Members member, ObservableCollection<Tasks> tasks)
        {
            Member = member;
            EditMemberCommand = new Command(EditMember);
            AssignTaskCommand = new Command(AssignTask);
        }

        public Members Member
        {
            get => _member;
            set
            {
                if (_member != value)
                {
                    _member = value;
                    OnPropertyChanged();
                }
            }
        }
        private void EditMember()
        {
            Member.Name = "Updated Name";
            Member.Surname = "Updated Surname";
            OnPropertyChanged(nameof(Member));
        }
        private void AssignTask()
        {
            var taskToAssign = Tasks.FirstOrDefault(t => !t.Assigned);
            if (taskToAssign != null)
            {
                taskToAssign.Assigned = true;
                taskToAssign.AssignedMember = Member.Name;
                Member.AssignedTasks.Add(taskToAssign);
                OnPropertyChanged(nameof(Member.AssignedTasks));
            }
        }
    }
}
