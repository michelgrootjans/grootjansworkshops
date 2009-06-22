using System.Data;
using Migrator.Framework;

namespace Migrations
{
    [Migration(001)]
    public class M001_HiLoImplementation : Migration
    {
        private const string NextHi = "next_hi";
        private const string TableName = "hibernate_unique_key";

        public override void Up()
        {
            Database.AddTable(TableName,
                              new Column(NextHi, DbType.Int64, ColumnProperty.NotNull));
            Database.Insert(TableName, new[] {NextHi}, new[] {"1"});
        }

        public override void Down()
        {
            Database.RemoveTable(TableName);
        }
    }
}