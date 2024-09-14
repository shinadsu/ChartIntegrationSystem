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
    public class CategoryRepositorys : DatabaseSettings
    {   
        private DatabaseSettings _dataBase;
        public CategoryRepositorys(DatabaseSettings databaseSettings)
        {
            _dataBase = databaseSettings;
        }

        public async Task<List<Categorys>> GET()
        {
            await Init();

            var connection = _dataBase.GetConnection();

            var listOfCategorys = await connection.Table<Categorys>().ToListAsync();
            foreach (var post in listOfCategorys)
            {
                Debug.WriteLine($"Current category id: {post.Id} Post Title - {post.Title} Post Description - {post.Description} ");
            }

            return listOfCategorys;
        }

    }
}
