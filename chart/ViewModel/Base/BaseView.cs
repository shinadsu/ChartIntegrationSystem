using CommunityToolkit.Mvvm.ComponentModel;

namespace chart.ViewModel.Base
{
    public partial class BaseView : ObservableObject
    {
        public BaseView() { }

        [ObservableProperty]
        private string _title;  

        [ObservableProperty]
        private bool _isBusy; 
    }
}
