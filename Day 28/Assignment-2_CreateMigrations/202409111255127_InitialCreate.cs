namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        City = c.String(),
                        Salary = c.Int(nullable: false),
                        DepartmentId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId_Id)
                .Index(t => t.DepartmentId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepartmentId_Id", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepartmentId_Id" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
