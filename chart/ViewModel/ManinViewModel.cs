using chart.ViewModel.Postss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chart.ViewModel
{
    public class ManinViewModel
    {
        public CategoryViewModel Category { get; set; }
        public PostsViewModel Posts { get; set; }

        public ManinViewModel(CategoryViewModel categoryViewModel, PostsViewModel postsViewModel) 
        {
            this.Category = categoryViewModel;
            this.Posts = postsViewModel;
        }
    }
}
