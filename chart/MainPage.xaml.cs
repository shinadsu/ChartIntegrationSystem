using chart.ViewModel;
using chart.ViewModel.Postss;
using System.Diagnostics;

namespace chart
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        PostsViewModel _postViewModel;

        public MainPage(PostsViewModel postsViewModel)
        {
            InitializeComponent();
            Debug.WriteLine("Setting BindingContext");
            this.BindingContext = postsViewModel;
            
        }

    }

}
