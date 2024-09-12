using chart.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chart.DatabaseService
{
    // Класс необходим для конфигурации нашей базы данных
    public class DatabaseSettings
    {
        private const string _databaseName = "lk.db";

        private static string _DbPath => Path.Combine(FileSystem.AppDataDirectory, _databaseName);

        private SQLiteAsyncConnection? _connection;

        private SQLiteAsyncConnection SQLiteAsyncConnection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SQLiteAsyncConnection(_DbPath,
                        SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);
                }
                return _connection;
            }
        }

        public static void DatabasePath()
        {
            Debug.WriteLine($"Existed current path is {_DbPath}");
        }

        public async Task Init()
        {
            try
            {
                if (_connection == null)
                {
                    _connection = SQLiteAsyncConnection;  
                    await _connection.CreateTableAsync<Posts>();
                    await _connection.CreateTableAsync<Categorys>(); 
                    Debug.WriteLine("Таблицы успешно созданы");
                    DatabasePath();
                }
            }
            catch (DbException ex)
            {
                Debug.WriteLine($"Internal database error: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Internal server error: {ex.Message}");
            }
        }

       
        public SQLiteAsyncConnection GetConnection()
        {
            return SQLiteAsyncConnection;
        }


    }
}
