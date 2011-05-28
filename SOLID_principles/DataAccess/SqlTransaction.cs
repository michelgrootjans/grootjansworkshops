using System;
using System.Data;

namespace DataAccess
{
    public class SqlTransaction : IDbTransaction
    {
        private readonly IDbConnection connection;

        public SqlTransaction(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing of the transaction...");
            connection.Close();
            connection.Dispose();
        }

        public void Commit()
        {
            Console.WriteLine("Commiting the transaction...");
        }

        public IDbConnection Connection
        {
            get { return connection; }
        }

        public void Rollback()
        {
            Console.WriteLine("Rolling back the transaction...");
        }

        public IsolationLevel IsolationLevel
        {
            get
            {
                return IsolationLevel.Chaos; //hehe }
            }
        }
    }
}