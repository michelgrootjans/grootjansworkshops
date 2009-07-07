using System.Collections.Generic;
using System.Data;
using Migrator.Framework;

namespace Migrations
{
    [Migration(002)]
    public class M002_Character : Migration
    {
        private readonly List<Column> columns;
        internal const string TableName = "Character";

        public M002_Character()
        {
            columns = new List<Column>
                          {
                              new Column("Id", DbType.Int64, ColumnProperty.PrimaryKey),
                              new Column("Account", DbType.String),
                              new Column("Type", DbType.String, ColumnProperty.NotNull),
                              new Column("Name", DbType.String, ColumnProperty.NotNull),
                              new Column("Level", DbType.Int32, ColumnProperty.NotNull),
                              new Column("Gold", DbType.Int32, ColumnProperty.NotNull),
                              new Column("Experience", DbType.Int32),
                              new Column("HitPoints", DbType.Int32, ColumnProperty.NotNull),
                              new Column("MaxHitPoints", DbType.Int32, ColumnProperty.NotNull),
                              new Column("Attack", DbType.Int32, ColumnProperty.NotNull),
                              new Column("Defence", DbType.Int32, ColumnProperty.NotNull)
                          };
        }

        public override void Up()
        {
            Database.AddTable(TableName, columns.ToArray());
        }

        public override void Down()
        {
            Database.RemoveTable(TableName);
        }
    }
}