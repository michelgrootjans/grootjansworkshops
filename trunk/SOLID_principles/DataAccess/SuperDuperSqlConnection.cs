using System;
using System.Data;

namespace DataAccess
{
    public class SuperDuperSqlConnection : IDbConnection
    {
        public IDbTransaction BeginTransaction()
        {
            Console.WriteLine("Beginning a transaction...");
            return new SuperDuperSqlTransaction(this);
        }

        public void Open()
        {
            Console.WriteLine("Opening a connection to the database ...");
        }

        public void Close()
        {
            Console.WriteLine("Closing the database connection");
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing of the database connection");
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public IDbCommand CreateCommand()
        {
            throw new NotImplementedException();
        }

        public string ConnectionString
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int ConnectionTimeout
        {
            get { throw new NotImplementedException(); }
        }

        public string Database
        {
            get { throw new NotImplementedException(); }
        }

        public ConnectionState State
        {
            get { throw new NotImplementedException(); }
        }
    }
}