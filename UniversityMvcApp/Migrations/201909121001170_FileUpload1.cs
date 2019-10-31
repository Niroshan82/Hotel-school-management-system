namespace UniversityMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileUpload1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileUploads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileId = c.String(),
                        FileName = c.String(),
                        FileUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileUploads");
        }
    }
}
