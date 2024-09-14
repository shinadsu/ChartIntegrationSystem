using chart.Models;
using chart.Repositories;
using chart.ViewModel.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace chart.ViewModel.Postss
{
    public partial class PostsViewModel : BaseView
    {
        private readonly PostsRepository _postsRepository;

        [ObservableProperty]
        public ObservableCollection<Posts> posts = new ObservableCollection<Posts>();

        public PostsViewModel(PostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
            LoadPostsAsync();  // Инициализация загрузки
        }

        public async Task LoadPostsAsync()
        {
            IsBusy = true;
            try
            {
                if (_postsRepository == null)
                    throw new ArgumentNullException(nameof(_postsRepository));

                var postsFromRepo = await _postsRepository.GET();
                Debug.WriteLine($"Loaded {postsFromRepo.Count} posts");

                // Очистите коллекцию перед добавлением новых данных
                posts.Clear();

                foreach (var post in postsFromRepo)
                {
                    posts.Add(post);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка загрузки постов: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
