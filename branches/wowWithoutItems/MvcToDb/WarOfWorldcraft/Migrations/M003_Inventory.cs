using System.Collections.Generic;
using System.Data;
using Migrator.Framework;
using System.Linq;

namespace Migrations
{
    [Migration(003)]
    public class M003_Inventory : Migration
    {
        internal static string TableName = "Inventory";
        private IList<Column> columns;
        private static string ForeignKeyToCharacter = "FK_Inventory_Character";

        public M003_Inventory()
        {
            columns = new List<Column>();
            columns.Add(new Column("Id", DbType.Int64, ColumnProperty.PrimaryKey));
            columns.Add(new Column("CharacterId", DbType.Int64, ColumnProperty.ForeignKey));
            columns.Add(new Column("Name", DbType.String, ColumnProperty.NotNull));
            columns.Add(new Column("Price", DbType.Int32, ColumnProperty.NotNull, 0));
        }

        public override void Up()
        {
            Database.AddTable(TableName, columns.ToArray());
            Database.AddForeignKey(ForeignKeyToCharacter, TableName, "CharacterId", M002_Character.TableName, "Id");
        }

        public override void Down()
        {
            Database.RemoveForeignKey(TableName, ForeignKeyToCharacter);
            Database.RemoveTable(TableName);
        }
    }
}