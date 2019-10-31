namespace UniversityMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblFileDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblFileDetails",
                c => new
                    {
                        SQLID = c.Int(nullable: false, identity: true),
                        FILENAME = c.String(),
                        FILEURL = c.String(),
                    })
                .PrimaryKey(t => t.SQLID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblFileDetails");
        }
    }
}
