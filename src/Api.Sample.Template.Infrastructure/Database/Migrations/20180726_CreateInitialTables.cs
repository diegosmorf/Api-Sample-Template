using FluentMigrator;

namespace Api.Sample.Template.Infrastructure.Database.Migrations
{
    [Migration(20180726090000)]
    public class Migration_20180726090000_CreateInitialTables : Migration
    {
        public override void Up()
        {
            Create.Table("Fund")
                .WithColumn("Id").AsGuid().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255)
                .WithColumn("Description").AsString(255)
                .WithColumn("CreatedDate").AsDateTime()
                .WithColumn("ModifiedDate").AsDateTime()
                .WithColumn("ModifiedBy").AsString(255);
        }

        public override void Down()
        {
            Delete.Table("Fund");
        }
    }
}
