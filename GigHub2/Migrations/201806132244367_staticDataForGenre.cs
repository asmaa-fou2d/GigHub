namespace GigHub2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class staticDataForGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(Id,Name) values('1','Jazz')");
            Sql("Insert into Genres(Id,Name) values('2','Blues')");
            Sql("Insert into Genres(Id,Name) values('3','Rock')");
            Sql("Insert into Genres(Id,Name) values('4','Country')");
        }

        public override void Down()
        {
            Sql("Delete from Genres where Id IN (1,2,3,4)");
        }
    }
}
