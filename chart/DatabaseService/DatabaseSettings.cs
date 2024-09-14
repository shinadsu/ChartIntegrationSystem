using chart.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace chart.DatabaseService
{
    // Класс необходим для конфигурации нашей базы данных
    public class DatabaseSettings
    {
        private const string _databaseName = "lk.db";

        // Укажите путь к директории, где будет создан файл базы данных
        private static string _DbPath => Path.Combine(Path.Combine(FileSystem.AppDataDirectory), _databaseName);

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
            Debug.WriteLine($"Current path is {_DbPath}");
        }

        public async Task Init()
        {
            try
            {
                var directory = Path.GetDirectoryName(_DbPath);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Проверяем, существует ли база данных перед созданием
                if (!File.Exists(_DbPath))
                {
                    _connection = SQLiteAsyncConnection; // Инициализируем соединение
                    await _connection.CreateTableAsync<Posts>();
                    await _connection.CreateTableAsync<Categorys>();
                    Debug.WriteLine("Tables successfully created");
                }
                else
                {
                    _connection = SQLiteAsyncConnection; // Если база данных существует, просто получаем соединение
                }
                DatabasePath();
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
