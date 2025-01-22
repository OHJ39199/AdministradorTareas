using AdministradorTareas.MVVM.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AdministradorTareas.MVVM.ViewModels;

public class MainViewModel 
{
    public ObservableCollection<Members> Members { get; set; } = new ObservableCollection<Members>()
    {
        new Members
        {
            Name = "Andrés",
            Surname = "Caso",
            Image = "a.png",
        },
        new Members
        {
            Name = "Samantha",
            Surname = "Burch",
            Image = "s.png",
        },
        new Members
        {
            Name = "Emely",
            Surname = "Caso",
            Image = "e.png",
        },
        new Members
        {
            Name = "Lily",
            Surname = "Caso",
            Image = "l.png",
        },

    };
    public ObservableCollection<Tasks> Tasks { get; set; } = new ObservableCollection<Tasks>()
    {
        new Tasks
        {
            Name = "Do laundry",
            Description = "Sort, wash, and hang clothes",
            Image = "laundry.png",
            Assigned = true,
            AssignedMember = "Andres",
            Priority = 2,
        },
        new Tasks
        {
            Name = "Wash dishes",
            Description = "Wash dishes, clean countertops and appliances",
            Image = "dishes.png",
            Assigned = true,
            AssignedMember = "Emely",
            Priority = 1,
        },
        new Tasks
        {
            Name = "Vacuum",
            Description = "Vacuum and clean all the house floor, specially the living room floors",
            Image = "vacuum.png",
            Assigned = true,
            AssignedMember = "Samantha",
            Priority = 2,
        },
        new Tasks
        {
            Name = "Clean windows",
            Description = "clean the windows",
            Image = "windows.png",
            Assigned = false,
            Priority = 3,
        },
        new Tasks
        {
            Name = "Empty dishwasher",
            Description = "Program, empty and clean the dishwasher",
            Image = "dishwasher.png",
            Assigned = true,
            AssignedMember = "Andres",
            Priority = 1,
        },
        new Tasks
        {
            Name = "Take out rurbish",
            Description = "Collect and take out rubbish from all rooms",
            Image = "rubbish.png",
            Assigned = true,
            AssignedMember = "Lily",
            Priority = 1,
        }


    };

    public ICommand? NavigateToTaskDetailsCommand { get; }
    public ICommand AddTaskCommand { get; }

    public MainViewModel()
    {
        AddTaskCommand = new Command(AddTask);
        DeleteTaskCommand = new Command(DeleteTask);
        
    }

    private void AddTask()
    {
        var newTask = new Tasks
        {
            Name = "New Task",
            Description = "Description of the new task",
            Image = "default.png",
            Assigned = false,
            Priority = 1
        };

        Tasks.Add(newTask);
    }

    /**
     * this will show display alerts
     * we will use them when  deletting tasks
     */
    private async Task<bool> ConfirmAction(string message)
    {
        return await Application.Current.MainPage.DisplayAlert("Confirm", message, "Yes", "No");
    }

    /**
     * Method use to delete a task
     * 
    */
    public ICommand DeleteTaskCommand { get; }

    private async void DeleteTask()
    {
    var selectedTask = Tasks.FirstOrDefault(t => t.Assigned == false);
        if (selectedTask != null)
        {
            bool confirmed = await ConfirmAction($"Are you sure you want to delete the task '{selectedTask.Name}'?");
            if (confirmed)
            {
                Tasks.Remove(selectedTask);
            }
        }
    }

    /**
     * gives order to the tasks using priority, 
     * thats what i want to do, still not working
     **/
    public void SortTasksByPriority()
    {
        var sortedTasks = Tasks.OrderBy(t => t.Priority).ToList();
        Tasks.Clear();
        foreach (var task in sortedTasks)
        {
            Tasks.Add(task);
        }
    }

    /**
     * assign a member to a task
     * working in progress
     */
    public void AssignTaskToMember(Tasks task, Members member)
    {
        task.AssignedMember = member.Name;
        task.Assigned = true;
        member.AssignedTasks.Add(task);
    }
}