using ERPSystem.MAUI.Models;
using ERPSystem.MAUI.PageModels;

namespace ERPSystem.MAUI.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}