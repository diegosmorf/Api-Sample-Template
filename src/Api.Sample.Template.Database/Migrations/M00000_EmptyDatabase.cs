using FluentMigrator;

namespace Api.Sample.Template.Database.Migrations
{
    [Migration(0)]
    public class M00000_EmptyDatabase : Migration
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
