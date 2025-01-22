using AdministradorTareas.MVVM.ViewModels;
using AdministradorTareas.MVVM.Views;

namespace AdministradorTareas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Routing.RegisterRoute("TaskView", typeof(TaskView));
            MainPage = new NavigationPage(new MainView());
            BindingContext = new MainViewModel();
        }
    }
}
