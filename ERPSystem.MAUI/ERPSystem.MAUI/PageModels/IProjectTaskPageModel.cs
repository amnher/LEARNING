using CommunityToolkit.Mvvm.Input;
using ERPSystem.MAUI.Models;

namespace ERPSystem.MAUI.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}