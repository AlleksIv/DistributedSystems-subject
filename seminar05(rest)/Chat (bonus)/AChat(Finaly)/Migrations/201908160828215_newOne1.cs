namespace AChat_Finaly_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newOne1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StoryModels", "ChatId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoryModels", "ChatId");
        }
    }
}
