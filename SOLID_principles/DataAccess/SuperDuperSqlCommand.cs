using System;
using System.Data;

namespace DataAccess
{
    public class SuperDuperSqlCommand : IDbCommand
    {
        private readonly SuperDuperSqlConnection connection;
        private readonly string command;

        public SuperDuperSqlCommand(SuperDuperSqlConnection connection, string command)
        {
            this.connection = connection;
            this.command = command;
        }

        public IDataReader ExecuteReader()
        {
            Console.WriteLine("Executing '{0}' on {1}", command, connection.GetType());
            return new SuperDuperSqlDataReader(GetTableName());
        }

        private string GetTableName()
        {
            string tableName = null;
            if (command.ToUpper().Contains("FROM CUSTOMERS"))
                tableName = "Customer";
            else if (command.ToUpper().Contains("FROM ORDERS"))
                tableName = "Order";
            return tableName;
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing of the command...");
        }

        public void Prepare()
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public IDbDataParameter CreateParameter()
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        public IDataReader ExecuteReader(CommandBehavior behavior)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar()
        {
            throw new NotImplementedException();
        }

        public IDbConnection Connection
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IDbTransaction Transaction
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string CommandText
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int CommandTimeout
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public CommandType CommandType
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IDataParameterCollection Parameters
        {
            get { throw new NotImplementedException(); }
        }

        public UpdateRowSource UpdatedRowSource
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}