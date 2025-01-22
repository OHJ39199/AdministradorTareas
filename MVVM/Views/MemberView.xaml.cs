using AdministradorTareas.MVVM.Models;
using AdministradorTareas.MVVM.ViewModels;
using System.Collections.ObjectModel;

namespace AdministradorTareas.MVVM.Views;

public partial class MemberView : ContentPage
{
    public MemberView(Members member, ObservableCollection<Tasks> tasks)
    {
        InitializeComponent();
        BindingContext = new MemberViewModel(member, tasks);
    }
    
}