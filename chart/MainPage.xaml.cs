using chart.ViewModel;
using chart.ViewModel.Postss;
using System.Diagnostics;

namespace chart
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage(PostsViewModel postsViewModel, CategoryViewModel categoryViewModel)
        {
            InitializeComponent();
            Debug.WriteLine("Setting BindingContext");
            //postsCollectionView.BindingContext = postsViewModel;
            //categoriesCollectionView.BindingContext = categoryViewModel;
        }

    }

}
