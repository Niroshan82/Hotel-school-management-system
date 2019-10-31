namespace RMS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerRegistrations",
                c => new
                    {
                        RegistrationID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        ContactNo = c.Int(nullable: false),
                        Address = c.String(maxLength: 200),
                        UserName = c.String(maxLength: 10),
                        Password = c.String(maxLength: 100),
                        ConfirmPassword = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.RegistrationID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmpCode = c.String(maxLength: 10),
                        Status = c.String(maxLength: 10),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Gender = c.String(maxLength: 10),
                        NicNo = c.String(maxLength: 15),
                        ContactNo = c.Int(nullable: false),
                        Email = c.String(maxLength: 50),
                        Address = c.String(maxLength: 200),
                        Position = c.String(maxLength: 20),
                        Image = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Comments = c.String(maxLength: 500),
                        Rating = c.Int(nullable: false),
                        EnteredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FeedbackID);
            
            CreateTable(
                "dbo.FoodCategories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 10),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailsID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        FoodName = c.String(maxLength: 10),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailsID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(maxLength: 50),
                        OrderName = c.String(maxLength: 10),
                        Date = c.DateTime(nullable: false),
                        TotalMoney = c.Single(nullable: false),
                        Confirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        ItemCode = c.String(nullable: false, maxLength: 10),
                        Price = c.Single(nullable: false),
                        Category = c.String(maxLength: 10),
                        Description = c.String(nullable: false, maxLength: 500),
                        Image = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.FoodCategories");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Employees");
            DropTable("dbo.CustomerRegistrations");
        }
    }
}
