/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: ConnectionTester.cs
/// File Description: Helper to test database connection
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.Helpers
{
    #region Using directives

    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Logging;
    using Npgsql;

    #endregion Using directives

    /// <summary>
    /// Helper to test database connection
    /// </summary>
    public static class ConnectionTester
    {
        /// <summary>
        /// Tests a SQL Server connection using the provided connection string
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <param name="logger">The logger instance</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public static async Task TestAsync(string connectionString, ILogger logger)
        {
            try
            {
                await using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync().ConfigureAwait(false);

                // Command test
                await using var command = new SqlCommand("SELECT 1", connection);
                var result = await command.ExecuteScalarAsync().ConfigureAwait(false);
                logger.LogInformation("SQL Express connection test succeeded. Result: {Result}", result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Database connection test failed.");
                throw;
            }
        }

        /// <summary>
        /// Tests a Neon connection using the provided connection string
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <param name="logger">The logger instance</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public static async Task TestNeonAsync(string connectionString, ILogger logger)
        {
            try
            {
                await using var connection = new NpgsqlConnection(connectionString);
                await connection.OpenAsync().ConfigureAwait(false);

                // Command test
                await using var command = new NpgsqlCommand("SELECT 1", connection);
                var result = await command.ExecuteScalarAsync().ConfigureAwait(false);
                logger.LogInformation("Neon connection test succeeded. Result: {Result}", result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Database connection test failed.");
                throw;
            }
        }
    }
}

