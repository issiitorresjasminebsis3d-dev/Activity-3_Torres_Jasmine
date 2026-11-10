using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace torresJasmine_Inventory_Management_System
{
    internal static class Database
    {
        private const string DatabaseFileName = "torresJasmine.accdb";

        private static string DatabasePath => FindDatabasePath();

        public static string CurrentDatabasePath => DatabasePath;

        private static string FindDatabasePath()
        {
            DirectoryInfo? directory = new(AppContext.BaseDirectory);

            while (directory is not null)
            {
                bool isProjectDirectory =
                    Directory.EnumerateFiles(directory.FullName, "*.csproj").Any() ||
                    Directory.EnumerateFiles(directory.FullName, "*.slnx").Any();

                if (isProjectDirectory)
                {
                    return Path.Combine(directory.FullName, DatabaseFileName);
                }

                directory = directory.Parent;
            }

            return Path.Combine(AppContext.BaseDirectory, DatabaseFileName);
        }

        private static string ConnectionString =>
            $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={DatabasePath};Persist Security Info=False;";

        public static OleDbConnection CreateConnection()
        {
            if (!File.Exists(DatabasePath))
            {
                throw new FileNotFoundException(
                    $"The Access database was not found at '{DatabasePath}'.",
                    DatabasePath);
            }

            return new OleDbConnection(ConnectionString);
        }

        public static async Task<int> ExecuteNonQueryAsync(
            string sql,
            params OleDbParameter[] parameters)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(sql);

            await using OleDbConnection connection = CreateConnection();
            await connection.OpenAsync();

            await using OleDbCommand command = new(sql, connection);
            command.Parameters.AddRange(parameters);
            return await command.ExecuteNonQueryAsync();
        }

        public static async Task<object?> ExecuteScalarAsync(
            string sql,
            params OleDbParameter[] parameters)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(sql);

            await using OleDbConnection connection = CreateConnection();
            await connection.OpenAsync();

            await using OleDbCommand command = new(sql, connection);
            command.Parameters.AddRange(parameters);
            return await command.ExecuteScalarAsync();
        }

        public static async Task<DbDataReader> ExecuteReaderAsync(
            string sql,
            params OleDbParameter[] parameters)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(sql);

            OleDbConnection connection = CreateConnection();
            try
            {
                await connection.OpenAsync();

                OleDbCommand command = new(sql, connection);
                command.Parameters.AddRange(parameters);

                return await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
            }
            catch
            {
                await connection.DisposeAsync();
                throw;
            }
        }
    }
}
