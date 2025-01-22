using AdministradorTareas.MVVM.Models;
using System.Collections.ObjectModel;

namespace AdministradorTareas.MVVM.Views;

public partial class MainView : ContentPage
{
    public ObservableCollection<Tasks> Tasks { get; set; }
    public MainView()
	{
		InitializeComponent();
	}

    private async void OnTaskSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Tasks selectedTask)
        {
            // Navigate to task details page
            await Navigation.PushAsync(new TaskView(selectedTask));
        }
    }

    private async void OnMemberSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Members selectedMember)
        {
            // Navigate to member details page
            await Navigation.PushAsync(new MemberView(selectedMember, Tasks));
        }
    }
}