using System;
using System.Data;

namespace DataAccess
{
    public class SuperDuperSqlTransaction : IDbTransaction
    {
        private readonly IDbConnection connection;

        public SuperDuperSqlTransaction(IDbConnection connection)
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
            throw new NotImplementedException();
        }

        public IsolationLevel IsolationLevel
        {
            get { throw new NotImplementedException(); }
        }
    }
}