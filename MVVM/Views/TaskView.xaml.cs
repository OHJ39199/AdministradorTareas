using AdministradorTareas.MVVM.Models;
using AdministradorTareas.MVVM.ViewModels;

namespace AdministradorTareas.MVVM.Views;

public partial class TaskView : ContentPage
{
    public string TaskId { get; set; }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is TaskViewModel viewModel)
        {
            viewModel.LoadTask(TaskId);
        }
    }
    public TaskView(Tasks task)
    {
		InitializeComponent();
        BindingContext = new TaskViewModel(task);
    }  
}