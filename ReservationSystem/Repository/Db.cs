using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace ReservationSystem.Repository
{
    /// <summary>
    /// Класс, содержащий обобщенные методы для необходимых типов исполнения sql-запросов в ADO.NET
    /// </summary>
    public class Db
    {
        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Конструктор, который получает строку подключения через IOptions
        /// </summary>
        /// <param name="options">Сервис, через который мы передаем троку подключения</param>
        public Db(IOptions<ConnectionStringOption> options)
        {
            connectionString = options.Value.DefaultConnection;
        }
        
        
        /// <summary>
        /// Обобщенный метод для получения списка записей из БД
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="readerFunc"></param>
        /// <param name="args"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetList<T>(string storedProcedure, Func<IDataReader, T> readerFunc, params DbParam[] args)
        {
            var result = new List<T>();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = OpenConnection(storedProcedure, connection);

                foreach (var dbParam in args)
                {
                    command.Parameters.AddWithValue(dbParam.Name, dbParam.Value);
                }

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(readerFunc(reader));
                }

                return result;
            }
        }
        
        public T GetItem<T>(string storedProcedure, Func<IDataReader, T> readerFunc, params DbParam[] args)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = OpenConnection(storedProcedure, connection);

                foreach (var dbParam in args)
                {
                    command.Parameters.AddWithValue(dbParam.Name, dbParam.Value);
                }

                var reader = command.ExecuteReader();
                if (reader.HasRows && reader.Read())
                    return readerFunc(reader);
                
                return default;
            }
        }

        /// <summary>
        /// Обобщенный метод для добавления записей в БД
        /// </summary>
        public void ExecuteNonQuery(string storedProcedure, params DbParam[] args)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = OpenConnection(storedProcedure, connection);

                foreach (var dbParam in args)
                {
                    command.Parameters.AddWithValue(dbParam.Name, dbParam.Value);
                }

                var result = command.ExecuteNonQuery();
            }
        }
        
        /// <summary>
        /// Открывает соединение и возвращает объект типа command
        /// </summary>
        /// <param name="sqlExpression"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        private static SqlCommand OpenConnection(string sqlExpression, SqlConnection connection)
        {
            connection.Open();
            var command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            return command;
        }
    }
    
    
}