using chart.DatabaseService;
using chart.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chart.Repositories
{
    // репозиторий для взаимодействия с базой
    public class PostsRepository : DatabaseSettings
    {
        private readonly DatabaseSettings _databaseService;

        public PostsRepository(DatabaseSettings databaseSettings)
        {
            _databaseService = databaseSettings;
        }

        public async Task<List<Posts>> GET()
        {
            await Init(); // Инициализация базы данных

            var connection = _databaseService.GetConnection(); // Получаем соединение

            var posts = await connection.Table<Posts>().ToListAsync();
            Debug.WriteLine($"Retrieved {posts.Count} posts from database.");
            foreach (var post in posts)
            {
                Debug.WriteLine($"Current post id: {post.Id}\nPost Url - {post.Url} Post Title - {post.Title} Post Description - {post.Description} ");
            }
            
            return posts;
        }

    }
}
